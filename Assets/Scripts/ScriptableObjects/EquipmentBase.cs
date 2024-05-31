using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Base", menuName = "Base")]
public class EquipmentBase : ScriptableObject
{
    public Sprite sprite;
    public int slot;
    public string baseName;
    public bool twoHand;
    public List<int> baseStats = new();
}
