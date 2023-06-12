using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the enemy follows the player
    private Transform target; // Reference to the player's transform
    public int maxHealth = 100; // Maximum health of the enemy
    public int currentHealth; // Current health of the enemy

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum value

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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the current health by the damage amount

        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if the enemy's health reaches zero or below
        }
    }

    private void Die()
    {
        // Perform any necessary death actions (e.g., play death animation, spawn particles, etc.)

        Destroy(gameObject); // Destroy the enemy game object
    }
}
