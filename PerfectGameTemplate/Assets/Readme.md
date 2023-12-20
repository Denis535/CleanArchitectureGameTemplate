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
- Set up project dependencies in `Packages/manifest.json`.
```
{
  "dependencies": {
    "com.unity.2d.sprite": "1.0.0",
    "com.unity.addressables": "1.21.19",
    "com.unity.ide.visualstudio": "2.0.22",
    "com.unity.inputsystem": "1.7.0",
    "com.unity.nuget.mono-cecil": "1.11.4",
    "com.unity.render-pipelines.universal": "16.0.4",
    "com.unity.services.lobby": "1.1.2",
    "com.unity.services.matchmaker": "1.1.2",
    "com.unity.services.qos": "1.2.1",
    "com.unity.test-framework": "1.3.9",
    "com.unity.ui": "2.0.0",
    "com.unity.modules.accessibility": "1.0.0",
    "com.unity.modules.animation": "1.0.0",
    "com.unity.modules.audio": "1.0.0",
    "com.unity.modules.imageconversion": "1.0.0",
    "com.unity.modules.jsonserialize": "1.0.0",
    "com.unity.modules.particlesystem": "1.0.0",
    "com.unity.modules.physics": "1.0.0",
    "com.unity.modules.screencapture": "1.0.0",
    "com.unity.modules.terrain": "1.0.0",
    "com.unity.modules.terrainphysics": "1.0.0",
    "com.unity.modules.umbra": "1.0.0",
    "com.unity.modules.unityanalytics": "1.0.0"
  }
}
```
- Link project with Unity Gaming Services.

# Build
- Prepare your project for build (Toolbar / Project / Pre Build).
- Build your project (Toolbar / Project / Build).

# Links
- https://u3d.as/39eY
