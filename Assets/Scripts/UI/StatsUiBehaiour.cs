using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUiBehaiour : MonoBehaviour
{
    public List<Text> statTexts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayStats()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i != 4)
            {
                statTexts[i].text = PlayerStats.currentStats[i] + ItemsDataHolder.Instance.statNames[i];
            }
            else
            {
                statTexts[1].text = (PlayerStats.currentStats[1] + PlayerStats.currentStats[i]) + ItemsDataHolder.Instance.statNames[1];
                statTexts[2].text = (PlayerStats.currentStats[2] + PlayerStats.currentStats[i]) + ItemsDataHolder.Instance.statNames[2];
                statTexts[3].text = (PlayerStats.currentStats[3] + PlayerStats.currentStats[i]) + ItemsDataHolder.Instance.statNames[3];
            }
        }
    }
}
