using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform itemsGrid;

    public static List<List<object>> inventory = new List<List<object>>();

    public GameObject thisUI;

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
        foreach (List<object> obj in inventory)
        {
            if (obj[0].Equals(item.id))
            {
                obj[3] = (int)obj[1] + amount;
                return;
            }
        }

        inventory.Add(newItem);
    }

    public static void AddEquipmentItem(Equipment equip)
    {
        List<object> newEquipment = new List<object> { equip.id, equip.slot, equip.rarity, equip.innateStats, equip.generatedStats, equip.GetTotalStats() };
        if(inventory.Count < 25)
        {
            inventory.Add(newEquipment);
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
                itemsGrid.GetChild(i).gameObject.SetActive(true);
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
