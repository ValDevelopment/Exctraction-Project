using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBehaviour : MonoBehaviour
{
    public int chestRarity;
    public List<Item> items = new();
    public List<Equipment> equipment = new();
    public SpriteRenderer thisSprite;
    public Transform grid;
    bool open;
    Color color;
    // Start is called before the first frame update
    void Awake()
    {
        color = thisSprite.color;
        GenerateLoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateLoot()
    {
        int equipmentNum = Random.Range(0, 3);
        for(int i = 0; i < equipmentNum; i++)
        {
            equipment.Add(GenerateEquipment());
        }



        int itemsNum = Random.Range(1, 5 + chestRarity);
        for(int i = 0; i < itemsNum; i++)
        {
            float chance = Random.Range(0.0f, 1.0f);
            if(chance<0.625f)
            {
                items.Add(GenerateItem(ItemsDataHolder.Instance.uncommon));
            }
            else if (chance >= 0.625f && chance < 0.925f)
            {
                items.Add(GenerateItem(ItemsDataHolder.Instance.rare));
            }
            else if (chance >= 0.925f && chance < 0.975f)
            {
                items.Add(GenerateItem(ItemsDataHolder.Instance.epic));
            }
            else if (chance >= 0.975f && chance < 0.995f)
            {
                items.Add(GenerateItem(ItemsDataHolder.Instance.legendary));
            }
            else if (chance >= 0.995f && chance <= 1.0f)
            {
                items.Add(GenerateItem(ItemsDataHolder.Instance.unique));
            }
        }
    }

    Equipment GenerateEquipment()
    {
        int slot = Random.Range(0, 10);
        List<EquipmentBase> bases = ItemsDataHolder.Instance.GetBase(slot);
        int baseId = 0;
        string id = bases[baseId].baseName;
        int rarity = 0;
        float chance = Random.Range(0.0f, 1.0f);
        if (chance < 0.625f)
        {
            rarity = 0;
        }
        else if (chance >= 0.625f && chance < 0.925f)
        {
            rarity = 1;
        }
        else if (chance >= 0.925f && chance < 0.985f)
        {
            rarity = 2;
        }
        else if (chance >= 0.985f && chance < 0.995f)
        {
            rarity = 3;
        }
        else if (chance >= 0.995f && chance <= 1.0f)
        {
            rarity = 4;
        }
        Equipment equipment = new Equipment(id, slot, rarity, bases[baseId].baseStats, GenerateRandomStats(rarity + 1));
        return equipment;
    }

    Item GenerateItem(List<Item> list)
    {
        int index = Random.Range(0, list.Count);
        Item item = list[index];
        return item;
    }

    List<int> GenerateRandomStats(int numStats)
    {
        List<int> statsIndexes = new();
        for(int i = 0; i < numStats; i++)
        {
            int index = Random.Range(0, 15);
            if (statsIndexes.Contains(index))
            {
                i--;
            } else
            {
                statsIndexes.Add(index);
            }
        }
        List<int> generatedStats = new List<int>(new int[15]);
        foreach(int i in statsIndexes)
        {
            generatedStats[i] = 5;
        }
        return generatedStats;
    }

    void OpenChest()
    {
        open = true;
        grid.parent.gameObject.SetActive(true);
        for (int i = 0; i < equipment.Count; i++)
        {
            foreach (Transform t in grid)
            {
                if (!t.gameObject.activeSelf)
                {
                    EquipmentBase thisBase = ItemsDataHolder.Instance.GetEquipment(equipment[i].slot, equipment[i].id);
                    t.gameObject.SetActive(true);
                    t.GetComponent<Image>().sprite =thisBase.sprite;
                    ItemIconBehaviour icon = t.GetComponent<ItemIconBehaviour>();
                    icon.isEquipment = true;
                    icon.rarity = equipment[i].rarity;
                    icon.equip = equipment[i];
                    icon.innateStats = equipment[i].innateStats;
                    icon.generatedStats = equipment[i].generatedStats;
                    icon.thisChest = this;
                    icon.AssignDescriptionImages();
                    icon.equipBase = thisBase;
                    break;
                }
            }
        }
        for (int i = 0; i < items.Count; i++)
        {
            foreach(Transform t in grid)
            {
                if(!t.gameObject.activeSelf)
                {
                    t.gameObject.SetActive(true);
                    t.GetComponent<Image>().sprite = items[i].icon;
                    ItemIconBehaviour icon = t.GetComponent<ItemIconBehaviour>();
                    icon.isEquipment = false;
                    icon.rarity = items[i].rarity;
                    icon.item = items[i];
                    icon.thisChest = this;
                    icon.AssignDescriptionImages();
                    break;
                }
            }
        }
    }

    public void CloseChest()
    {
        foreach (Transform t in grid)
        {
            t.gameObject.SetActive(false);
        }
        grid.parent.gameObject.SetActive(false);
        open = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!open)
            {
                OpenChest();
            }
            else
            {
                CloseChest();
            }
        }
    }

    private void OnMouseEnter()
    {
        if (CombatManager.Instance.basicAttack.attackMode)
        {
            thisSprite.color = Color.grey;
        }
    }

    private void OnMouseExit()
    {
        if (CombatManager.Instance.basicAttack.attackMode)
        {
            thisSprite.color = color;
        }
    }
}
