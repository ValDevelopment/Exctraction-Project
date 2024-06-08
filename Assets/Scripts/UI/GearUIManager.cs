using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearUIManager : MonoBehaviour
{
    public List<GameObject> gearIcons;




    private static GearUIManager _instance;
    public static GearUIManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignEquippedGear()
    {
        foreach(List<object> item in PlayerStats.currentGear)
        {
            if (item != null)
            {
                gearIcons[(int)item[1]].SetActive(true);
            }
        }
    }
}
