using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{
    public AudioClip collectSound; // файл аудио
    private AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            // добавляем так AudioSource компонент, или в инспекторе
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // проверка на  тег Collectible
        if (other.CompareTag("Collectible"))
        {
            //звук 
            audioSource.PlayOneShot(collectSound);
            // Destroy(other.gameObject);
        }
    }
}

