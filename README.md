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
Final project is an iOS/Android app, so you'll either need an emulator or a phone. We are currently working with EWB to make an account to upload the build to. For now, use the Windows executable found in `D4/Build` (you need to download the entire folder). For users, check out the [simulation guide](simulation-guide.md) to understand how the application works.

If you're a contributor, you can read the [technical document](technical-document.md) to learn more about the specifics behind the project, and view our [code documentation](https://csc301-2024-s.github.io/13-Engineers-Without-Borders/api/Global.html). The scrollbar on the left side is a little janky, so here's the link to the [Backend](https://csc301-2024-s.github.io/13-Engineers-Without-Borders/api/Backend.html) namespace documentation.

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
Deployment Usage: **download** the folder `deliverables/D4/Build` and run `Green Revolution.exe`.

Communication is done on our Discord server. We say what we're writing and how we're going to merge it (either directly or through a pull request). We honestly aren't very strict about this - as long as it gets the work done. As a rule of thumb, if we're making a small bug fix, we can just push directly to main. If it's a big change, like writing new classes, we'll create a branch for it, and the writer of it will create a pull request. Team lead reviews it and merges it.

Access our Trello here: https://trello.com/b/YwVbyUKp/green-revolution  (you may need to request permission).

We TRIED to get a [workflow](https://github.com/marketplace/actions/unity-test-runner) working to automatically test our test suite, but we just couldn't get it to work. Also I think it's actually faster to run the tests in the Unity editor anyway, so there really wasn't much of a point to a workflow.

Luckily we got a workflow working to auto-generate code documentation using docfx.

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

**Always use `//` for comments**, and use `///` for XML comments. Public variables/methods should be documented with XML comments so they'll appear on our auto-generated documentation. (Bonus points if your IDE automatically creates a template for you when you type `///`.)
​
## Licenses 
We went with the MIT license as that is what our partners went with for their previous project, Water for the World.
