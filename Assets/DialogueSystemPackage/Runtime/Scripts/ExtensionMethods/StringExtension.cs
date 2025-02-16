/********************************************************************************
 * Script:        StringExtension.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Extension methods for string manipulation.
 *                Includes a method to format dialogue strings with variables.
 ********************************************************************************/

using System;
using UnityEngine;

public static class StringExtension
{
    // formats dialogue string with player name or other variables
    public static string FormatDialogue(this string dialogue, string playerName)
    {
        return dialogue.Replace("{playerName}", playerName);
    }
}