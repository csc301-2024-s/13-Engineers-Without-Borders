# Engineers Without Borders/Mr Cyborg
 > **This document will serve as a master plan between your team, your partner and your TA.**

## Product Details
 
#### Q1: What is the product?
An iOS/Android game exploring issues around global food production and supply, developed in partnership with Engineers Without Borders. In the game, the player takes on the role of a farmer who must make choices that affect food production using new and existing technology. External factors such as weather will also affect the food production's performance. The player will also be able to choose budgets, supplies, and funds in order to see what affect they have on their harvest.

At the start of the game, the player starts off with a randomized family that needs to be taken care of and a set amount of money. The game runs in phases - during each phase, the player makes choices to buy stuff and plant/sell crops. The player can advance to the next phase to see the outcome - how their crops are doing, what the weather is like, and other random events - and continue making decisions. Gameplay-wise it's similar to the mobile game "BitLife".

The MVP will be single player, but there can be other (computer-ran) farmers that you can interact with.

#### Q2: Who are your target users?
Middle, high school, and university students wanting to learn more about global food supply and issues relating to it.

#### Q3: Why would your users choose your product? What are they using today to solve their problem/need?
The traditional way of learning about issues surrounding global food supply and production require research, which is quite boring for middle school users and time consuming for high school/university students. Framing it as a game makes it fun and entertaining, and conveys EWB's vision to engineer a more sustainable future in a more engaging and interactive way. It will also help to reinforce EWB's reputation as one of the top leaders in education about international equity issues.

This product also serves as a digitized version of EWB's "Green Revolution" workshop. Originally it is done in person with different teams, and they'd have to keep track of their money and statistics with a spreadsheet. The product makes this process a lot easier by handling all the calculations and data for you, and also you don't need to meet up with other people in real life. This is a rather important option to give post-pandemic, afterall.

