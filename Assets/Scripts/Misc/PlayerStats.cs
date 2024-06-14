using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static int maxSkills = 4;
    public static int maxHealth = 25;
    public static int maxEnergy = 100;
    public static List<object> currentGear = new List<object>(new object[10]);

    public static List<int> currentStats = new List<int>(new int[15]);





    public static void AddEquipmentItem(string id, int slot, int rarity, List<int> innateStats, List<int> generatedStats)
    {
        List<int> totalStats = new List<int>(new int[15]);
        for (int i = 0; i < 15; i++)
        {
            totalStats[i] = innateStats[i] + generatedStats[i];
        }
        List<object> newEquipment = new List<object> { id, slot, rarity, innateStats, generatedStats, totalStats };
        currentGear[slot] = newEquipment;
    }

    public static bool IsSlotEmpty(int slot)
    {
        return currentGear[slot] == null;
    }
}
