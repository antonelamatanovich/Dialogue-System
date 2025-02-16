/********************************************************************************
 * Script:        ObjectInstantiator.cs
 * Author:        Antonela Matanovic
 * Date Created:  February 16th, 2025
 * Last Modified: February 16th, 2025
 * Description:   Instantiates an object at a specified position with fixed rotation.
 ********************************************************************************/

using UnityEngine;

public class ObjectInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;  // prefab to instantiate
    [SerializeField] private Transform spawnLocation;  // location to spawn the object (optional)
    [SerializeField] private Vector3 defaultPosition = Vector3.zero;  // default position if no spawn location is provided
    [SerializeField] private float rotationY = -45f;  // fixed rotation on y-axis for the instantiated object

    // instantiates the object at the specified location with fixed rotation
    public void InstantiateObject()
    {
        if (objectToInstantiate == null)
        {
            Debug.LogWarning("object to instantiate is not assigned.");
            return;
        }

        // determine the spawn position
        Vector3 spawnPosition = spawnLocation != null ? spawnLocation.position : defaultPosition;

        // apply fixed rotation on y-axis
        Quaternion fixedRotation = Quaternion.Euler(0f, rotationY, 0f); 

        // instantiate object at spawn position with fixed rotation
        Instantiate(objectToInstantiate, spawnPosition, fixedRotation);  
    }
}
