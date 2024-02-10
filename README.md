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

Then, just open up the project in Unity, like any other normal Unity project.

UML diagrams can be edited using Violet UML Editor (https://sourceforge.net/projects/violet/).
 
## Deployment and Github Workflow
Deployment is TBD. Maybe we'll set up an auto-building feature, or maybe not.

Most of our communication is done on our Discord server. Ideally, we communicate what classes we're writing. If we're making a small bug fix or writing a new class, we can just push directly to main without causing issues. If it's a huge refactoring or another big change, we'll create a branch for it, and the writer of it will create a pull request. TBD reviews it and merges it.

Access our Trello here: https://trello.com/b/YwVbyUKp/green-revolution  (you may need to request permission).

 ## Coding Standards and Guidelines
Since we're using Unity, we'll be using C# naming and style conventions: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

In particular:
- Properties are upper case
- Static variables are prefixed with s_
- Private variables are prefixed with _
- Pascal case basically everywhere
- Allman bracketting style:
    ```
    if ()
    {
        ...
    }
    ```
​
 ## Licenses 
Just a normal open source license, I guess. Will need to research what the formal term is.
