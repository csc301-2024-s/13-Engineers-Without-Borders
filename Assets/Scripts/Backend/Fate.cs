/*
 * Original Author: Arick Liu
 * This class represents a fate event which happens every year
 */
using UnityEngine;

namespace Backend
{
    public static class Fate
    {
        private static System.Random _random = new();

        public static void TriggerYearlyEvents()
        {
            DetermineFamilyEvent(GameState.s_Player);
            DetermineVillageEvent();
        }

        private static void DetermineVillageEvent()
        {
            int villageEventOutcome = _random.Next(1, 7);

            switch (villageEventOutcome)
            {
                case 1:
                    PopupManager.QueuePopup("Village Event", "A Relief Organization is working in your community. Oxen are half price this year!", "Hooray!");
                    // Update ox prices in the market
                    Market.SetPriceMultiplier("Ox", 0.5f);
                    break;
                case 2:
                    PopupManager.QueuePopup("Village Event", "A Relief Organization is working in your community. Tubewells are half price this year!", "Hooray!");
                    // Update tubewell prices in the market
                    Market.SetPriceMultiplier("Tubewell", 0.5f);
                    break;
                case 3:
                    PopupManager.QueuePopup("Village Event", "HYC seeds are sold out this year!", "Oh no!");
                    Market.DeactivateProduct("HYC Seed");
                    break;
                default:
                    Debug.Log("No village event this year");
                    break;
            }
        }

        private static void DetermineFamilyEvent(Household household)
        {
            int familyEventOutcome = _random.Next(1, 7);

            switch (familyEventOutcome)
            {
                case 1:
                    PopupManager.QueuePopup("Family Event", "Pest attack! You will lose half your crops this year!", "Oh no!");
                    GameState.s_Player.Land.SetYieldMultiplier(0.5f);
                    break;
                case 3:
                    PopupManager.QueuePopup("Family Event", "Your family has a new child!", "Okay!");
                    household.Family.CreateChild(0);
                    break;
                default:
                    Debug.Log("No family event this year");
                    break;
            }
        }
    }
}