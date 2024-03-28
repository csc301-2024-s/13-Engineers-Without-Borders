using System;
using System.Collections.Generic;
using Random = System.Random;

/*
 * This class represents the States of the game
 */
namespace Backend
{
    /// <summary>
    /// Represents global game state.
    /// </summary>
    public static class GameState
    {
        /// <summary>
        /// Starting money of player.
        /// </summary>
        public const int StartMoney = 500;

        /// <summary>
        /// Game year.
        /// </summary>
        public static int s_Year;

        /// <summary>
        /// Game phase/season. From 1 to 3.
        /// </summary>
        public static int s_Phase;

        /// <summary>
        /// Game weather index. From 1 (best) to 5 (worst).
        /// </summary>
        public static int s_WeatherIndex;

        /// <summary>
        /// The player's household object.
        /// </summary>
        public static Household s_Player;

        /// <summary>
        /// A list of all households in the game. We originally wanted to have AI players which is why this is here, but we didn't end up doing that.
        /// </summary>
        public static Household[] s_Households;

        /// <summary>
        /// Array of predefined households that the player can choose from. Learn from our mistakes and don't do this in your own projects,
        /// load data from a JSON file or something instead.
        /// </summary>
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
        private static bool _phase1TutorialShown = false;

        /// <summary>
        /// Initializes the game, setting year and phase to 0 (this happens before the main gameplay).
        /// </summary>
        /// <param name="Player">The household that the player chose.</param>
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
            _phase1TutorialShown = false;

            Market.Initialize();

            _startingAcresOfLand = Player.Land.Plots.Count;
        }

        /// <summary>
        /// Advance to phase 1, the growing season. (Year 2+ only) Choose random village event and household event for each household, but there might not be one.
        /// Handle starvation and losing condition if player wheat is in the negatives. Automatically loads phase 2 if you don't have any tubewells.
        /// </summary>
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
                PopupManager.QueuePopup("Tutorial", "Welcome to the simulation! Tap on each plot to select it, then press the harvest button below to advance. Each plot costs one labour point to harvest. If you don't have enough labour to harvest all of your land, your remaining crops will be left on the field to rot.", "Okay");
                AdvanceToPhaseTwo();
            }
            else if (!s_Player.Inventory.Contains("Tubewell"))
            {
                PopupManager.QueuePopup("Notice", $"Growing Season skipped due to lack of tubewell.", "Okay");
                AdvanceToPhaseTwo();
            }
            else if (!_phase1TutorialShown)
            {
                _phase1TutorialShown = true;  // show the tutorial promp the first year you get a tubewell
                PopupManager.QueuePopup("Tutorial", "It's Growing Season! Since you have a tubewell, you can irrigate your crops to make sure they yield the most wheat as possible! Each plot costs two labour points to irrigate.", "Okay");
            }
        }

        /// <summary>
        /// Advance to phase 2, the harvest season. Simply sets the phase variable and switches scenes.
        /// </summary>
        public static void AdvanceToPhaseTwo()
        {
            s_Phase = 2;
            SceneUtils.LoadScene("ManageFarm");  // reload
        }

        /// <summary>
        /// Advance to phase 3, the planting season. Any hired labour is removed.
        /// </summary>
        public static void AdvanceToPhaseThree()
        {
            s_Phase = 3;
            s_Player.Land.ResetIrrigation();
            s_Player.Land.ClearPlots();  // any hyc seeds/fertilizer that you didn't harvest get wasted

            // Remove all hired workers
            s_Player.RemoveLabour();

            if (s_Year == 1)
                PopupManager.QueuePopup("Tutorial", "The Market is now open! You can buy or sell tools or make the best out of next year's harvest. You can also select a seed type and fertilizer and apply them to your farm plots.", "Okay");

            if (s_Player.Wheat < 0)
            {
                PopupManager.QueuePopup("Notice", "You need to buy wheat to feed your family! If you don't buy enough by the end of this year, some of your family will starve!", "Oh no!");
            }

            SceneUtils.LoadScene("Market");
        }

        /// <summary>
        /// Helper method to return game data to be displayed in the results screen at the end.
        /// </summary>
        /// <returns>Game data used for results.</returns>
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
