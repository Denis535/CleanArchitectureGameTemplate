# Overview
This well designed project shows an example of good structure and architecture of the unity game project.
This allowing you to quickly and efficiently start developing your own project with the best practices (like Domain Driven Design, Clean Architecture and Uber Ribs).

# Reference
The project consists of the following modules:

## Assemblies
### Project
The root of project.
This contains the entry point and scenes.

### Project.UI
The presentation (user interface) logic.
This contains ui-level logic: the audio theme, screens, widgets and views.

### Project.App
The application logic.
This contains application-level logic: game start/stop, pasue/unpause, save/load, environment variables.

### Project.Entities
The domain (entities) logic.
This contains game-level logic: game, players, entities.

### Project.Common
Everything common.

# Setup
- Install the "UIToolkit Theme Style Sheet" package (https://assetstore.unity.com/packages/tools/gui/uitoolkit-theme-style-sheet-273463s).
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

# Links
- https://denis535.github.io
- https://assetstore.unity.com/publishers/90787
- https://denis535.itch.io/
- https://openupm.com/packages/?sort=downloads&q=denis535
- https://www.youtube.com/channel/UCLFdZl0pFkCkHpDWmodBUFg

# If you want to support me
If you want to support me, please rate my packages, subscribe to my YouTube channel and like my videos.
