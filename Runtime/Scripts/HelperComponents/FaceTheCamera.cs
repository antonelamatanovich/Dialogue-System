/********************************************************************************
 * Script:        FaceTheCamera.cs
 * Author:        Antonela Matanovic
 * Date created:  February 19th, 2025
 * Last modified: February 19th, 2025
 * Description:   Makes the text smoothly face the camera.
 ********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    public Camera targetCamera;  // reference to the camera

    private void LateUpdate()
    {
        if (targetCamera != null)  // check if the target camera is assigned
        {
            transform.LookAt(targetCamera.transform);  // make the text face the camera
            transform.Rotate(0, 180, 0);
        }
    }
}
