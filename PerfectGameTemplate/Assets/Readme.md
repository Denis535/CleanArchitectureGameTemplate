# Overview
The PerfectGameTemplate is well designed game template allowing you to quickly and efficiently start developing your project.
It shows you well thought out structure and architecture of project following best practices (like Clean Architecture, Uber Ribs).
It provides you with useful framework, utils, extensions and tools.
It uses UI Toolkit with Pug and Stylus for easy creation of most beautiful UI.

# Reference
It consists of two projects: PerfectGameTemplate and PerfectGameTemplate.Internal.

# Reference (PerfectGameTemplate)
The project contains all modules.
## Project
The module contains scenes (Launcher, Program, MainScene, GameScene), main classes and tools.
## Project.UI
The module contains screens (MainScreen, GameScreen, DebugScreen), widgets, views, styles and other.
## Project.App
The module contains application logic, global variables and constants.
## Project.Game
The module contains game (domain) logic.
## Project.Core
The module contains everything common for all modules (settings, asset addresses and labels).

# Reference (PerfectGameTemplate.Internal)
The project encapsulates everything rarely viewed and changed (third party, libraries, frameworks, utils, extensions).
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