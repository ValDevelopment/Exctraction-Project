using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDataHolder : MonoBehaviour
{
    [Header("Chest Items")]
    public List<Sprite> chestSprites;
    public List<Item> uncommon;
    public List<Item> rare;
    public List<Item> epic;
    public List<Item> legendary;
    public List<Item> unique;


    [Header("Equipment Bases")]
    public List<EquipmentBase> helmets;
    public List<EquipmentBase> chests;
    public List<EquipmentBase> pants;
    public List<EquipmentBase> feet;
    public List<EquipmentBase> gloves;
    public List<EquipmentBase> necks;
    public List<EquipmentBase> rings;
    public List<EquipmentBase> mainHand;
    public List<EquipmentBase> offHand;

    [Header("Misc")]
    public List<Color> rarityColors;
    public List<string> statNames;


    private static ItemsDataHolder _instance;
    public static ItemsDataHolder Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    public List<EquipmentBase> GetBase(int slot)
    {
        List<List<EquipmentBase>> allBases = new() {helmets, chests, pants, feet,gloves,necks,rings,mainHand,offHand};
        return allBases[slot];
    }

    public EquipmentBase GetEquipment(int slot, string name)
    {
        List<List<EquipmentBase>> allBases = new() { helmets, chests, pants, feet, gloves, necks, rings, mainHand, offHand };
        foreach(EquipmentBase b in allBases[slot])
        {
            if (b.baseName.Equals(name))
            {
                return b;
            }
        }
        return null;
    }
}
