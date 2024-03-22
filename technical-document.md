# GREEN REVOLUTION TECHNICAL DOCUMENT

Here you will find instructions and details about code and project structure. This assumes you have working knowledge of Unity and (possible) Unity's UI Builder.

## Project Structure
It's mostly a standard Unity project. There's standard stuff like an Assets folder containing Prefabs, Scenes, and Scripts.

There are two types of scenes: non-simulation and simulation. It's rather self-explanatory what these mean. Note that these scenes are all lumped together in the Scenes folder, because it would be complicated in terms of scene loading if we separated them into different folders.

The simulation scenes are:
- HouseholdSelection
- ManageFarm
- ManageHousehold
- ManageFamily
- ViewInventory
- Market
And the non-simulation screens are the rest of them (surprise!). If you want to start testing the simulation, you can play starting with the HouseholdSelection scene. If you want to playtest the entire app, you should start with the Welcome scene.

### Non-simulation Scenes
These are not built with Unity UI but rather UI Documents. These work similarly to HTML/CSS, but catered for Unity projects. In these scenes you'll find a UIDocument game object which contains the UI. The UI source assets are in `Assets/Screen UI` (note that there are some scripts here. We put those there because they are used exclusively to program this UI).

You'll notice that some scenes have a PopupOnDefault game object, these make it so a popup appears as soon as you enter the scene. In all non-simulation scenes the UIDocument has a "UI Document Load Scene Button" component which makes it so buttons (of class ".load-scene-button") load another scene on click, the name of which is their Tooltip.

The Results scene DOES, however, contain some Unity UI. This is because this scene uses the same popup system as the simulation screens (which is different from the system used by the non-simulation screens).

### Scripts
Within the Scripts folder there's a Backend folder and a Components folder, as long with an assembly definition. The assembly definition is so that we could use Unity's testing framework, the unit tests of which can be found in `Assets/Tests`.

The term "Backend" is used loosely here, it's more or less all the classes that don't inherit from MonoBehaviour, and "Components" are all the classes that do.

### Testing
As mentioned previously we do have unit tests. In the Unity editor, go to Window > General > Test Runner and you should be able to run our tests there. Double click on a test suite's name to run it, or double click on "Tests.dll" to run multiple test suites at once.
![test runner](DocumentImages/test-runner.png)