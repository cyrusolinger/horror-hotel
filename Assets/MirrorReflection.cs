using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    private Transform playerCamera; // Reference to the player's camera
    public Transform mirrorSurface; // Reference to the mirror surface

    void Start()
    {
        // Automatically find the player camera by its name
        GameObject cameraGameObject = GameObject.Find("MainCameraBrain");
        if (cameraGameObject != null)
        {
            playerCamera = cameraGameObject.transform;
        }
        else
        {
            Debug.LogError("MainCameraBrain not found in the scene!");
        }
    }

    void Update()
    {
        if (playerCamera == null || mirrorSurface == null)
        {
            // Skip the update if references are not set
            return;
        }

        // Calculate the mirrored position
        Vector3 cameraDirection = playerCamera.position - mirrorSurface.position;
        transform.position = mirrorSurface.position - cameraDirection;

        // Calculate the mirrored rotation
        Vector3 reflectedRotation = Vector3.Reflect(playerCamera.forward, mirrorSurface.forward);
        transform.rotation = Quaternion.LookRotation(reflectedRotation, mirrorSurface.up);
    }
}

