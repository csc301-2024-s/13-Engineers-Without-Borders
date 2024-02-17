2. Sub-Team Report
Each sub-team will submit the following in their respective branch and organize them in a
readable way. Place the file such as “deliverables/D2/sub-team-X_report.md” following a
structure similar to D1.
1. A summary of your decisions and the options you considered for your component(s)
(UI/frontend, logic/backend, database) so your TA knows what you have built and why.
(Soft limit of 600 words. This doesn’t mean you have to write 600 words. Quality is
more important than quantity).

Backend:
For this deliverable, we implemented the backend files corresponding to phase 2 of the game. This includes the files FarmLand.cs, FarmPlot.cs, FertilizerTypes.cs, YieldPerformanceTable.cs as well as unit tests for Farmland, FarmPlot, and YieldPerformanceTable. For Farmplot, we decided to make the methods for getting/updating the seed type, fertilizer type, and the assigned worker as properties to make them more concise. The Yield Performance table is a static dictionary to make looking up wheat yield based on weather, fertilizer type and seed type more efficient. The fertilizer types are contained in an enum to make sure these values stay consistent across all files. We realized that seedtype should also be an enum but we decided to leave that for D3 to prevent any last minute confusion. 


Front end:
Currently the UI (The “Harvest” scene) displays the current weather level, the price of wheat, and the number of family members the player has. There is a button, “Show Yield Table”, which allows the user to open and close an image of the Yield Table, which is the table used for calculating wheat yield based on weather and fertilizer. This is included so the player knows how much wheat they should receive. There is a total wheat count that corresponds to the total amount of wheat the player has, which can be a negative value. We decided there should be some interactivity in this phase, but we also needed to prevent the user from missing out on collecting some wheat, so we added the “collect all” button, which is only clickable once to prevent the user from collecting multiple times. After clicking, the “next” button appears, which in the actual game would send the player to phase 3 of the game. The yellow square in the middle is meant to represent a wheat field. In the future we will make this more dynamic so that the actual number of farm plots is displayed with fertilizer values for each. Once harvested, the wheat field turns brown to represent a harvested field. In the actual game, the weather, price of wheat, and family members would be generated in phase 1 of the game. Currently, however, the UI is preset with values of 3 for the weather, 10 for the wheat price, 4 for family members, which can be found in the GameStateInitializer File in the Components folder. To make it simpler, the preset has 5 farm plots, all with assigned workers so that wheat can actually be collected.



2. Individual contributions explaining who did what. You can keep it to at most one
paragraph per person to highlight any work that is not captured in any of the repos.

Jacqueline:
- Implemented FarmPlot.cs
- Implemented the UI, which includes the files CloseYieldTable, CollectAllWheat, DisplayTotalWheat, DisplayWeather, ShowFamilyMembers ShowWheatPrice, ShowYieldTable in - the Components folder
- Wrote the subteam report and readme file

Bill:
- implemented Farmland.cs, FertilizerTypes.cs, YieldPerformanceTable.cs
- implemented GameStateInitializer.cs
- contributed to Household.cs, Gamestate.cs
- added unit tests for Farmland, FarmPlot, and YieldPerformanceTable

3. All the details and instructions needed for your TA to see and verify your work. You need
to provide enough documentation so your TA can confirm:
a. Your software does what you say it does.
b. You've done the work (i.e., it's something on your repo/servers, etc.).

Check Github under Assets/Backend folder to see the corresponding backend files, and check Assets/Components to see the corresponding UI files. To run the application, check the READ ME and the D2/Builds folder.

