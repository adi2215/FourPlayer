using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoving : MonoBehaviour
{
    public float speed = 3f;
    public float changeDirectionInterval = 0.5f; // Time interval to change direction

    private float timeSinceLastDirectionChange;

    private Vector3 randomDirection = Vector2.zero;

    void Start()
    {
        // Initialize the timer
        timeSinceLastDirectionChange = changeDirectionInterval;
    }

    void Update()
    {
        // Update the timer and change direction if needed
        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
        }

        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Get the current position of the enemy
        Vector3 currentPosition = transform.position;

        // Update the current position based on the random direction and speed
        currentPosition += randomDirection * speed * Time.deltaTime;

        // Apply the new position to the enemy
        transform.position = currentPosition;
    }

    void ChangeDirection()
    {
        // Reset the timer
        timeSinceLastDirectionChange = 0f;

        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }
}
