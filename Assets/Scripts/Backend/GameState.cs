using System;
using System.Collections.Generic;
using System.Diagnostics;
using Random = System.Random;

/*
 * This class represents the States of the game
 */
namespace Backend
{
    public static class GameState
    {
        public const int StartMoney = 500;  // how much money the player starts with
        public static int s_Year;
        public static int s_Phase;
        public static int s_WeatherIndex;
        public static Household s_Player;
        public static Household[] s_Households;  // originally planned to have AI players but not enough time :(
        public static PopupManager PopupManagerInstance { get; private set; }
        public static Household[] s_PredefinedHouseholds = new Household[]
        {
            new Household(StartMoney, "Madhar", 3, 2, 3),
            new Household(StartMoney, "Bralch", 4, 2, 3),
            new Household(StartMoney, "Rama", 4, 3, 4),
            new Household(StartMoney, "Dulai", 4, 5, 4),
            new Household(StartMoney, "Grewal", 4, 6, 5),
            new Household(StartMoney, "Kahlon", 3, 2, 4),
            new Household(StartMoney, "Aujla", 4, 2, 2),
            new Household(StartMoney, "Sandha", 4, 3, 6),
            new Household(StartMoney, "Kohli", 0, 2, 1),
            new Household(StartMoney, "Gill", 2, 4, 7),
            new Household(StartMoney, "Dhillon", 1, 2, 2),
            new Household(StartMoney, "Singh", 2, 3, 3),
            new Household(StartMoney, "Kapoor", 3, 5, 5),
            new Household(StartMoney, "Bhatia", 2, 2, 2),
            new Household(StartMoney, "Gupta", 3, 5, 7),
            new Household(StartMoney, "Khan", 1, 3, 4)   // added to make it an even number
        };

        private static int _startingAcresOfLand = 0;

        // Initialize the game
        public static void Initialize(Household Player)
        {
            // create a COPY of the player
            // We kind of messed up by making the predefined households an array of objects
            // because objects are passed by reference
            // so starvation would mutate the player object
            // It would be better to load the information from something like a JSON file and
            // create a new Household object in the initialize method
            s_Player = new(StartMoney, Player.Family.Name, Player.Family.GetChildrenAmount(), Player.Family.GetAdultAmount(), Player.Land.Plots.Count);
            s_Year = 0;
            s_Phase = 0;
            Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Households = new Household[] { Player };

            Market.Initialize();

            _startingAcresOfLand = Player.Land.Plots.Count;
        }

        // (Year 2+ only) Choose random village event and household event for each household
        //Read WorkshopSheets/Fate Seeds and Tools Cards.pdf
        //These can be implemented however you think makes sense; make sure it's scalable (easy to add new events), can affect GameState and other important variables, and Household events should be able to affect specific households
        //Possible for there to be no village event, or for a household to have no event
        public static void AdvanceToPhaseOne()
        {
            // If player's wheat is < 0, remove the first children or adults that cannot be fed
            // For example, child consumption is 5 and adult consumption is 10
            // If you have -4 wheat, one child starves. If you have -6 wheat, two children starve.
            // If you have -4 or -6 wheat and no children, an adult starves.
            // If you have -20 wheat, two adults starve.
            // If you don't harvest anything, your entire family should die the next year (if you don't buy more wheat)
            // After starvation, if your family has no adults left, end the game (load results screen directly)
            while (s_Player.Wheat < 0 && s_Player.Family.GetAdultAmount() > 0)
            {
                // Remove children first because they're less useful than adults
                if (s_Player.Family.GetChildrenAmount() > 0)
                {
                    Child child = s_Player.Family.Children[0];
                    string name = child.FirstName;
                    s_Player.Family.Children.RemoveAt(0);
                    PopupManager.QueuePopup("Notice", $"Your child, {name}, starved to death!", "R.I.P.");
                    s_Player.Wheat += Child.Consumption;
                }
                else if (s_Player.Family.GetAdultAmount() > 0)
                {
                    Adult adult = s_Player.Family.Adults[0];
                    string name = adult.FirstName;
                    if (adult.HasOx)
                    {
                        s_Player.Inventory.AddItem("Ox");
                    }
                    s_Player.Family.Adults.RemoveAt(0);
                    PopupManager.QueuePopup("Notice", $"An adult, {name}, starved to death!", "R.I.P.");
                    s_Player.Wheat += Adult.Consumption;
                }
                s_Player.Wheat = Math.Min(s_Player.Wheat, 0);  // don't let it go over 0
            }

            if (s_Player.Family.GetAdultAmount() <= 0)
            {
                PopupManager.QueuePopup("Game Over!", $"All of your adults starved to death!", "Aw man");
                SceneUtils.LoadScene("Results");
                return;
            }

            Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Year++;
            s_Phase = 1;

            SceneUtils.LoadScene("ManageFarm");

            Market.UpdateWheatPrice();
            Market.ActivateProduct("HYC Seed");  // in case it was deactivated last year
            Market.SetPriceMultiplier("Ox", 1);  // in case it was halved last year
            Market.SetPriceMultiplier("Tubewell", 1);
            s_Player.Land.SetYieldMultiplier(1);  // in case it was halved last year

            if (s_Year >= 2)
            {
                Fate.TriggerYearlyEvents();

                foreach (Household household in s_Households)
                {
                    // age up children when they're old enough
                    Family fam = household.Family;
                    for (int i = fam.Children.Count - 1; i > -1; i--)
                    {
                        Child child = fam.Children[i];
                        child.IncrementAge();
                        if (child.Age <= 12)
                        {
                            continue;
                        }

                        fam.Children.Remove(child);
                        Adult newAdult = child.ToAdult();
                        fam.Adults.Add(newAdult);
                    }
                }
            }

            if (s_Year == 1)
            {
                AdvanceToPhaseTwo();
            }
            else if (!s_Player.Inventory.Contains("Tubewell"))
            {
                PopupManager.QueuePopup("Notice", $"Irrigation skipped due to lack of tubewell.", "Okay");
                AdvanceToPhaseTwo();
            }
        }

