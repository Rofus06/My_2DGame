using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed

    // Move the bullet upward and destroy it when it goes off-screen
    void Update()
    {
        MoveUp();
        CheckVisibility();
    }

    void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void CheckVisibility()
    {
        // Destroy the bullet when it goes off-screen
        if (!IsVisible())
        {
            Destroy(gameObject);
        }
    }

    bool IsVisible()
    {
        // Check if the bullet is visible by any camera
        Renderer renderer = GetComponent<Renderer>();

        // Check if the renderer and the GameObject are both active in the scene
        return renderer != null && renderer.isVisible && gameObject.activeSelf;
    }
}
