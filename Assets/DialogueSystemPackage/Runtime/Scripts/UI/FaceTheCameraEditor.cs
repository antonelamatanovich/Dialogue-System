/********************************************************************************
 * Script:        FaceTheCameraEditor.cs
 * Author:        Antonela Matanovic
 * Date created:  February 19th, 2025
 * Last modified: February 19th, 2025
 * Description:   Custom editor for FaceTheCamera component.
 *                Allows enabling / disabling the camera-facing rotation in the inspector.
 ********************************************************************************/

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FaceTheCamera))]
public class FaceTheCameraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FaceTheCamera faceTheCamera = (FaceTheCamera)target;

        // draw default inspector fields
        DrawDefaultInspector();

        // add a toggle for enabling / disabling the rotation
        faceTheCamera.enabled = EditorGUILayout.Toggle("Enable Face Camera", faceTheCamera.enabled);
    }
}