# Dialogue System Package

Dialogue System Package is a reusable Unity package that provides a modular dialogue framework built around Scriptable Objects, reusable architecture, and event-driven programming.

The package was developed as part of the **ER-EL Winter Semester 2024 – Depths of Unity** elective course within the **Bachelor of Arts (B.A.) in Expanded Realities** study programme at **Darmstadt University of Applied Sciences (h_da), Germany**.

Rather than creating a complete game, the focus of the project was to design reusable Unity systems, apply software engineering principles, and build maintainable tools that can be integrated into future XR and game development projects.

---

# Course Information

| | |
|---|---|
| **University** | Darmstadt University of Applied Sciences (h_da), Germany |
| **Faculty** | Faculty of Media |
| **Study Programme** | Bachelor of Arts (B.A.) – Expanded Realities |
| **Course** | ER-EL Winter Semester 2024 – Depths of Unity |
| **Semester** | Winter Semester 2024/2025 |
| **Project Type** | Individual Elective Project |
| **Engine** | Unity |
| **Language** | C# |

---

# Project Goals

The primary objective of this project was to design and implement a reusable dialogue framework that follows modern Unity development practices and software engineering principles.

The project focuses on:

- Reusable dialogue architecture
- Scriptable Object workflows
- Modular system design
- Event-driven programming
- Extensible Unity tooling
- Maintainable code structure

Instead of implementing dialogue directly inside gameplay scripts, the system separates dialogue data, presentation, and interaction logic into reusable components.

---

# Features

## Dialogue Assets

Dialogue content is stored using Unity Scriptable Objects.

This allows dialogue to be:

- Created without hardcoding
- Easily reusable
- Editable inside the Unity Editor
- Independent from gameplay logic

---

## Dialogue Manager

The Dialogue Manager is responsible for:

- Starting conversations
- Progressing dialogue
- Ending dialogue
- Managing dialogue flow

Gameplay systems communicate with the manager through a clean and reusable API.

---

## Dialogue Triggers

Dialogue can be started through reusable trigger components attached to scene objects.

This allows NPCs and interactive objects to share the same dialogue system without custom scripting.

---

## Branching Dialogue

The package supports branching conversations through dialogue choices.

This allows developers to create interactive conversations with multiple possible dialogue paths.

---

## User Interface

The dialogue system integrates with Unity UI and supports:

- Dialogue windows
- Speaker names
- Dialogue text
- Response options
- Next dialogue progression

The presentation layer remains independent from dialogue data.

---

## Event-Driven Architecture

Dialogue events can trigger additional gameplay behaviour, making the system easy to integrate with other mechanics.

Possible integrations include:

- Animations
- Audio
- Quests
- Gameplay events
- Scene interactions

---

# Technologies

- Unity
- C#
- Unity UI
- Scriptable Objects
- Unity Events
- TextMesh Pro

---

# Software Engineering Concepts

The project demonstrates practical Unity development concepts including:

- Object-Oriented Programming (OOP)
- Component-Based Architecture
- Scriptable Objects
- Event-Driven Programming
- Composition
- Modular System Design
- Separation of Concerns
- Reusable Gameplay Systems

---

# Project Structure

```text
Assets/
│
├── Dialogue/
├── Dialogue Assets/
├── Dialogue Manager/
├── Dialogue Trigger/
├── UI/
├── Scriptable Objects/
└── Runtime/
```

---

# Example Workflow

Creating a dialogue consists of the following steps:

1. Create a new Dialogue Scriptable Object.
2. Add dialogue lines and optional dialogue choices.
3. Assign the dialogue asset to a Dialogue Trigger.
4. Place the Dialogue Trigger in the scene.
5. Start the conversation through player interaction.

The Dialogue Manager handles the remaining dialogue flow automatically.

---

# Repository Notes

This repository contains the reusable dialogue package developed during the course.

The project focuses on architecture and reusable Unity systems rather than a standalone game. It can serve as a foundation for future Unity, XR, and game development projects.

---

# What I Learned

This project allowed me to gain practical experience with:

- Unity package architecture
- Scriptable Objects
- Event-driven programming
- Modular software design
- Separation of concerns
- Reusable Unity systems
- UI integration
- API design
- Software architecture

The project strengthened my understanding of how reusable development tools can improve maintainability and scalability across larger Unity projects.

---

# Future Improvements

Possible future extensions include:

- Dialogue localisation
- Voice-over support
- Dialogue conditions
- Save and load integration
- Rich text formatting
- Typewriter animation
- Timeline integration
- Visual dialogue editor
- Node-based dialogue graph
- XR interaction support

---

# Author

**Antonela Matanović**

Bachelor of Arts (B.A.) – Expanded Realities

Faculty of Media

Darmstadt University of Applied Sciences (h_da)

Developed as part of the **ER-EL Winter Semester 2024 – Depths of Unity** elective course during the **Winter Semester 2024/2025**.
