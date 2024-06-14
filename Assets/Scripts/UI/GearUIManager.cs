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
        foreach(GameObject obj in gearIcons)
        {
            obj.SetActive(false);
        }

        foreach(List<object> item in PlayerStats.currentGear)
        {
            if (item != null)
            {
                Image image = gearIcons[(int)item[1]].GetComponent<Image>();
                gearIcons[(int)item[1]].SetActive(true);
                image.sprite = ItemsDataHolder.Instance.GetEquipment((int)item[1], (string)item[0]).sprite;


                ItemIconBehaviour icon = gearIcons[(int)item[1]].GetComponent<ItemIconBehaviour>();
                //Button button = itemsGrid.GetChild(i).GetComponent<Button>();

                    icon.isEquipment = true;

                    icon.rarity = (int)item[2];
                    icon.innateStats = (List<int>)item[3];
                    icon.generatedStats = (List<int>)item[4];
                    icon.equipId = (string)item[0];
                    icon.equipBase = ItemsDataHolder.Instance.GetEquipment((int)item[1], icon.equipId);
                    icon.slot = (int)item[1];
                    //button.onClick.AddListener(icon.Equip);
            }
        }
    }
}
