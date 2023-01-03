# Sticky Walls

![Page](Title.png?raw=true "Title")

## Table of contents
- [Overview](#overview)
- [Start Point](#start-point)
- [Game Concept](#game-concept)
- [Backlog list](#backlog)
- [Strategic design, tactical programming and development pipeline](#design)
- [DDD context maps and concepts](#ddd)
- [Roadmap](#roadmap)
- [Dangerous points in concept and development with current project](#bottlenecks)
- [SOLID-match](#solid)
- [Learning references and sources](#refs)

# <a name="overview"></a>Overview
This project is created with purpose of training in planning and development of game prototypes, using a rather large range of possibilities. In the context of design, an object-oriented design paradigm has been chosen, which, together with TDD, allows to achieve a balance between speed and security in the development of a domain architecture. As an option ECS was seen as a flexible practice, but i think it's pretty abstract and does not lead to a deeper knowledgeof the game elements and their true representation in the project. Extenject is used as an IoC container to ensure good binding of elements. Testing takes place on Nunit with limited NSubstitute mocking library (simple and efficient). The DOTween library is used to help with a movement of the objects. The stylistic changes bought through the store are implemented using Addresabless, as a necessary (and convenient) standard for working with assets. In the project, the system of achievements is implemented through Google Play. Through it are implemented and in-game purchases. Integrated advertising Unity Ads. It also collects data with Unity Analitics.

# <a name="start-point"></a>Start Point

At the time of the start of the project, some work on the code base and knowledge processing was already carried out. Architecture at that time was based only on SOLID principles, and even that was a good basis for the future foundation of the game’s prototype. At the time of initialization of this project on githab a certain list of materials (links at the end) was already studied, and it was decided to necessarily implement XP concepts in the system design. Testing was not present until this moment in the pipeline development, respectively, there was a question of working with the legacy code and covering the tests of the current project.

# <a name="game-concept"></a>Game concept

A copy of a real game from Google Play Market called Wall Kickers. The game is a 2D platformer in which the character moves up from wall to wall wall by tapping the screen. The walls have properties: from one it will slide, the second - repel, the third - kill and so on. Upon pressing the button, the character leaps from the wall and upwards, and the second tap - jump with a change of direction. There are also horizontal platforms, and when touched the player moves on them in the direction where he was last directed. Coins appear on the screen in random places, and you can buy screen, hero and wall style changes. Calculate the maximum height (record), which the player raises. Every N units of height can be saved after touching the wall with checkpoint. Falling below the screen or touching a dangerous wall, the player will reborn on the checkpoint three times before dying and reappearing.

> When you press and touch the walls, the character makes a sound and changes the animation.

#### The following types of walls were selected for implementation in the prototype:
- slippery - the player drops when touched;
- normal - the player does not change positions;
- elastic - the player touches the other side;
- dangerous - dies on contact;
- destructible - the first touch - behaves as usual, after repulsion it breaks down and recovers over time;
- electric - every N seconds shocks the one who holds it, as a result he dies;
- turnstile - every N seconds mirrors the position of the elements;
- moving - moves along the route, allows you to fix it and move together.

# <a name="backlog"></a>Backlog

The game should implement the following:
- loading the game;
- level creation;
- player movement;
- wall mechanics;
- checkpoints;
- coin collection;
- level generation;
- in-game store;
- in-game purchasing;
- achievements;
- advertising;
- analytics.

# <a name="design"></a>Strategic design, tactical programming and development pipeline

The first step is to get the current draft ready for the full development cycle. Once the project is initialized, the repository is configured and the project description
is described, it is necessary to proceed to the project requirements setting, technology selection and product backlog planning. In particular, we will use it at every stage to assess the progress of the project. The next important stage, which is typical for this case - the analysis of the legacy code and the initial coverage of tests. After making sure that we have tested system and set of requirements for the final version, we start iterative design.

With DDD, we mark our domain area into individual sub-domains, highlighting the semantic core and service sub-domains, while paying attention to the context marking in them. When implementing changes we will focus on this map of context and if necessary we will refine it and refactoring the system.

Before each step, we run previous tests to make sure the system is stable. After designing a new feature, we determine whether we can make a change to the prototype, if not, at this stage we refactoring and only then develop the possibility itself. After implementation, tests are run and system optimization is tested. If the system has performance problems, additional refactoring is made for graphics or computation.

All the new features are added first to the feature branch, from which they will push into development branch. The set of several linked features forms a release - push from branch develop to branch release. It only has hotfix releases, bug fixes, and merges. After fixing bugs the data in master branch, compile the project and publish this release file.

# <a name="ddd"></a>DDD context maps and concepts

Knowledge of the Domain is transferred to a separate folder named "Domain".

# <a name="roadmap"></a>RoadMap

![Page](Roadmap.png?raw=true "Roadmap")

### Milestone 1:
**Date**: first half of November.
**Name**: Main functionality.
**Release**:
- loading the game;
- level creation;
- player movement;
- wall mechanics;
- checkpoints;
- coin collection.

### Milestone 2:
**Date**: first half of December.
**Name**: Style and shopping.
**Release**:
- level generation;
- in-game store;
- in-game purchasing.

### Milestone 3:
**Date**: second half of December.
**Name**: Monetization.
**Release**:
- achievement system;
- advertising;
- analytics.

# <a name="bottlenecks"></a>Dangerous points in concept and development with current project

It should be noted that despite the small amount of mechanics in the game it seems too simple. However, I have noted for myself a list of "bottlenecks" when designing which i try to work through various user scenarios with a possible extension of the system functionality:
1. Interaction of closely connected entities;
2. Possible introduction of new wall types;
3. Working with a physical game model.

# <a name="solid"></a>SOLID-match

Since the project was originally designed to be developed through the lens of SOLID, the addition of the DDD paradigm not only allows for better management of responsibilities between classes, but also for a qualitative separation of interfaces between prototype objects. One should not forget that Extenject is used to implement dependencies that provide inversion. Additional assistance is provided by the heuristic response analysis method in the class described by Michael Feathers. The method describes quite precisely the process of finding and identifying SRP execution in places where it seems confusing.

# <a name="refs"></a>Learning references and sources

The books i used to develop:
- Robert C. Martin "Clean code";
- Eric Evans "Domain-Driven Design: Tackling Complexity in the Heart of Software";
- Mark Seeman "Dependency inversion in .NET";
- Vaughn Vernon "Implementing domain-driven design";
- Roy Osherove "The Art of Unit Testing: with examples in C#";
- Michael Feathers "Working Effectively with Legacy Code".
