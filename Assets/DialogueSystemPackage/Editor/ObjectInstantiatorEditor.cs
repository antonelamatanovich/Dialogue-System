/********************************************************************************
 * Script:        ObjectInstantiatorEditor.cs
 * Author:        Antonela Matanovic
 * Date created:  February 19th, 2025
 * Last modified: February 19th, 2025
 * Description:   Custom editor for ObjectInstantiator component.
 *                Provides a button to instantiate an object from the inspector.
 ********************************************************************************/

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectInstantiator))]
public class ObjectInstantiatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ObjectInstantiator instantiator = (ObjectInstantiator)target;

        // add a button to instantiate an object
        if (GUILayout.Button("Instantiate Object"))
        {
            instantiator.InstantiateObject(); // call the method to instantiate the object
        }
    }
}