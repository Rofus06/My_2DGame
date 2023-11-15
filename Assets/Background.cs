using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float resetPosition = -10f;

    private float initialPosition;

    void Start()
    {
        // Store the initial y-position of the background
        initialPosition = transform.position.y;
    }

    void Update()
    {
        // Move the background downward based on the scrollSpeed
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // Check if the background is below the reset position
        if (transform.position.y < resetPosition)
        {
            // Move the background to the initial position to create a looping effect
            transform.position = new Vector2(transform.position.x, initialPosition);
        }
    }
}