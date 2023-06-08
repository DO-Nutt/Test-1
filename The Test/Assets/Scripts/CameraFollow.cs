using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float cameraHeight = 5f; // Desired height of the camera above the player
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the player's position

    private void LateUpdate()
    {
        // Calculate the desired position for the camera with offset and height
        Vector3 desiredPosition = player.position + offset + new Vector3(0f, cameraHeight, 0f);

        // Smoothly move the camera towards the desired position using Lerp
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

        // Set the camera rotation to be directly facing downwards
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }

}
