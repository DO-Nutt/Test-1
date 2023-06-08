using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the enemy follows the player

    private Transform target; // Reference to the player's transform

    private void Start()
    {
        // Find the player object with the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Check if the player object was found
        if (target == null)
        {
            Debug.LogWarning("Player not found!");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = target.position - transform.position;

            // Normalize the direction to have a magnitude of 1
            direction.Normalize();

            // Calculate the desired movement amount based on the direction and move speed
            Vector3 movement = direction * moveSpeed * Time.deltaTime;

            // Move the enemy towards the player
            transform.Translate(movement);
        }
    }
}
