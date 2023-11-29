using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public float speed = 2f; // the speeed
    public float moveDownSpeed = 2f; // spped ner den går ner
    public Transform Ship_Main; // Referens till spelarens skepp

    private bool isMovingDown = true;

    void Update()
    {
        if (isMovingDown)
        {
            MoveDown();
        }
        else
        {
            // Kontrollera om fienden är synlig och rör dig mot spelarens skepp
            if (IsVisible())
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector2.down * moveDownSpeed * Time.deltaTime);

        // om enemy är synlig slutar den gå ner
        if (IsVisible())
        {
            isMovingDown = false;
        }
    }

    void MoveTowardsPlayer()
    {
        if (Ship_Main != null)
        {
            // Beräkna riktningen till spelaren
            Vector2 direction = (Ship_Main.position - transform.position).normalized;

            // Flytta fienden mot spelaren
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    bool IsVisible()
    {
        // Kontrollera om fienden är synlig
        Renderer renderer = GetComponent<Renderer>();

        // Kontrollera om renderaren och GameObject båda är aktiva i scenen
        bool isVisible = renderer != null && renderer.isVisible && gameObject.activeSelf;

        // Debug log
        Debug.Log("IsVisible: " + isVisible);

        return isVisible;
    }

    void ResetPosition()
    {
        // Återställ fiendens position ovanför kameran
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float cameraHeight = 2f * mainCamera.orthographicSize;
            transform.position = new Vector2(transform.position.x, mainCamera.transform.position.y + cameraHeight);
        }
    }
}