# UBC Rose Garden XR Viewfinder (FPS Version)

![RoseGardenUnityImage](docs/doc-image.png)

## Project Overview
A First-Person Shooter (FPS) version of the UBC Rose Garden XR Viewfinder project. The XR version can be found [here](https://github.com/br-zhou/Rose-Garden-VR).
This project was developed as part of a course project at the [Emerging Media Lab](https://eml.ubc.ca/projects/a-pass-thru-vr-viewfinder-experience-for-ubcs-arts-community).

## Development Environment
| Component | Specification |
|-----------|---------------|
| Unity     | 6000.0.36f1 LTS |
| Computer  | MacBook Pro (2020), Apple M1 chip, 16GB |
| OS        | macOS Sequoia 15.4 |

## Project Structure
Below are the locations of important assets:

- `/Assets/Objects` - 3D objects
- `/Assets/Material`- Materials for the 3D objects
- `/Assets/Scripts` - C# scripts
- `/Animation` - Animation Controllers
- `/Firebase` - Database-related

## Scripts Overview
Below are brief descriptions of important scripts:

### Core Systems
- `GameManager.cs` - Main game state management. Manages the selected objects for ray casting.

- `DatabaseManager.cs` - Data persistence and management (Firebase)

### Ray Casting Interaction
- `RayCaster.cs` - Defines the behaviors when an object is ray-cast. Activate new objects, deactivate old objects, or ignore the ray cast.
- `IRayEventReceiver.cs` - Interface for objects that can receive ray-cast interactions.
- `ClickHandler.cs` - Defines key bindings and on-click actions in terms of ray casting.

### Object Controllers

- **Planter System**
  - `PlanterController.cs` - Defines the sequence of actions when the planter is activated or deactivated by ray casting. Calls methods defined in `EnvelopeController.cs`, `RoseController.cs`, and `DescriptionPanelController.cs`.
  - `PlanterControllerCenter.cs` - Inherits `PlanterController.cs` to define center-planter-specific behaviors. Adjusts the position of the envelope and rose description panel.
  - `PlanterPopup.cs` - Defines the position and movement animation of the planters.

- **Envelope System**
  - `EnvelopeController.cs` - Defines envelope rotation and switching animations. Calls methods defined in `EnvelopeScript.cs` and `LetterScript.cs` to manage the animation state and order.
  - `EnvelopeScript.cs` - Defines methods to trigger the envelope animations.
  - `LetterScript.cs` - Defines methods to trigger the letter animations.

- **Rose System**
  - `RoseController.cs` - Controls the active state of each rose in a planter.
  - `RoseScript.cs` - Defines methods to trigger the rose animations.

- **Others**
  - `DescriptionPanelController.cs` - Defines the rose description panel animations.
  - `StartButton.cs` - Defines related behaviors of the instruction panel at the beginning.
  - `FlyingAnimator.cs` - Defines the randomized flying animation of the bees and butterflies.
