using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item; // ссылаемся на ScriptableObject

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collision detected with: {other.name}");

        Debug.Log("Player tag detected");
        
        //if (item.collectSound != null)
        //{
        //    AudioSource.PlayClipAtPoint(item.collectSound, transform.position);
        //    Debug.Log("Sound played");
        if (item.healthValue == 3)
        {
            Player player = other.GetComponent<Player>();

            Debug.Log($"Adding {item.healthValue} hearts to player.");
            player.AddHearts(item.healthValue);
        }
        // проверка на тег 
        if (other.CompareTag("Player"))
        {
            //если есть звук у item, проиграть его
            if (item.collectSound != null)
            {
                AudioSource.PlayClipAtPoint(item.collectSound, transform.position);
            }
        }
    }
}
