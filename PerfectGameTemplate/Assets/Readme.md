# Overview
The PerfectGameTemplate is well designed game template allowing you to quickly and efficiently start developing your project.
It demonstrates well thought out structure and architecture of project.
And it also provides framework (like Uber Ribs) which helps you design high quality project architecture (like Clean Architecture) and useful system extensions, engine extensions, and tools.

# Reference
It consists of two projects: PerfectGameTemplate and PerfectGameTemplate.Internal.

# Reference (PerfectGameTemplate)
The project contains all modules.
## Main
The module contains scenes (Launcher, Program, MainScene, GameScene), main classes and tools.
## UI
The module contains screens (MainScreen, GameScreen, DebugScreen), widgets, views, styles and other.
## App
The module contains application logic, global variables and constants.
## Game
The module contains game (domain) logic.
## Core
The module contains everything common for all modules (asset addresses and labels).

# Reference (PerfectGameTemplate.Internal)
The project encapsulates everything rarely viewed and changed (third party, libraries, frameworks, utils).
## System
- Assertions
- Exceptions
## UnityEngine
- UI Toolkit
- Stylus
- Pug
- Addressables
## UnityEngine.Framework
- Program - entry point
- IDependencyContainer - dependency container
## UnityEngine.Framework.UI
- UIAudioTheme - audible component
- UIScreen - logical component
- UIWidget - logical element
- UIView - visual element
- UIRouter - ui and app state router
## UnityEngine.Framework.App
- Application - application
- Globals - global variables and constants
## UnityEngine.Framework.Game
- Game - game rules and states
- Player - player rules and states
- World - world
- WorldView - world visual/audible component
- Entity - entity (player avatar)
- EntityView - entity visual/audible component
- EntityBody - entity physical component
## UnityEditor
 - ProjectWindow - project window with folders and assets painted in special colors
 - SourceGenerator - source generator to generate assets addresses and labels
 - ProjectConfigurator - project configurator to configure scripts execution order
 - ProjectAnalyzer - project analyzer to analyzer coding conventions
 - ProjectBuilder - project builder

# Setup
1. Unpack PerfectGameTemplate project.
2. Unpack PerfectGameTemplate.Internal project near to PerfectGameTemplate project.
3. Link PerfectGameTemplate project with "com.pgt.internal" package (Open Package Manager, press "Install package from disk" and choose "com.pgt.internal" package).
4. Link PerfectGameTemplate project with unity gaming services.
5. Install Node.js, Stylus and Pug npm on your PC.