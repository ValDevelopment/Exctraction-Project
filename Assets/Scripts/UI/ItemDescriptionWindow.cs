using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionWindow : MonoBehaviour
{
    public List<Text> innateStats;
    public List<Text> generatedStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignArmourTexts(List<int> innateStats, List<int> generatedStats, EquipmentBase thisBase)
    {
        int innateStatsNum  = 0;
        foreach(int stat in thisBase.baseStats)
        {
            if(stat != 0)
            {
                innateStatsNum++;
            }
        }

        int textIndex = 0;
        for (int i = 0; i < innateStats.Count; i++)
        {
            if (textIndex < innateStatsNum)
            {
                if (innateStats[i] != 0)
                {
                    this.innateStats[textIndex].gameObject.SetActive(true);
                    this.innateStats[textIndex].text = innateStats[i] + "" + ItemsDataHolder.Instance.statNames[i];
                    textIndex++;
                }

            }
        }

        int genStatsNum = 0;
        foreach(int stat in generatedStats)
        {
            if(stat != 0)
            {
                genStatsNum++;
            }
        }

        int genTextIndex = 0;
        for(int i = 0; i<generatedStats.Count; i++)
        {
            if(genTextIndex < genStatsNum)
            {
                if (generatedStats[i] != 0)
                {
                    this.generatedStats[genTextIndex].gameObject.SetActive(true);
                    this.generatedStats[genTextIndex].text = generatedStats[i] + "" + ItemsDataHolder.Instance.statNames[i];
                    genTextIndex++;
                }
            }
        }
    }

}