        public static void AdvanceToPhaseTwo()
        {
            s_Phase = 2;
            SceneUtils.LoadScene("ManageFarm");  // reload
        }

        public static void AdvanceToPhaseThree()
        {
            s_Phase = 3;
            s_Player.Land.ResetIrrigation();
            s_Player.Land.ClearPlots();  // any hyc seeds/fertilizer that you didn't harvest get wasted

            // Remove all hired workers
            s_Player.RemoveLabour();

            if (s_Player.Wheat < 0)
            {
                PopupManager.QueuePopup("Notice", "You need to buy wheat to feed your family! If you don't buy enough by the end of this year, some of your family will starve!", "Oh no!");
            }

            SceneUtils.LoadScene("Market");
        }

        // For the results screen to report your final results at end of game
        public static Dictionary<string, int> ResultReport()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            //ending year
            results["end-of-year"] = s_Year;
            //starting savings
            results["starting-savings"] = StartMoney;
            //starting acres of land
            results["starting-acres-of-land"] = _startingAcresOfLand;
            //tubewell
            results["tubewell"] = 0;
            if (s_Player != null)
            {
                results["tubewell"] = s_Player.Inventory.GetAmount("Tubewell");
            }
            //ox
            results["ox"] = 0;
            if (s_Player != null)
            {
                results["ox"] += s_Player.Inventory.GetAmount("Ox");
                for (int i = 0; i < s_Player.Family.Adults.Count; i++)
                {
                    if (s_Player.Family.Adults[i].HasOx)
                    {
                        results["ox"]++;
                    }
                }
            }
            //acres of land
            results["acres-of-land"] = 0;
            if (s_Player != null)
            {
                results["acres-of-land"] = s_Player.Land.Plots.Count;
            }
            //total savings
            results["total-savings"] = 0;
            if (s_Player != null)
            {
                results["total-savings"] = s_Player.Money;
            }
            //total assets
            results["total-assets"] = 1000 * results["tubewell"] + 1000 * results["ox"] + 300 * results["acres-of-land"] + results["total-savings"];
            //staring assets
            results["starting-assets"] = results["starting-savings"] + 300 * results["starting-acres-of-land"];
            //total earnings
            results["total-earnings"] = results["total-assets"] - results["starting-assets"];
            //adults number
            results["adults-number"] = 0;
            if (s_Player != null)
            {
                results["adults-number"] = s_Player.Family.Adults.Count;
            }
            results["adults-number"] = 0;
            //children number
            results["children-number"] = 0;
            if (s_Player != null)
            {
                results["children-number"] = s_Player.Family.Children.Count;
            }

            return results;
        }
    }
}
