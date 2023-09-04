# Overview
The PerfectGameTemplate is designed to be the foundation for any other project. It's very well designed and it allows you to quickly and efficiently start developing any project.

# Setup
1. You must link project with "com.pgt.internal" package. Unpack PerfectGameTemplate.Internal project next to the main PerfectGameTemplate project. Open Package Manager, press "Install package from disk" and choose "com.pgt.internal" package.
2. You must link project with unity gaming services.
3. Install Stylus npm package.
4. Install Pug npm package.

# Reference
It consists of two projects: PerfectGameTemplate and PerfectGameTemplate.Internal.

## PerfectGameTemplate
The project contains all modules of game.

### Main
The module contains scenes (Launcher, Program, MainScene, GameScene), main classes and some tools.

### UI
The module contains screens (MainScreen, GameScreen, DebugScreen), widgets, views, styles and other assets.

### App
The module contains application manager, game manager, globals (environment arguments, storage values and other global variables and constants).

### Game
The module contains domain logic.

### Core
The module contains something common for all modules (addresses and labels).

## PerfectGameTemplate.Internal
The project contains "com.pgt.internal" package which hides in itself rarely changed code (third party, framework, utils, tools).

### Framework
The framework that helps you to develop your project (following the principles of clean architecture) and designing your UI (as hierarchy of logical and visual units, similar to uber ribs).
- Root
    * Program - main class of application
- UI
    * UIAudioTheme - ui audible component
    * UIScreen - ui logical component
    * UIWidget - ui logical element
    * UIView - ui visual element
    * UIRouter - app state manager
- App
    * AppManager - app manager
    * GameManager - game manager
- Game
    * Game - game rules and states
    * Player - player rules and states
    * World - world
    * WorldView - world visual/audible component
    * Entity - entity (player avatar)
    * EntityView - entity visual/audible component
    * EntityBody - entity physical component

### System
- Assertions
- Exceptions

### UnityEngine
- UI Toolkit
- Stylus
- Pug
- Addressables

### UnityEditor
 - ProjectWindow - project window with folders and assets painted in special colors
 - SourceGenerator - source generator to generate assets addresses and labels
 - ProjectConfigurator - project configurator to configure scripts execution order
 - ProjectAnalyzer - project analyzer to analyzer coding conventions
 - ProjectBuilder - project builder
