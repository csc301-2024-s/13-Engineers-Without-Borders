We are responsible for implementing and testing the logic for Phase 1 as well as Game Initialization. Our part contains a lot of backend scripts with two scenes for the frontend

Backend: In D2, we have implemented the required backend scripts for phase 1 and to initialize the game. This includes Family.cs, FamilyMember.cs, Adult.cs, Child.cs, Household.cs and GameState.cs. Also, we have made the unit tests for creating and interacting with Family and FamilyMember classes. In fact, FamilyMember is a parent class with two children: Adult and Child. This is because we realized that Children and Adult share some attributes and functionalities but they still have different roles in the game. For example, a Child object has an age attribute, which increments every year. If a child reaches 12, a new adult object inheriting the child's information is created. Although adults' age is not important in the gameplay, they have a MaxAssignedPlot attribute to keep track of the amount of farm plots that they are working on. Also, there is a hasOx boolean attribute, which helps determine whether to increase the MaxAssignedPlot of an Adult. Family is a class that contains two seperate lists representing adults and children of a family. When initialized, this class will creates all the Adults and Children in one Family. Household object has a family attributes containing a family, a Farmland atrribute to keep track of the plots that the family owns and an Inventory to store all the purchases. Finally, the GameState.cs where all the subteams implement the logic to advance the game to their phase. There is an Initialize method that will be used to start the game. 

Frontend: Our first scence, Household Selection is where the players can choose the household that represent them. In the middle of the GUI, there are the name of the household alongside with the amount of adults, children and number of farm plots that the family own. The "Next" and "Back" button are used to change the household based on the player's preference. After choosing, players can click on the "Play" button at the bottom of the screen to call the GameState.Initialize method that will start the game. Next, a new scence that displays the player's information will appear.

Individual Contribution.

Hoa:
- Implemented Family.cs, FamilyMember.cs, Adult.cs, Child.cs, Household.cs and contributed to GameState.cs
- Added unit tests for the methods for Family, FamilyMember, Adult and Child.
- Designed the Household Selection scence
- Wrote the subteam report
