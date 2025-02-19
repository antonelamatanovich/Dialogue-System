/********************************************************************************
 * Script:        DialogueExtensions.cs
 * Author:        Antonela Matanović
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Provides utility methods for handling dialogue logic, such as 
 *                checking if more lines are available
 ********************************************************************************/

public static class DialogueExtensions
{
    // checks if there is another dialogue line available
    public static bool HasNextLine(this string[] dialogueLines, int currentLine)
    {
        return currentLine < dialogueLines.Length;
    }
}   
