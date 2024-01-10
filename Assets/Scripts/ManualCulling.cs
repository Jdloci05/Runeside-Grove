using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCulling : MonoBehaviour
{
    public Transform[] objectsToCull; // Assign objects to cull in the Inspector

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        FindObjectsWithTag();
    }

    void FindObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ObjectsToCull");

        // Almacena los objetos encontrados con la etiqueta en objectsToCull
        objectsToCull = new Transform[objectsWithTag.Length];
        for (int i = 0; i < objectsWithTag.Length; i++)
        {
            objectsToCull[i] = objectsWithTag[i].transform;
        }
    }

    void Update()
    {
        foreach (Transform objTransform in objectsToCull)
        {
            Vector3 viewportPos = mainCamera.WorldToViewportPoint(objTransform.position);

            float visibilityThreshold = 0.2f; // Umbral de visibilidad (ajústalo según sea necesario)

            if (viewportPos.x < -visibilityThreshold || viewportPos.x > 1 + visibilityThreshold ||
                viewportPos.y < -visibilityThreshold || viewportPos.y > 1 + visibilityThreshold)
            {
                objTransform.gameObject.SetActive(false); // Object is significantly outside of view, deactivate it.
            }
            else
            {
                objTransform.gameObject.SetActive(true); // Object is at least partially inside view, activate it.
            }
        }

    }
}
