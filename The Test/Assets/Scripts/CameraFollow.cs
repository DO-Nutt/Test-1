using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the player's position

    private void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera towards the desired position using Lerp
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
    }
}
