/********************************************************************************
 * Script:        TransformExtension.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Extension methods for the Transform class.
 *                Includes a method to smoothly move a transform to a target position.
 ********************************************************************************/

using System;
using UnityEngine;

public static class TransformExtension
{
    // smoothly moves a transform to a target position over time
    public static void MoveTo(this Transform transform, Vector3 target, float duration)
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime / duration);
    }
}