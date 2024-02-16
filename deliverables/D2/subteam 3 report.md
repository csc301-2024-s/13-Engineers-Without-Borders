## SUMMARY
We were in charge of Phase 3, where the majority of the player's interactions and choices happen. Naturally, this would mean less backend scripting and more of a focus on gameplay scripting, and making sure the GUI worked.

As expected, we had the least amount of backend classes assigned to us (`Inventory.cs`, `Market.cs`, and `GameState.AdvanceToPhaseThree`). However, we made up for it with our more complex shop and farm management GUI.

It's true that making GUI in Unity isn't done with code; it's just drag-and-drop stuff in the Unity Editor instead of writing, for example, JavaScript code with React. However, there is still a lot of code to make this GUI actually do stuff, and to programmatically modify the GUI to show the player's items.

For example, we needed to write a component for the buy buttons to interface with the Market class, and to show success or error messages when you can't buy a certain item. We also had to make sure the prices displayed were accurate, since they could be changed by village events. In the farm management scene, we needed to interface with the backend to display the player's inventory, and we needed to write the logic to allow the player to customize their farm.

We also had a lot of trouble setting up a tool to help us with builds. Turns out Unity's Build Automation tool on the cloud goes by a "pay what you use" model
which I (our team lead) really didn't want to bother with. We found [this tool](https://github.com/superunitybuild/buildtool) which was free, but couldn't figure out how to install it properly. It kept giving a "could not load icon" error which prevented it from working. So in the end we just had to stick with manually exporting our project as Android and Windows.

**CODE CREDIT DISCLAIMER:**
Not every backend script was written by this subteam. Look at [`implementation details`](implementation%20details.md) and the [`project report`](project%20report.md) for the full breakdown of backend scripts. Individual authors for each script should be commented in each script as well.

## CONTRIBUTIONS
Andy Wang:
- Wrote first draft of main project report
- Wrote first draft of this report
- Wrote Inventory.cs and corresponding unit tests
- Contributed to `GameState.AdvanceToPhaseThree`
- Wrote `GameStateInitializer.cs`, `PlayerMoneyDisplayer.cs`, `PlayerWheatDisplayer.cs`
- Made the shop UI in the Market scene (`Assets/Scenes/Market.unity`)
- Started on Farm Management scene (`Assets/Scenes/Manage Farm.unity`)

Kevin: