using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text coinText;
    [SerializeField] private PauseMenu pauseMenu;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Transform inventoryBody;
    [SerializeField] private Cell cellPrefab;

    private List<Cell> inventoryList = new List<Cell>();


    private void Awake()
    {
        player.onCoinsChanged += Player_onCoinsChanged;
        player.inventory.onInventoryChanged += Inventory_onInventoryChanged;
    }

    private void Inventory_onInventoryChanged(List<ItemData> list)
    {
        foreach (Cell cell in inventoryList)
        {
            Destroy(cell.gameObject);
        }
        inventoryList.Clear();

        foreach (ItemData itemData in list)
        {
            Cell cell = Instantiate(cellPrefab, inventoryBody);
            cell.img.sprite = itemData.item.Sprite;
            cell.txt.text = itemData.count.ToString();
            inventoryList.Add(cell);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//панель меню
        {
            OpenClosePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.Tab))//при клике на таб откр/закр инвентарная книга
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    private void OnDestroy()
    {
        player.onCoinsChanged -= Player_onCoinsChanged;
    }

    private void Player_onCoinsChanged(float obj)
    {
        coinText.text = obj.ToString();
    }

    public void OpenClosePauseMenu()
    {
        if (!pauseMenu.gameObject.activeSelf)
        {
            pauseMenu.Show();
        }
        else
        {
            pauseMenu.Hide();
        }
    }
}
