# GREEN REVOLUTION - Made by Mr Cyborg
​
## Partner Intro
Fidel Labit from Engineers Without Borders. Primary contact. Email: topro.learn@chapter.ewb.ca

Engineers Without Borders is an organization dedicated to educating students about international equity issues. They are running a workshop on the "Green Revolution", focusing on global food supply and production, as well as the role technology (new or old) plays in it.

## Description about the project
A mobile game where you play as a farmer trying to grow as much wheat and gain as much profit as you can. It has an educational aspect to it, and educates players on issues surrounding global food production and the role of technology in farming.
​
## Key Features
- Includes teaching information about the pros and cons of the Green Revolution
- Includes simulation of being a farmer
    - Specifically a Punjabi farmer
    - Start of season - Random weather quality, village events, irrigation (if you have a tubewell)
    - Harvest season - See how much wheat your family consumes, and how much wheat your farm produces
    - Shop season - Buy seeds, fertilizer, oxen, and other technology to help your farm, and plant them
- Includes reflection questions of what you learned after the simulation
​
## Instructions
Final project is an iOS/Android app, so you'll either need an emulator or a phone. We'll make a Windows build as well for convenience.

When you open the app, you'll be greeted with the home screen. You'll have the option to skip the simulation, or continue on with the educational stuff.

The educational stuff is the just information about the Green Revolution and its pros and cons. Simply click the next/back buttons to proceed.

Eventually you will reach the simulation. There will be a screen where you can select which household you want to play as, each with a different number of adults, children, and plots of land. When you click, you will be brought to the farm management screen - in the upper left corner you can see the current weather index, year, and phase. In the lower left corner there is a button that will display information about your household. In the lower middle there is a button to progress to the next phase. In the lower right corner there is a button to take you to the market, which should only be visible during phase 3. In the upper right corner of phases 1 and 2, you can see your total "labour value." Every adult by default contributes two labour points, but contributes four if they are assigned an ox. Near the top right is an information button which you can press to read about how to play the current phase.

### Household Screen
When you click the lower left button you will be taken to a screen where you can view your adults, children, inventory, and land (which takes you back to the farm management screen). In the adults section it lists all your adults (and hired labour, which last for one year), and there are buttons for you to assign oxen to them (if you have any). In the children section it lists all your children, as well as how many years until they become adults. In the inventory you can see how many of every item you own (except land and labour, which can be seen in farm management and the adult list respectively).

### Phase 1
In year 1, there is nothing for you to do in this phase, so it automatically skips to phase 2.

At the start of years 2+, there may be random events - if there is one, a popup will be shown. Events include making certain market items unavailable or changing their price, or adding a child to your family.

In phase 1 you irrigate your crops. You can irrigate up to 8 plots of land per tubewell owned. Of course, this means you can't irrigate any land if you don't have tubewells - you will receive a popup to prompt to skip to phase 2 if this is the case. Irrigating one plot of land costs two labour points.

### Phase 2
In this phase you select which plots of land you want to harvest. Every plot costs one labour point. The yield amount of each plot of land depends on what type of seed and fertilizer it has, as well as the weather and whether it's irrigated or not. The entire table of values can be found in `Assets/Backend/YieldPerformanceTable.cs` but the gist of it is:
- Low/high fertilizer increases yield by a low/high amount respectively
- Lower weather index = better yield, higher weather index = worse yield
- HYC seeds perform better than regular seeds in good weather, but worse in worse weather
- If a plot of land is irrigated, it uses the best weather index (1) to calculate its yield

### Phase 3
In this phase you start in the market. Here you can buy items and sell wheat (by the tens or by the hundreds. Wheat sell price is the same as the buy price). Their descriptions as shown in the market should be explanatory enough. In the top right corner you should see your money and wheat.

Some items have purchase limits:
- You can only buy as many oxen as adults in your family
- You can only own a maximum of 16 plots of land
- You can only own a maximum of two tubewells

At the bottom of the market screen is a button that takes you back to the farm management screen, this time with three extra toggles at the bottom for planting. Yes, phase 3 is the planting phase. If you toggle the HYC Seed option, you can select plots of land to plant HYC seeds on them. It's a similar deal for the low/high fertilizer options.

To remove HYC seed or fertilizer from a plot of land, simply select it with the proper toggle enabled.


After the simulation (after the harvest on the 7th year), there will be a results screen to show your final score. This is followed by some self reflection questions to see how much you've learned.

If you're a contributor, you can read the [technical document](technical-document.md) to learn more about the specifics behind the project, and view our [code documentation](https://csc301-2024-s.github.io/13-Engineers-Without-Borders/api/Global.html).

You can view/download our demo [here](deliverables/D4/demo-video.mp4).
 
## Development requirements
We are using the Unity Engine, LTS version 2022.3.18f1. Your local git branch should be configured to use Unity YAML merge.

Add this to your local git config file:
```
[merge]
    tool = unityyamlmerge
[mergetool "unityyamlmerge"]
    trustExitCode = false
    cmd = "PUT PATH TO UnityYAMLMerge.exe HERE" merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

On Windows at least, the path to the tool is `C:/Program Files/Unity/Hub/Editor/2022.3.18f1/Editor/Data/Tools/UnityYAMLMerge.exe`

Then, just open up the project in Unity, like any other normal Unity project. The project is optimized for a 9:20 viewport ratio, so be sure to set that as your
viewport's ratio when testing.

It is recommended to edit scripts by clicking on them in the Unity editor, as that will give you the appropriate intellisense (assuming you've set that up correctly; https://code.visualstudio.com/docs/other/unity ).

UML diagrams can be viewed in the browser, and edited using Violet UML Editor (https://sourceforge.net/projects/violet/).
 
## Deployment and Github Workflow
Deployment Usage: navigate to D4/Build and run [Green Revolution.exe](deliverables/D4/Build/Green%20Revolution.exe)

Communication is done on our Discord server. We say what we're writing and how we're going to merge it (either directly or through a pull request). We honestly aren't very strict about this - as long as it gets the work done. As a rule of thumb, if we're making a small bug fix, we can just push directly to main. If it's a big change, like writing new classes, we'll create a branch for it, and the writer of it will create a pull request. Team lead reviews it and merges it.

Access our Trello here: https://trello.com/b/YwVbyUKp/green-revolution  (you may need to request permission).

We TRIED to get a [workflow](https://github.com/marketplace/actions/unity-test-runner) working to automatically test our test suite, but we just couldn't get it to work. Also I think it's actually faster to run the tests in the Unity editor anyway, so there really wasn't much of a point to a workflow.

## Coding Standards and Guidelines
We will be adapting https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions .

But we will use our own naming conventions:
- Static variables are prefixed with s_
    - Constants are already static but DO NOT take the s_ prefix
- Private variables are prefixed with _ and are **camel case**
    - Private static variables use this rule instead of s_
- Pascal case for properties and methods
- Public variables are camel case, but they should really be properties instead
    - Exception is public variables in custom components

And we will ignore the note about four spaces instead of tabs.

As for comments, every class and method should be documented. Classes should have authors, and methods should have comments explaining their parameters and return values. These don't need to be in a specific format, as long as they explain the information.

**Always use `//` for comments**
​
## Licenses 
"You can upload the code to GitHub or other similar publicly available domains."

This is the Intellectual Property Confidentiality Agreement our partner agreed to.

As for code usage, please do not fork this project or reuse it until the term ends.
