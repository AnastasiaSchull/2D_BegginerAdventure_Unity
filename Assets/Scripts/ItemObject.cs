using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item; // ссылаемся на ScriptableObject

    void OnTriggerEnter2D(Collider2D other)
    {
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
