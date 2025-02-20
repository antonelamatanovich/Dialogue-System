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
using UnityEngine.UI; 
using TMPro; 

public class DialogueSystem : MonoBehaviour
{
    public string[] dialogueLines;  // stores dialogue lines
    public UnityEvent onDialogueEnd;  // event triggered when dialogue ends
    public string playerName = "Antonela";  // example player name

    // references for UI or character movement
    public Transform speakerTransform;  // speaker's transform (optional)
    public Transform dialogueBoxTransform;  // dialogue UI transform (optional)
    public Vector3 speakerTargetPosition;  // target position for speaker movement
    public Vector3 uITargetPosition;  // target position for dialogue UI
    public float moveDuration = 1.5f;  // duration for movement transitions

    public TMP_Text dialogueText;  // text element to display dialogue
    public Button nextButton;  // button to proceed with dialogue

    // reference to ObjectInstantiator.cs for spawning objects
    public ObjectInstantiator objectInstantiator;

    private int currentLine = 0;  // tracks the current dialogue line

    // starts the dialogue
    public void StartDialogue()
    {
        currentLine = 0;  // reset dialogue position to the start
        dialogueLines.Shuffle();  // shuffle dialogue lines before starting

        // move speaker if assigned
        if (speakerTransform != null)
        {
            speakerTransform.MoveTo(speakerTargetPosition, moveDuration);
        }

        // move dialogue UI box if assigned
        if (dialogueBoxTransform != null)
        {
            dialogueBoxTransform.MoveTo(uITargetPosition, moveDuration);
        }

        // setup next button click handler only once
        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners();  // clear any existing listeners
            nextButton.onClick.AddListener(ShowDialogue);  // show next line on button click
        }

        ShowDialogue();  // display the first dialogue line when dialogue starts
    }

    // displays the current dialogue line
    public void ShowDialogue()
    {
        if (dialogueLines.HasNextLine(currentLine))
        {
            string formattedLine = dialogueLines[currentLine].FormatDialogue(playerName);  // format text with playerName
            if (dialogueText != null)
            {
                dialogueText.text = formattedLine;  // display formatted dialogue text
            }

            // check if it's the second line to instantiate the cube
            if (currentLine == 1) // 2nd line, since index starts at 0
            {
                objectInstantiator.InstantiateObject(); // instantiate the cube
            }

            currentLine++;  // move to the next dialogue line after displaying the current one
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