<By Andy Wang>

# Notes
- Excluding labour and irrigation for now, for simplicity. But do keep in mind how you could easily extend the scripts to include it.
- The scripts described below should go in *Assets/Backend*, and are *SHARED* among subteam branches.
- Assets/Components is for scripts that you write that get dragged and dropped onto Unity game objects. These can be individual among sub teams, or shared.
- For the purpose of this, "Backend" scripts refer to those in the UML diagram, that aren't dragged and dropped into Unity game objects. **These must go into Assets/Backend.** These are shared among all subteams for convenience.
- **The implementations of the GameState.Advance functions** are what differs between each sub team's branch (as well as some Unity scenes/Component scripts).
- When writing backend scripts and you have to refer to a type that hasn't been written yet, just ignore any errors your IDE might throw at you.

# SIMULATION START
- Initialize `GameState` with player(s) in `GameState.Initialize`
    - Create `Household` object for main player
        - Create a selection GUI for the player to select their household
    - Households are chosen from `Household.s_Households`, a dictionary of pre-made households
        - The way these are stored is up to you, could be delegated to its own file, or loaded from JSON
        - Make these according to WorkshopSheets/Household Cards.pdf
        - Family members should be created with random first name (list of names could be a hardcoded array), and have family's last name
            - Children have a random age below 12
        - Household `FarmPlot`s should all be initialized to have no HYC seeds and no fertilizer
            - Assign workers to `FarmPlot`s automatically using `Household`'s adults, with a ratio of one adult to two plots -- if there are any plots remaining with no workers, leave them be
        - Household `Inventory` should be empty
    - (Later on, not for this deliverable) create more `Household` objects for AI (different from Player-chosen one)
    - Set to appropriate `GameState` static variables
    - Initialize year and phase to 1 and 0, respectively
    - **This part is done by the Phase 1 sub-team**

# PHASE 1
- Increment phase and year appropriately
    - **On a new year (2+), increment the ages of every child in the game's data**. When they reach an age of 12, remove them from `Family.Children` and use their `ToAdult` method to convert them to an adult, and add it to `Family.Adults`
    - Don't worry about ages of adults (for now, at least)
- Set `GameState.s_WeatherIndex` to a random integer between 1 and 5
- Set wheat price to random integer between 1 and 10
    - Tentativey, prices are stored in dictionary `Market.s_Prices`
- (Year 2+ only) Choose random village event and household event for each household
    - Read WorkshopSheets/Fate Seeds and Tools Cards.pdf
    - These can be implemented however you think makes sense; make sure it's scalable (easy to add new events), can affect GameState and other important variables, and Household events should be able to affect specific households
    - Possible for there to be no village event, or for a household to have no event
- The above should be done in `GameState.AdvanceToPhaseOne`
- Create a GUI to show relevant information to the player
    - Corresponding to the "Start of Year" section in WorkshopSheets/Spreadsheet.jpg
    - Must have a next button to Phase 2

**Backend Scripts**
- GameState (all except AdvanceToPhaseTwo/Three)
- Fate (not specified in UML diagram)
- Household
- Family
- FamilyMember (including Children and Adult)

**For D2**
- Since builds are isolated from each other, the next button won't actually do anything
- Instead, make this button go back to the selection GUI
- This should be implemented in two Unity scenes: one for `Household` selection, another for the Phase 1 GUI

# PHASE 2
- Calculate total wheat yield
    - Use the player's `Farmland` class and create the `YieldPerformanceTable`
    - `YieldPerformanceTable._yield`'s first dimension is weather index
    - `YieldPerformanceTable._yield`'s second dimension is fertilizer
    - `YieldPerformanceTable._yield`'s third dimension is type of seed (0 = native, 1 = HYC)
    - `YieldPerformanceTable._yield` should have shape (5, 3, 2)
    - If a plot has no worker, it gets no yield
    - **In the final game, the player should be able to tap on farm plots to collect the yield.** This doesn't need to be implemented now, but keep this in mind.
- Calculate total consumption for the player's `Family`
    - Child/adult consumption are constants in `FamilyMember`
- Calculate remaining wheat yield
- Calculate total wheat sold (for now, this is total income)
- Create a GUI to show relevant information to the player
    - Show # of family members, weather index, wheat price
    - Corresponding to the "Harvest season" section in WorkshopSheets/Spreadsheet.jpg, but without labour/land sales
    - Create a button to show the YieldPerformanceTable
    - Must have a next button to Phase 3

**Backend Scripts**
- GameState.AdvanceToPhaseTwo
- Farmland
- FarmPlot
- FertilizerType (note that this is an **enum**)
- YieldPerformanceTable

**For D2**
- Since builds are isolated from each other, the player won't choose their own household. Instead choose a random one and use `GameState.Initialize` with it
    - **In the final product**, this phase should use existing `GameState` values instead of re-initializing
- Only for this deliverable, there should be a GUI to freely choose which plots of land are LR (native) or HYC
    - Also choose which adults are assigned to which plots
    - Mainly for testing purposes so the TA can play around with it
    - **This will most likely be a placeholder solely for testing**, so don't put too much work into making it look pretty
- This should be implemented in two Unity scenes: one for the plot GUI, another for the Phase 2 GUI

# PHASE 3
- Create a shop GUI where the player can buy stuff
    - HYC seeds
    - Fertilizer (low or high)
    - Ox
        - Maximum amount is # of adults in your family
    - Extra land
    - **Village events may affect prices/availability**, so however you store shop items should allow this and be scalable (easy to add new shop items)
        - This may require communication with sub-team 1, who is assigned to making fate events
- Each item should have a description of its effect and have a buy button
    - On buy, the transaction is complete if purchase function succeeds, otherwise display error message
    - When successfully bought, add the item to the buyer's inventory
- Create a Farmland management GUI
    - Can place down HYC seeds/fertilizer in specific plots
    - Can manage which plots adults work on
        - Can give an ox to adults working on a plot
        - When an adult with an ox is removed from work, place the ox back in your inventory
    - Can also rescind these items to put them back in inventory
    - Newly bought plots of land should appear here
    - Obviously, increment/decrement inventory amount of items as necessary
    - **This will likely be the building blocks for the final product's main HUD**
- Should have a button somewhere to advance to next year, Phase 1

**Backend Scripts**
- GameState.AdvanceToPhaseThree
    - Now that I think about it, this is the simplest advance function of the three. It's basically just enabling the shop GUI.
- Market
- Inventory

**For D2**
- Since builds are isolated from each other, the player won't choose their own household. Instead choose a random one and use `GameState.Initialize` with it
    - **In the final product**, this phase should use existing `GameState` values instead of re-initializing
    - Initialize with a lot more money than normal
- I'd expect this phase to use a lot more custom Components than Backend stuff
- This should be implemented in two Unity scenes: one for the shop GUI, another for the plot management GUI

