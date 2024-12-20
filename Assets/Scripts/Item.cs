using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item", fileName = "ItemData")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public float Price;
    public Rarity rarity;
    public AudioClip collectSound; // звук для предмета

    public enum Rarity
    {
        Common,
        Rare,
        Legendary,
        Epic
    }
}
