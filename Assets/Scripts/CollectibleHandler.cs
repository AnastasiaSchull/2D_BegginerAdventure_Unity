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
            // проверяем, есть ли у объекта ItemObject
            ItemObject itemObject = other.GetComponent<ItemObject>();
            if (itemObject != null && itemObject.item.collectSound != null)
            {
                //звук из ItemObject
                audioSource.PlayOneShot(itemObject.item.collectSound);
                Debug.Log($"Collected item: {itemObject.item.Name}");
                Destroy(other.gameObject); 
            }

            else
            {
                //не для айтемобьектов
                audioSource.PlayOneShot(collectSound);
                // Destroy(other.gameObject);
            }
        }
    }
}
