using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string id;
    public Sprite icon;
    public int sellingPrice;
    public int purchasePrice;
    public int rarity;
    public bool stackable;
}
