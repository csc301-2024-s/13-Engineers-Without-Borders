# Project Report

## Software Summary
Our partner, Engineers Without Borders, is a non-profit organization dedicated to education about global equity issues. They run a workshop about the Green Revolution, which features an in-person activity where teams simulate being farmers in underdeveloped countries. This software aims to digitize this workshop.

Green Revolution is an iOS/Android game exploring issues around global food production and supply, developed in partnership with Engineers Without Borders. In the game, the player takes on the role of a farmer who must make choices that affect wheat production using new and existing technology. External factors such as weather and village events will also affect the player's harvest. The player will also be able to budget their spending and buy tools and new plots of land.

At the start of the game, the player chooses a household with a set family, farmland, and starting money. The game runs in three phases:
- The beginning of the year, where weather and events are decided
- Harvest season, where you harvest your wheat yield and sell it
- Buying season, where you visit the market to buy seeds (native or HYC), fertilizer, and other technology

## Project Division
Unlike other projects, which are websites or mobile apps, this is a mobile *game*. And furthermore, instead of being coded with a framework like React, it was made with the Unity game engine. This made it tricky to divide the project, as it's not as simple as "frontend vs. backend."

If you take a look at our mockup flowcharts, you'll see that the simulation is only one screen out of many. The other screens relate to information about the Green Revolution and the self assessment. One way we could have split our project was to have one group do the Green Revolution scenes, another the self assessment, and another the simulation. However, the simulation takes up the vast majority of the actual coding, so this wouldn't be a fair division.

Let's focus on just the simulation, then. Another way to split it up is to have one team do the full UI, and two on the backend. This could have worked, but the backend teams would have needed to create UI for their own builds, which seemed a bit unnecessary since another team would be making the full UI anyway. And even if they shared the full UI, that would have defeated the point of the next deliverable, which will be to put everything together.

We ultimately decided to split our teams based on the three phases, since each phase has a specific gameplay/business logic associated with it (see `Assets/Backend/GameState.cs`). **Each subteam is responsible for their corresponding AdvanceToPhase method**, and their individual builds focus on their assigned phase. The backend was also partitioned roughly based on relevance to each phase. For convenience, we decided that **every backend script be pooled in `Assets/Backend` in the main branch**, since it just didn't make sense to isolate them from each other (of course we will specify which class each subteam wrote as per D2 guidelines). The corresponding tests are in `Assets/Tests`. The individual subteam branches differ in their own builds, and whatever custom components they needed to write for it. This also makes it more straight forward to put everything together in the next deliverable.

## Subteam responsibilities
This is more detailed in `D2/implementation details.md`, but as a quick summary:

**Sub team 1:**
- Phase 1 logic and simulation initialization
- Household choice at beginning

**Sub team 2:**
- Phase 2 logic
- Harvesting crops

**Sub team 3:**
- Phase 3 logic
- Shop UI
- UI to apply tools to your farm