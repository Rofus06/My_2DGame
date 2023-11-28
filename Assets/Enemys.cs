using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public float speed = 2f; // the speeed
    public Transform Ship_Main; // Referens till spelarens skepp

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Kontrollera om fienden är synlig och rör dig mot spelarens skepp
        if (IsVisible())
        {
            MoveTowardsPlayer();
        }
    }


    void MoveTowardsPlayer()
    {
        if (Ship_Main != null)
        {
            // Calculate the direction to the player's ship
            Vector2 direction = (Ship_Main.position - transform.position).normalized;

            // Move the enemy towards the player's ship
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    bool IsVisible()
    {
        // Check if the enemy is visible by any camera
        Renderer renderer = GetComponent<Renderer>();

        // Check if the renderer and the GameObject are both active in the scene
        bool isVisible = renderer != null && renderer.isVisible && gameObject.activeSelf;

        // Debug log
        Debug.Log("IsVisible: " + isVisible);

        return isVisible;
    }


    void ResetPosition()
    {
        // Reset the enemy's position above the camera
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float cameraHeight = 2f * mainCamera.orthographicSize;
            transform.position = new Vector2(transform.position.x, mainCamera.transform.position.y + cameraHeight);
        }
    }
}
