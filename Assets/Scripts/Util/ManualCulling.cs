using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCulling : MonoBehaviour
{
    #region Variables
    public Transform[] objectsToCull; // Assign objects to cull in the Inspector

    private Camera mainCamera;

    #endregion

    #region Methods
    void Start()
    {
        mainCamera = Camera.main;        
    }

    void FindObjectsWithTag()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ObjectsToCull");

        // Store the found objects with the tag in objectsToCull
        objectsToCull = new Transform[objectsWithTag.Length];
        for (int i = 0; i < objectsWithTag.Length; i++)
        {
            objectsToCull[i] = objectsWithTag[i].transform;
        }
    }

    void Update()
    {
        FindObjectsWithTag();

        foreach (Transform objTransform in objectsToCull)
        {
            Vector3 viewportPos = mainCamera.WorldToViewportPoint(objTransform.position);

            float visibilityThreshold = 0.2f; // Visibility threshold (adjust as needed)

            SpriteRenderer spriteRenderer = objTransform.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (viewportPos.x < -visibilityThreshold || viewportPos.x > 1 + visibilityThreshold ||
                    viewportPos.y < -visibilityThreshold || viewportPos.y > 1 + visibilityThreshold)
                {
                    spriteRenderer.enabled = false; // SpriteRenderer is significantly outside of view, disable it.
                }
                else
                {
                    spriteRenderer.enabled = true; // SpriteRenderer is at least partially inside view, enable it.
                }
            }
            else
            {
                Debug.LogWarning("SpriteRenderer not found on object with tag 'ObjectsToCull'.");
            }
        }
    }

    #endregion
}

