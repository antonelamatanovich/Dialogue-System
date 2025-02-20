/********************************************************************************
 * Script:        TransformExtension.cs
 * Author:        Antonela Matanovic
 * Date created:  February 16th, 2025
 * Last modified: February 16th, 2025
 * Description:   Extension methods for the Transform class.
 *                Includes a method to smoothly move a transform to a target position.
 ********************************************************************************/

using UnityEngine;
using System.Collections;

public static class TransformExtension
{
    public static void MoveTo(this Transform transform, Vector3 targetPosition, float duration)
    {
        transform.GetComponent<MonoBehaviour>().StartCoroutine(MoveRoutine(transform, targetPosition, duration));
    }

    private static IEnumerator MoveRoutine(Transform transform, Vector3 target, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }
}
