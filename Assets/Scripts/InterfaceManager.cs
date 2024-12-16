using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    
    [SerializeField] private Player player;
    [SerializeField] private Text coinText;


    private void Awake()
    {
        player.onCoinsChanged += Player_onCoinsChanged;//подписываемся на событие 
    }

    private void OnDestroy()
    {
        player.onCoinsChanged -= Player_onCoinsChanged;//отписываемся
    }

    private void Player_onCoinsChanged(float obj)
    {
        coinText.text = obj.ToString();
    }
}
