# Overview
The PerfectGameTemplate is well designed game template allowing you to quickly and efficiently start developing your project.
It shows you well thought out structure and architecture of project following best practices (like Clean Architecture, Uber Ribs).
And also it provides you with useful framework, utils, extensions and tools.

# Features
- Well designed project structure.
- Well designed project architecture.
- Framework which you can use in other projects.
- Project.
    - Beautiful UI powered by modern UI Toolkit, Pug and Stylus.
    - State (logic) driven UI architecture.
    - Domain driven project architecture.
- Tools.
    - Source generator (asset addresses and labels).
    - Project window with conveniently highlighted modules, assets, sources.
    - Project configurator (script execution order).
    - Project analyzer (naming convention).
    - Project builder.
- Misc.
    - Environment utils.
    - Storage utils.
    - Assertion and exception utils.

# Reference
It consists of two projects: PerfectGameTemplate and PerfectGameTemplate.Internal.

# Reference (PerfectGameTemplate)
The main project.
## Project
The module contains scenes, main classes and tools.
## Project.UI
The module contains screens, widgets, views, styles and other.
## Project.App
The module contains application logic, global variables and constants.
## Project.Entities
The module contains entities (domain) logic.
## Project.Core
The module contains everything common for all modules (settings, asset addresses and labels).

# Reference (PerfectGameTemplate.Internal)
The project encapsulates everything rarely viewed and changed (third party, libraries, frameworks, utils, extensions).
## System
- Assertions.
- Exceptions.
- Option.
## UnityEngine
- UI Toolkit.
- Stylus.
- Pug.
- Addressables.
## UnityEngine.Framework
- Program.
- IDependencyContainer.
## UnityEngine.Framework.UI
- UIAudioTheme - audible component.
- UIScreen - logical component.
- UIWidget - logical element.
- UIView - visual element.
- UIRouter - ui and app state router.
## UnityEngine.Framework.App
- Application - application.
- Globals - global variables and constants.
## UnityEngine.Framework.Game
- Game - game rules and states.
- Player - player rules and states.
- World - world.
- WorldView - world visual/audible component.
- Entity - entity (player avatar).
- EntityView - entity visual/audible component.
- EntityBody - entity physical component.
## UnityEditor.Windows
- ProjectWindow - project window with folders and assets painted in special colors.
## UnityEditor.Tools
- SourceGenerator - source generator to generate assets addresses and labels.
- ProjectConfigurator - project configurator to configure scripts execution order.
- ProjectAnalyzer - project analyzer to analyzer coding conventions.
- ProjectBuilder - project builder.

# Setup
- Unpack PerfectGameTemplate project.
- Unpack PerfectGameTemplate.Internal project near to PerfectGameTemplate project.
- Link PerfectGameTemplate project with "com.pgt.internal" package (Package Manager Window / Install package from disk).
- Link PerfectGameTemplate project with unity gaming services.
- Install Node.js, Stylus and Pug npm on your PC.

# Build
- Build addressables asset bundles (Addressables Groups Window / Build / New Build / Default Build Script).
- Prepare your project (Toolbar / Tools / Pre Build) (it generates sources, configures and analyzes project).
- Build your project (Toolbar / Tools / Build).