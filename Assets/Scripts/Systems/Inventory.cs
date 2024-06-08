using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform itemsGrid;

    public static List<List<object>> inventory = new List<List<object>>(new List<object>[25]);

    public GameObject thisUI;

    public ItemsDataHolder itemData;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            thisUI.SetActive(!thisUI.activeSelf);
            OnInventoryOpen();
        }
    }

    public static void AddItem(Item item, int amount)
    {
        List<object> newItem = new List<object> { item.id, item.sellingPrice, item.rarity, amount};

        if (item.stackable)
        {
            foreach (List<object> obj in inventory)
            {
                if (obj[0].Equals(item.id))
                {
                    obj[3] = (int)obj[1] + amount;
                    return;
                }
            }
        }

        for (int i = 0; i < 25; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = newItem;
                return;
            }
        }
    }

    public static bool IsInventoryFull()
    {
        foreach(List<object> item in inventory)
        {
            if(item == null)
            {
                return false;
            }
        }
        return true;
    }

    public static void AddEquipmentItem(Equipment equip)
    {
        List<object> newEquipment = new List<object> { equip.id, equip.slot, equip.rarity, equip.innateStats, equip.generatedStats, equip.GetTotalStats()};

        for (int i = 0; i < 25; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = newEquipment;
                return;
            }
        }
    }

    public static void AddEquipmentItem(string id, int slot, int rarity, List<int> innateStats, List<int> generatedStats)
    {
        List<int> totalStats = new();
        for(int i = 0; i < 15; i++)
        {
            totalStats[i] = innateStats[i] + generatedStats[i];
        }
        List<object> newEquipment = new List<object> { id, slot, rarity, innateStats, generatedStats, totalStats};
        for(int i = 0; i <25; i++)
        {
            if(inventory[i] == null)
            {
                inventory[i] = newEquipment;
                return;
            }
        }
        
    }

    public void OnInventoryOpen()
    {
        foreach(Transform t in itemsGrid)
        {
            t.gameObject.SetActive(false);
        }
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i] != null)
            {
                Image image = itemsGrid.GetChild(i).GetComponent<Image>();
                ItemIconBehaviour icon = itemsGrid.GetChild(i).GetComponent<ItemIconBehaviour>();
                Button button = itemsGrid.GetChild(i).GetComponent<Button>();
                itemsGrid.GetChild(i).gameObject.SetActive(true);
                if (inventory[i].Count > 4)
                {
                    image.sprite = itemData.GetEquipment((int)inventory[i][1], (string)inventory[i][0]).sprite;
                    icon.isEquipment = true;

                    icon.rarity = (int)inventory[i][2];
                    icon.innateStats = (List<int>)inventory[i][3];
                    icon.generatedStats = (List<int>)inventory[i][4];
                    icon.equipId = (string)inventory[i][0];
                    icon.equipBase = ItemsDataHolder.Instance.GetEquipment((int)inventory[i][1], icon.equipId);
                    icon.slot = (int)inventory[i][1];
                    icon.inventoryIndex = i;
                    button.onClick.AddListener(icon.Equip);
                }
                else
                {
                    button.enabled = false;
                    image.sprite = itemData.GetItem((string)inventory[i][0], (int)inventory[i][2]).icon;
                }
            }
        }
    }

    /*
     * 
    public string id;
    public int slot;
    public int rarity;

    public List<int> innateStats;
    public List<int> generatedStats;

    List<int> totalStats = new List<int>(new int[15]);
    */
}
