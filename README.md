# Dialogue System Package

## Overview
The **Dialogue System Package** is a modular and flexible dialogue system for Unity, designed for VR/AR projects. It allows developers to create and manage dialogues efficiently using scriptable objects and UI components.

## Features
- **Scriptable Object-Based Dialogue System**: Easily create dialogue sequences without hardcoding.
- **UI Integration**: Displays dialogue through customizable UI elements.
- **Event-Driven System**: Supports triggers for animations, sounds, and other events.
- **Branching Dialogue**: Allows multiple response options and conditional dialogue progression.
- **Extensible API**: Easily extendable with custom logic and additional features.
- **VR/AR Compatible**: Optimized for Unity's XR Interaction Toolkit.

## Installation

### Using Unity Package Manager (UPM)
1. Open your Unity project.
2. Go to `Window` > `Package Manager`.
3. Click the `+` button and select `Add package from git URL`.
4. Enter the repository URL: 
   ```
   https://github.com/antonelamatanovich/Dialogue-System/tree/upm
   ```
5. Click `Add` and wait for Unity to import the package.

### Manual Installation
1. Download the latest release from [GitHub Releases](https://github.com/antonelamatanovich/Dialogue-System/releases).
2. Extract the package and place it in your `Assets` folder.

## Getting Started
### 1. Creating a Dialogue Asset
1. Navigate to `Assets` > `Create` > `Dialogue`.
2. Create a new dialogue asset and define your dialogue lines.
3. Optionally, add response choices for branching dialogues.

### 2. Setting Up the Dialogue System
1. Add the `DialogueManager` prefab to your scene.
2. Assign a `Dialogue UI` component to handle text display.
3. Attach the `DialogueTrigger` component to objects that should start a conversation.
4. Call `DialogueManager.StartDialogue(dialogueAsset)` to begin a dialogue sequence.

## API Reference
### `DialogueManager`
```csharp
public void StartDialogue(DialogueAsset dialogue);
public void SkipDialogue();
public void EndDialogue();
```

### `DialogueTrigger`
```csharp
public void TriggerDialogue();
```

## Examples
```csharp
void Start()
{
    DialogueManager.Instance.StartDialogue(myDialogueAsset);
}
```

## License
This project is licensed under the MIT License.

## Contributing
Pull requests are welcome! Please open an issue for major changes.

## Contact
For questions and feedback, reach out via [GitHub Issues](https://github.com/antonelamatanovich/Dialogue-System/issues).
