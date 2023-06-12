using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileOffset = 1f; // Offset distance for projectile spawn position

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shoots a projectile with left click
        if (Input.GetMouseButtonDown(0))
        {
            shootProjectile();
        }

        //Constalty checks to rotate player based on cursor position
        RotatePlayerTowardsMouse();

        // Get input axes for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize the movement vector to ensure constant speed regardless of direction
        movement.Normalize();

        // Apply movement with speed to the player's position
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void shootProjectile()
    {
        // Calculate the spawn position for the projectile with offset
        Vector3 spawnPosition = transform.position + transform.forward * projectileOffset;

        // Instantiate the projectile at the spawn position
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);

        // Get the Rigidbody component of the projectile
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Apply a force to the projectile in the forward direction
        projectileRigidbody.velocity = transform.forward * projectileSpeed;

        // Destroy the projectile after a certain amount of time
        Destroy(projectile, 3f);
    }

    private void RotatePlayerTowardsMouse()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePositionScreen = Input.mousePosition;

        // Convert the screen coordinates to world coordinates
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, transform.position.z));

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mousePositionWorld - transform.position;
        direction.y = 0f; // Ensure the player doesn't tilt up or down

        // Rotate the player to face the direction
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
