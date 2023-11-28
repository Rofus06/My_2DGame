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
        // Lagra bakgrundens initiala y-position
        initialPosition = transform.position.y;
    }

    void Update()
    {
        // rör sig ner ifrån speeden som gers
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // Kontrollera om bakgrunden är under återställningspositionen
        if (transform.position.y < resetPosition)
        {
            // Flytta bakgrunden till utgångsläget för att skapa en loopeffekt
            transform.position = new Vector2(transform.position.x, initialPosition);
        }
    }
}