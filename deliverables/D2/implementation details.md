<By Andy Wang>

# Notes
- Excluding labour trading and irrigation for now

# SIMULATION START
- Initialize `GameState` with player(s) in `GameState.Initialize`
    - Create `Household` object for main player
        - Create a selection GUI for the player to select their household
    - Households are chosen from `Household.s_Households`, a dictionary of pre-made households
        - The way these are stored is up to you, could be delegated to its own file, or loaded from JSON
        - Make these according to WorkshopSheets/Household Cards.pdf
        - Family members should be created with random first name (list of names could be a hardcoded array), and have family's last name
        - Household `FarmPlot`s should all be initialized to have no HYC seeds and no fertilizer
            - Assign workers to `FarmPlot`s automatically using `Household`'s adults, with a ratio of one adult to two plots -- if there are any plots remaining with no workers, leave them be
        - Household `Inventory` should be empty
    - (Later on, not for this deliverable) create more `Household` objects for AI (different from Player-chosen one)
    - Set to appropriate `GameState` static variables
    - Initialize year and phase to 1 and 0, respectively
    - **This part is done by the Phase 1 sub-team**

# PHASE 1
- Increment phase and year appropriately
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
- Calculate total consumption for the player's `Family`
    - Child/adult consumption are constants in `FamilyMember`
- Calculate remaining wheat yield
- Calculate total wheat sold (for now, this is total income)
- Create a GUI to show relevant information to the player
    - Show # of family members, weather index, wheat price
    - Corresponding to the "Harvest season" section in WorkshopSheets/Spreadsheet.jpg, but without labour/land sales
    - Must have a next button to Phase 3

**For D2**
- Since builds are isolated from each other, the player won't choose their own household. Instead choose a random one and use `GameState.Initialize` with it
    - **In the final product**, this phase should use existing `GameState` values instead of re-initializing
- Only for this deliverable, there should be a GUI to freely choose which plots of land are LR (native) or HYC
    - Also choose which adults are assigned to which plots
    - Mainly for testing purposes so the TA can play around with it
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
- Should have a button somewhere to advance to next year, Phase 1

**For D2**
- Since builds are isolated from each other, the player won't choose their own household. Instead choose a random one and use `GameState.Initialize` with it
    - **In the final product**, this phase should use existing `GameState` values instead of re-initializing
    - Initialize with a lot more money than normal
- This should be implemented in two Unity scenes: one for the shop GUI, another for the plot management GUI

