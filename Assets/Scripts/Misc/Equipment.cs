using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public string id;
    public int slot;
    public int rarity;

    public List<int> innateStats;
    public List<int> generatedStats;

    List<int> totalStats = new List<int>(new int[15]);
    public Equipment(string id, int slot, int r, List<int> innate, List<int> generated)
    {
        this.slot = slot;
        this.id = id;
        rarity = r;
        innateStats = innate;
        generatedStats = generated;
        for(int i = 0; i < 15; i++)
        {
            totalStats[i] = innateStats[i] + generatedStats[i];
        }
    }

    public List<int> GetTotalStats()
    {
        return totalStats;
    }
}
