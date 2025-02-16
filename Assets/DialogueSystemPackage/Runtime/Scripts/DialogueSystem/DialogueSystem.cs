/********************************************************************************
 * Script:        DialogueSystem.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Handles dialogue logic, includes methods to start, continue, 
 *                and end a conversation, tracks the current state (which line of 
 *                dialogue is showing, what the next choices are)
 ********************************************************************************/

using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSystem : MonoBehaviour
{
    public string[] dialogueLines;  // stores dialogue lines
    public UnityEvent onDialogueEnd;  // event triggered when dialogue ends
    public string playerName = "Antonela";  // example player name

    // references for ui or character movement
    public Transform speakerTransform;  // speaker's transform (optional)
    public Transform dialogueBoxTransform;  // dialogue ui transform (optional)
    public Vector3 speakerTargetPosition;  // target position for speaker movement
    public Vector3 uiTargetPosition;  // target position for dialogue ui
    public float moveDuration = 1.5f;  // duration for movement transitions

    private int currentLine = 0;  // tracks the current dialogue line

    // starts the dialogue
    public void StartDialogue()
    {
        currentLine = 0;  // reset dialogue position
        dialogueLines.Shuffle();  // shuffle dialogue lines

        // move speaker if assigned
        if (speakerTransform != null)
        {
            speakerTransform.MoveTo(speakerTargetPosition, moveDuration);
        }

        // move dialogue ui box if assigned
        if (dialogueBoxTransform != null)
        {
            dialogueBoxTransform.MoveTo(uiTargetPosition, moveDuration);
        }

        ShowDialogue();  // display the first dialogue line
    }

    // displays the current dialogue line
    public void ShowDialogue()
    {
        if (currentLine < dialogueLines.Length)
        {
            string formattedLine = dialogueLines[currentLine].FormatDialogue(playerName);  // format text with variables
            Debug.Log(formattedLine);  // output formatted line
            currentLine++;  // move to the next line
        }
        else
        {
            EndDialogue();  // end the dialogue when no lines remain
        }
    }

    // ends the dialogue and triggers an event
    private void EndDialogue()
    {
        onDialogueEnd.Invoke();  // trigger event when dialogue ends
        Debug.Log("dialogue ended");  // log dialogue completion
    }
}
