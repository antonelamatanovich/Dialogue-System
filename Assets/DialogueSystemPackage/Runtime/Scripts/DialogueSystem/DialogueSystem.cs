/********************************************************************************
 * Script:        DialogueSystem.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Handles dialogue logic, includes methods to start, continue, 
                  and end a conversation, tracks the current state (which line of 
                  dialogue is showing, what the next choices are)
 ********************************************************************************/

using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueSystem : MonoBehaviour
{
    public string[] dialogueLines;  // array of dialogue lines
    public UnityEvent onDialogueEnd;  // event to trigger when the dialogue ends

    private int currentLine = 0;  // keeps track of the current dialogue line

    // start the dialogue system
    public void StartDialogue()
    {
        currentLine = 0;  // reset dialogue position
        ShowDialogue();  // show the first dialogue line
    }

    // show the current dialogue line
    public void ShowDialogue()
    {
        if (currentLine < dialogueLines.Length)
        {
            Debug.Log(dialogueLines[currentLine]);  // display the current line
            currentLine++;  // move to the next line
        }
        else
        {
            EndDialogue();  // end the dialogue if there are no more lines
        }
    }

    // end the dialogue and trigger an event
    private void EndDialogue()
    {
        onDialogueEnd.Invoke();  // trigger the end event
        Debug.Log("Dialogue Ended");  // log the end of the dialogue
    }
}