#### Q4: What are the user stories that make up the Minumum Viable Product (MVP)?
1) As a student, I want to simulate budget choices in order to learn about the struggles of farmers in third world countries. AC: Given budget choices, when I choose a budget, then I see what farming tools I can afford.
2) As a student, I want to choose what technology I use in order to learn its benefits/downsides. AC: Given choice of tools/technology, when I choose one, then I see how it affects my crop yield.
3) As a student, I want to experience random climate/weather events in order to learn how weather affects my crops. AC: Given the beginning of the simulation year, when I continue the game, I see what weather event is selected and see how that affects my crops.
4) As a player, I want to replay the game in order to come up with a different strategy. AC: Given the ending of one game, when I see the replay button, I can press it to play again.
5) As a player, I want to get the best score so I can win the game. AC: Given the amount of crops I can grow/sell, when I finish the game, I can see my score in relation to others, if there are any.
![image](https://github.com/csc301-2024-s/deliverable-1-13-mr-cyborg/assets/46545759/9623a1fe-6ec8-4507-9e1d-3575cc322793)


#### Q5: Have you decided on how you will build it? Share what you know now or tell us the options you are considering.
We are planning on using the Unity game engine, so that will involve coding in C#. Unity has an option to export to iOS and Android, so we're planning on using that (and EWB's app/play store account) to deploy the game. Development in Unity is strongly component-based, so patterns such as dependency injection, strategy, and composition will be very useful. We will most likely not use any 3rd party APIs, unless we decide to implement multiplayer later on.

For example, here is a simplified schema for a button in Unity that performs some action when clicked:
![image](https://github.com/csc301-2024-s/deliverable-1-13-mr-cyborg/assets/46545759/66ce9b52-4b63-434d-a239-8c936c6fcc35)

A clickable button should be composed of a Button component (as well as other Unity components which are omitted for sake of discussion). In the editor, there is a field to add callbacks to the Button's clicked event, so the Button can easily be configured to call MyComponent's DoAction method upon click. As an example of dependency injection, notice how MyComponent has a field for AudioClips. In the editor, you can easily drag and drop (or "inject") AudioClips into this field to customize what sound MyComponent should use. The Strategy pattern can be performed similarly, only with custom scripts instead of Unity components.

----
## Intellectual Property Confidentiality Agreement 
**By default, you own any work that you do as part of your coursework.** However, some partners may want you to keep the project confidential after the course is complete. As part of your first deliverable, you should discuss and agree upon an option with your partner. Examples include:
1. You can share the software and the code freely with anyone with or without a license, regardless of domain, for any use.
2. You can upload the code to GitHub or other similar publicly available domains.
3. You will only share the code under an open-source license with the partner but agree to not distribute it in any way to any other entity or individual. 
4. You will share the code under an open-source license and distribute it as you wish but only the partner can access the system deployed during the course.
5. You will only reference the work you did in your resume, interviews, etc. You agree to not share the code or software in any capacity with anyone unless your partner has agreed to it.

**Your partner cannot ask you to sign any legal agreements or documents pertaining to non-disclosure, confidentiality, IP ownership, etc.**

Our partner decided to go with option #2.

----

## Teamwork Details

#### Q6: Have you met with your team?
As an ice breaker, we each sent a fact about ourselves in our Discord group chat.

Facts:
- One of us is a roller coaster enthusiast
- One of us plays League of Legends a lot
- One of us plays Dota a lot

![image](https://github.com/csc301-2024-s/deliverable-1-13-mr-cyborg/assets/46545759/14034455-c4ce-4d27-827f-ee2bda2e73eb)


#### Q7: What are the roles & responsibilities on the team?

Describe the different roles on the team and the responsibilities associated with each role. 
 * Roles should reflect the structure of your team and be appropriate for your project. One person may have multiple roles.  
 * Add role(s) to your Team-[Team_Number]-[Team_Name].csv file on the main folder.
 * At least one person must be identified as the dedicated partner liaison. They need to have great organization and communication skills.
 * Everyone must contribute to code. Students who don't contribute to code enough will receive a lower mark at the end of the term.

List each team member and:
 * A description of their role(s) and responsibilities including the components they'll work on and non-software related work
 * Why did you choose them to take that role? Specify if they are interested in learning that part, experienced in it, or any other reasons. Do no make things up. This part is not graded but may be reviewed later.

Roles we have: Team Rep (liaison), Developer, UI/UX

#### Q8: How will you work as a team?

Describe meetings (and other events) you are planning to have. 
 * When and where? Recurring or ad hoc? In-person or online?
 * What's the purpose of each meeting?
 * Other events could be coding sessions, code reviews, quick weekly sync meeting online, etc.
 * You should have 2 meetings with your project partner (if you have one) before D1 is due. Describe them here:
   * You must keep track of meeting minutes and add them to your repo under "deliverables/minutes" folder
   * You must have a regular meeting schedule established for the rest of the term.

As a team, we haven't really discussed regular meetings yet. We have a Discord server where we can communicate with each other any time we want and share our progress.

For D1 we only had time to meet with our partner once. In this meeting we discussed the MVP and expectations for the game. Our tentative regular meeting schedule will be wednesday afternoons around the same time biweekly. These will be online.
  
#### Q9: How will you organize your team?

List/describe the artifacts you will produce in order to organize your team.       

 * Artifacts can be To-Do lists, Task boards, schedule(s), meeting minutes, etc.
 * We want to understand:
   * How do you keep track of what needs to get done? (You must grant your TA and partner access to systems you use to manage work)
   * **How do you prioritize tasks?**
   * How do tasks get assigned to team members?
   * How do you determine the status of work from inception to completion?

We communicate via our Discord server. We are thinking of making a Trello board to prioritize and assign tasks.

#### Q10: What are the rules regarding how your team works?

**Communications:**
We are all using a Discord server, we expect everyone to talk in it at least once a day to report on their progress. We have a general channel and a documents channel.

Partner communication is done via email and biweekly meetings.
 
**Collaboration:**
Still mostly done on Discord. If someone isn't doing their assigned work or hasn't reported back yet, we simply ping them or directly message them asking about their progress.

## Organisation Details

#### Q11. How does your team fit within the overall team organisation of the partner?
* Given the team structure of your partner, what role do you think your team will play?
* Examples include product development that includes developing new features, or quality assurance that includes developing features that test the product reliability, or software maintenance that includes fixing crucial bugs in the product.
* Provide examples of why you think you fit this role.
  
Our partner, EWB, is currently running workshops about green revolution. As a team, we are responsible for developing a software simulating the process of food production that the organisation will later use in their workshops. For this project, we are in charged of building all the features as well as maintaining and bug fixing the whole software.  

#### Q12. How does your project fit within the overall product from the partner?
* Look at the big picture of the product and think about how your project fits into this product.
* Is your project the first step towards building this product? Is it the first prototype? Are you developing the frontend of a product whose backend is developed by the partner? Are you building the release pipelines for a product that is developed by the partner? Are you building a core feature set and take full ownership of these features?
* You should also provide details of who else is contributing to what parts of the product, if you have this information. This is more important if the project that you will be working on has strong coupling with parts that will be contributed to by members other than your team (e.g. from partner).
* You can be creative for these questions and even use a graphical or pictorial representation to demonstrate the fit.

  The software we are developing is the whole product that is requested by our partner. The product is a step of the organisation's movement to educate people about global food supply. Our team will make it from stratch based on EWB's expectations and there is also room for creativity beyond them.   
