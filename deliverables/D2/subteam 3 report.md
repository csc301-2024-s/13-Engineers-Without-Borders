## SUMMARY
We were in charge of Phase 3, where the majority of the player's interactions and choices happen. Naturally, this would mean less backend scripting and more of a focus on gameplay scripting, and making sure the GUI worked.

As expected, we had the least amount of backend classes assigned to us (`Inventory.cs`, `Market.cs`, and `GameState.AdvanceToPhaseThree`). However, we made up for it with our more complex shop and farm management GUI.

It's true that making GUI in Unity isn't done with code; it's just drag-and-drop stuff in the Unity Editor instead of writing, for example, JavaScript code with React. However, there is still a lot of code to make this GUI actually do stuff, and to programmatically modify the GUI to show the player's items.

For example, we needed to write a component for the buy buttons to interface with the Market class, and to show success or error messages when you can't buy a certain item. We also had to make sure the prices displayed were accurate, since they could be changed by village events. In the farm management scene, we needed to interface with the backend to display the player's inventory, and we needed to write the logic to allow the player to customize their farm.

## RCONTRIBUTIONS
Andy Wang:
- Wrote first draft of main project report
- Wrote first draft of this report
- Wrote Inventory.cs and corresponding unit tests
- Made the shop UI in the Market scene (`Assets/Scenes/Market.unity`)