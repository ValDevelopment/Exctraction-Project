using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DungeonTimeManager : MonoBehaviour
{
    public Slider energySlider;
    int currentEnergy = 0;
    // Start is called before the first frame update
    void Awake()
    {
        energySlider.maxValue = PlayerStats.maxEnergy;
        currentEnergy = PlayerStats.maxEnergy;
        energySlider.value = currentEnergy;

    }


    public void ReduceEnergy(int actionPoints)
    {
        currentEnergy -= actionPoints * 2;
        energySlider.value = currentEnergy;
    }
}
