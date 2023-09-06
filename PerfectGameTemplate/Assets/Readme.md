# Overview
The PerfectGameTemplate is designed to be the foundation for any project. It's well designed and it allows you to quickly and efficiently start developing you any project.

# Reference
It consists of two projects: PerfectGameTemplate and PerfectGameTemplate.Internal.

## PerfectGameTemplate
The project contains all modules of game.

### Main
The module contains scenes (Launcher, Program, MainScene, GameScene), main classes and some tools.

### UI
The module contains screens (MainScreen, GameScreen, DebugScreen), widgets, views, styles and other assets.

### App
The module contains application manager, game manager, global variables and constants.

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

# Setup
1. Install Node.js on your PC.
2. Install Stylus npm package on your PC.
3. Install Pug npm package on your PC.

## PerfectGameTemplate
1. Link project with "com.pgt.internal" package. Open Package Manager, press "Install package from disk" and choose "com.pgt.internal" package.
2. Link project with unity gaming services.
3. Create Packages/manifest.json with content:
{
  "dependencies": {
    "com.unity.modules.animation": "1.0.0",
    "com.unity.modules.audio": "1.0.0",
    "com.unity.modules.imageconversion": "1.0.0",
    "com.unity.modules.jsonserialize": "1.0.0",
    "com.unity.modules.particlesystem": "1.0.0",
    "com.unity.modules.physics": "1.0.0",
    "com.unity.modules.terrain": "1.0.0",
    "com.unity.modules.terrainphysics": "1.0.0",
    "com.unity.modules.umbra": "1.0.0",
    "com.unity.modules.unityanalytics": "1.0.0",
    "com.unity.services.lobby": "1.1.0",
    "com.unity.services.matchmaker": "1.0.0",
    "com.unity.services.qos": "1.2.1",
    "com.unity.nuget.mono-cecil": "1.11.4",
    "com.unity.addressables": "1.21.17",
    "com.unity.render-pipelines.universal": "15.0.6",
    "com.unity.postprocessing": "3.3.0",
    "com.unity.ui": "2.0.0",
    "com.unity.2d.sprite": "1.0.0",
    "com.unity.textmeshpro": "3.0.6",
    "com.unity.inputsystem": "1.7.0",
    "com.unity.test-framework": "1.3.9",
    "com.unity.ide.visualstudio": "2.0.20",
    "com.pgt.internal": "file:../../PerfectGameTemplate.Internal/Assets/com.pgt.internal"
  }
}

## PerfectGameTemplate.Internal
1. Unpack PerfectGameTemplate.Internal project near to the main PerfectGameTemplate project.
2. Create Packages/manifest.json with content:
{
  "dependencies": {
    "com.unity.modules.animation": "1.0.0",
    "com.unity.modules.audio": "1.0.0",
    "com.unity.modules.imageconversion": "1.0.0",
    "com.unity.modules.jsonserialize": "1.0.0",
    "com.unity.modules.particlesystem": "1.0.0",
    "com.unity.modules.physics": "1.0.0",
    "com.unity.modules.terrain": "1.0.0",
    "com.unity.modules.terrainphysics": "1.0.0",
    "com.unity.modules.umbra": "1.0.0",
    "com.unity.modules.unityanalytics": "1.0.0",
    "com.unity.services.lobby": "1.1.0",
    "com.unity.services.matchmaker": "1.0.0",
    "com.unity.services.qos": "1.2.1",
    "com.unity.nuget.mono-cecil": "1.11.4",
    "com.unity.addressables": "1.21.17",
    "com.unity.render-pipelines.universal": "15.0.6",
    "com.unity.postprocessing": "3.3.0",
    "com.unity.ui": "2.0.0",
    "com.unity.2d.sprite": "1.0.0",
    "com.unity.textmeshpro": "3.0.6",
    "com.unity.inputsystem": "1.7.0",
    "com.unity.test-framework": "1.3.9",
    "com.unity.ide.visualstudio": "2.0.20"
  }
}