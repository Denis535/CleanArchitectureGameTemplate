# Overview
The PerfectGameTemplate is well designed game template allowing you to quickly and efficiently start developing your project with best practices, architecture and structure (like Clean Architecture and Uber Ribs).

# Details
The project consists of the following modules: Root, UI, App, Entities, Core, Tests.
And the project depends on the following modules: Clean Architecture Game Framework, Addressables Source Generator, Colorful Project Window, UIToolkit Theme Style Sheet.

## Clean Architecture Game Framework
This package provides you with clean architecture framework that helping you to develop your project following the best practices (like Clean Architecture and Uber Ribs).
* Framework
  * IDependencyContainer
  * Program
* Framework.UI
  * UIAudioTheme - audible component
  * UIScreen - logical component
  * UIWidget - logical component
  * UIView - visual component
  * UIRouter - application state router
* Framework.App
  * Application
  * Globals - global variables and constants.
* Framework.Entities
  * Game - game rules and states.
  * Player - player rules and states.
  * World - world.
  * WorldView - world visual/audible component.
  * Entity - entity (player avatar).
  * EntityView - entity visual/audible component.
  * EntityBody - entity physical component.
* System
  * Assertions
  * Exceptions
  * Option

## Addressables Source Generator
This package gives you an ability to generate a hierarchical list of all addressable assets and its labels.

## Colorful Project Window
This package (Colorful Project Window) gives you the more comfortable and colorful project window.

## UIToolkit Theme Style Sheet
This package provides you with beautiful theme style sheets and some additions and tools for UIToolkit.

# Setup
- Install embedded packages.
- Link project with Unity Gaming Services.

# Build
- Prepare your project for build (Toolbar / Project / Pre Build).
- Build your project (Toolbar / Project / Build).

# Links
- https://u3d.as/39eY
- https://youtu.be/tardralpxdA
