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
    - Start of season - Random weather quality, village events
    - Harvest season - See how much wheat your family consumes, and how much wheat your farm produces
    - Shop season - Buy seeds, fertilizer, oxen, and other technology to help your farm
- Includes self assessment of what you learned after the simulation
​
## Instructions
Final project is an iOS/Android app, so you'll either need an emulator or a phone. We'll probably make a Windows build as well to make testing easier.

As for the features described above, it's quite self-explanatory. When you start the app there will be a button to learn about the Green Revolution before starting the simulation. The simulation itself will have a tutorial, so just follow that and you'll be good. The self assessment comes after it (or it can also be skipped).
 
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

Then, just open up the project in Unity, like any other normal Unity project. The project is optimized for a 9:16 viewport ratio, so be sure to set that as your
viewport's ratio when testing.

It is recommended to edit scripts by clicking on them in the Unity editor, as that will give you the appropriate intellisense (assuming you've set that up correctly; https://code.visualstudio.com/docs/other/unity ).

UML diagrams can be viewed in the browser, and edited using Violet UML Editor (https://sourceforge.net/projects/violet/).
 
## Deployment and Github Workflow
Deployment is TBD. Maybe we'll set up an auto-building feature, or maybe not.

Most of our communication is done on our Discord server. Ideally, we communicate what classes we're writing. If we're making a small bug fix, we can just push directly to main. If it's a big change, like writing new classes, we'll create a branch for it, and the writer of it will create a pull request. Team lead reviews it and merges it.

Access our Trello here: https://trello.com/b/YwVbyUKp/green-revolution  (you may need to request permission).

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
Just a normal open source license, I guess. Will need to research what the formal term is.
