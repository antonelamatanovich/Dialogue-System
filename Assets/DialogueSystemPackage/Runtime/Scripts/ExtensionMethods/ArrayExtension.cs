/********************************************************************************
 * Script:        ArrayExtension.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Extension methods for arrays.
 *                Includes a method to shuffle an array randomly.
 ********************************************************************************/

using System;
using UnityEngine;

public static class ArrayExtension
{
    // shuffles an array randomly
    public static void Shuffle<T>(this T[] array)
    {
        System.Random rand = new System.Random();  // use System.Random
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}