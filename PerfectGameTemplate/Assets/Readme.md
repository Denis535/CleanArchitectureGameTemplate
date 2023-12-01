# Overview
The PerfectGameTemplate is well designed game template allowing you to quickly and efficiently start developing your project.
It shows you well thought out structure and architecture of project following best practices (like Clean Architecture, Uber Ribs).
And also it provides you with useful framework, utils, extensions and tools.

# Features
- Well designed project structure.
- Well designed project architecture (domain driven project architecture and state (logic) driven UI architecture).
- Well designed framework which you can use in any other projects (something like Uber Ribs).
- Beautiful dark theme style sheet.
- Utils - assertions, exceptions, storage, environment arguments, etc.
- Tools - resources and labels source generator, project configurator, project analyzer, project builder.
- Project window - project window with conveniently highlighted folders and assets.

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
The module contains everything common (settings, asset addresses and labels).

# Reference (PerfectGameTemplate.Internal)
The project encapsulates everything rarely viewed and changed (third party, libraries, frameworks, utils, extensions).
## System
- Assertions
- Exceptions
- Option
## UnityEngine
- UI Toolkit
- Stylus
- Pug
- Addressables
## UnityEngine.Framework
- Program
- IDependencyContainer
## UnityEngine.Framework.UI
- UIAudioTheme - audible component
- UIScreen - logical component
- UIWidget - logical element
- UIView - visual element
- UIRouter - ui and app state router
## UnityEngine.Framework.App
- Application
- Globals - global variables and constants.
## UnityEngine.Framework.Game
- Game - game rules and states.
- Player - player rules and states.
- World - world.
- WorldView - world visual/audible component.
- Entity - entity (player avatar).
- EntityView - entity visual/audible component.
- EntityBody - entity physical component.
## UnityEditor.Tools
- SourceGenerator - source generator to generate assets addresses and labels.
- ProjectConfigurator - project configurator to configure scripts execution order.
- ProjectAnalyzer - project analyzer to analyzer coding conventions.
- ProjectBuilder - project builder.
## UnityEditor.Windows
- ProjectWindow - project window with folders and assets painted in special colors.

# Setup
- Link project with Unity Gaming Services.

# Build
- Prepare your project for build (Toolbar / Project / Pre Build).
- Build your project (Toolbar / Project / Build).

# Links
https://u3d.as/39eY
