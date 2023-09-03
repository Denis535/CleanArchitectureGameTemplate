# Overview
The main purpose of this package is provide you with framework (something like Uber Ribs) that defines ui and project architecture. Also it contains useful system utils, unity utils and tools.

# Features
## Framework
- Program - root of application
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
## System
- Assertions
- Exceptions
## UnityEngine
- UI Toolkit
- Stylus
- Pug
- Addressables
## UnityEditor
 - ProjectWindow - project window with folders and assets painted in special colors
 - SourceGenerator - source generator to generate assets addresses and labels
 - ProjectConfigurator - project configurator to configure scripts execution order
 - ProjectAnalyzer - project analyzer to analyzer coding conventions
 - ProjectBuilder - project builder