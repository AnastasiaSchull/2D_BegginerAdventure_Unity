using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider healthSlider; 
    [SerializeField] private Player player; 

    private void Start()
    {
        //значения слайдера  устанавливаем
        healthSlider.maxValue = player.MaxHearts;

        healthSlider.value = player.CurrentHearts;
    }

    public void UpdateHealthUI(int currentHealth)
    {
        healthSlider.value = currentHealth; // обновляем слайдер
    }
}

