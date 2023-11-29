using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Main : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float boundaryPadding = 0.5f; // Adjust the padding to keep the ship within bounds
    public GameObject bulletPrefab; // Reference to the Bullet prefab
    void Start()
    {
        
    }


    void Update()
    {
        Move();
        ClampToBounds();
        Shoot();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 newPosition = (Vector2)transform.position + moveDirection * moveSpeed * Time.deltaTime;

        transform.position = newPosition;
    }

    void ClampToBounds()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float cameraHalfHeight = mainCamera.orthographicSize;

            float minX = mainCamera.transform.position.x - cameraHalfWidth + boundaryPadding;
            float maxX = mainCamera.transform.position.x + cameraHalfWidth - boundaryPadding;
            float minY = mainCamera.transform.position.y - cameraHalfHeight + boundaryPadding;
            float maxY = mainCamera.transform.position.y + cameraHalfHeight - boundaryPadding;

            // Clamp the ship's position to stay within the camera bounds
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

            transform.position = new Vector2(clampedX, clampedY);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate a new bullet at the player's position
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}