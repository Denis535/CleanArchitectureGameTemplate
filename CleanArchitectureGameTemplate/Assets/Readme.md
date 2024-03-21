# Overview
This project is well designed game template allowing you to quickly and efficiently start developing your project with the best practices (like Domain Driven Design, Clean Architecture and Uber Ribs).

# Reference
## Assemblies
The project consists of the following modules:
### Project
The root of project (entry point, global logic, scenes).
### Project.UI
The presentation-level objects (audio theme, screens, widgets and views).
### Project.App
The application-level objects (application, global variables).
### Project.Entities
The domain-level objects (game, players, characters, entities).
### Project.Common
Everything common.

## Namespaces
The project consists of the following namespaces:
### Project
The root of project.
### Project.UI
The presentation-level objects.
### Project.UI.MainScreen
The presentation-level objects.
### Project.UI.GameScreen
The presentation-level objects.
### Project.UI.Common
The presentation-level objects.
### Project.App
The application-level objects.
### Project.Entities.MainScene
The domain-level objects.
### Project.Entities.GameScene
The domain-level objects.
### Project.Entities.WorldScene
The domain-level objects.
### Project.Entities.Common
The domain-level objects.

# Clean Architecture Game Framework
This package contains classes that define the entire architecture of your game project and some other utilities.

## Assemblies
### CleanArchitectureGameFramework
This module contains additional classes.
### CleanArchitectureGameFramework.Core
This module contains main classes.
### CleanArchitectureGameFramework.Internal
This module contains utilities and helpers.

## Namespaces
### Framework
This namespace represents the root module.

**IDependencyContainer** -
This interface allows you to resolve your dependencies.

**Program** -
This class is responsible for the startup and global logic.

### Framework.UI
This namespace represents the presentation (user interface) module.

**UIAudioTheme** -
This class is responsible for the audio theme.

**UIScreen** -
This class is responsible for the user interface.
The user interface consists of the hierarchy of logical (business) units and the hierarchy of visual units.

**UIWidget** -
This class is responsible for the business logic of ui unit. This may contain (or not contain) the view.

**UIView** -
This class is responsible for the visual (view) logic of ui unit.
This just contains the VisualElement, so it's essentially a wrapper for VisualElement.

**UIRouter** -
This class is responsible for the application state.

### Framework.App
This namespace represents the application module.

**Application** -
This class is responsible for the application logic.

**Globals** -
This class provides you with the global values.

### Framework.Entities
This namespace represents the domain (entities) module.

**Game** -
This class is responsible for the game rules and states.

**Player** -
This class is responsible for the player rules and states.

**World** -
This class is responsible for the world.

**WorldView** -
This class is responsible for the world's visual and audible aspects.

**Entity** -
This class is responsible for the scene's entity (player's avatar, AI agent or any other object).

**EntityView** -
This class is responsible for the entity's visual and audible aspects.

**EntityBody** -
This class is responsible for the entity's physical aspects.

# Setup
- Install the "UIToolkit Theme Style Sheet" package (https://denis535.github.io/#uitoolkit-theme-style-sheet).
- Embed "UIToolkit Theme Style Sheet" package (press Tools/UIToolkit Theme Style Sheet/Embed Package).
- Link project with Unity Gaming Services.

# Build
- Prepare your project for build (Toolbar / Project / Pre Build).
- Build your project (Toolbar / Project / Build).

# FAQ
- Why can not I compile the stylus files?
    - You need to install the node.js and stylus.
- Why is the "ThemeStyleSheet.styl" compiled with errors?
    - The "UIToolkit Theme Style Sheet" package must be embedded.
- Why is the UI broken?
    - Sometimes you need to reimport the "UIToolkit Theme Style Sheet" package.

# Media
- https://youtu.be/SJ8aB4fxgUo?feature=shared

# Links
- https://denis535.github.io
- https://assetstore.unity.com/publishers/90787
- https://denis535.itch.io/
- https://openupm.com/packages/?sort=downloads&q=denis535
- https://www.youtube.com/channel/UCLFdZl0pFkCkHpDWmodBUFg
- https://github.com/Denis535/CleanArchitectureGameTemplate/

# If you want to support me
If you want to support me, please rate my packages, subscribe to my YouTube channel and like my videos.
