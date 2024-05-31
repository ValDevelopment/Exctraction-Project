using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemIconBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform equipmentDescriptions;
    public Transform itemDescription;
    public int index;
    public Transform thisEquipDesc;
    public Transform thisItemDesc;
    public bool isEquipment;
    public int rarity;
    public Equipment equip;

    public EquipmentBase equipBase;
    public Item item;
    Button thisButton;
    public ChestBehaviour thisChest;

    public List<int> innateStats;
    public List<int> generatedStats;
    // Start is called before the first frame update
    void Awake()
    {
        AssignDescriptionImages();
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(Loot);
    }


    public void AssignDescriptionImages()
    {
        index = transform.GetSiblingIndex();
        thisEquipDesc = equipmentDescriptions.GetChild(index);
        thisItemDesc = itemDescription.GetChild(index);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (isEquipment)
        {
            thisEquipDesc.gameObject.SetActive(true);
            Image image = thisEquipDesc.GetChild(0).gameObject.GetComponent<Image>();
            Color color = ItemsDataHolder.Instance.rarityColors[rarity];
            image.color = new Color(color.r, color.g, color.b, image.color.a);
            thisEquipDesc.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().color = ItemsDataHolder.Instance.rarityColors[rarity];
            //thisEquipDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().color = ItemsDataHolder.Instance.rarityColors[rarity];
            thisEquipDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().color = Color.white;
            thisEquipDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = equip.id;
            ItemDescriptionWindow thisWindow = thisEquipDesc.GetComponent<ItemDescriptionWindow>();
            thisWindow.AssignArmourTexts(innateStats, generatedStats, equipBase);
        }
        else
        {
            thisItemDesc.gameObject.SetActive(true);
            Image image = thisItemDesc.GetChild(0).gameObject.GetComponent<Image>();
            Color color = ItemsDataHolder.Instance.rarityColors[rarity];
            image.color = new Color(color.r, color.g, color.b, image.color.a);
            thisItemDesc.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().color = ItemsDataHolder.Instance.rarityColors[rarity];
            //thisItemDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().color = ItemsDataHolder.Instance.rarityColors[rarity];
            thisItemDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().color = Color.white;
            thisItemDesc.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = item.name;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        thisEquipDesc.gameObject.SetActive(false);
        thisItemDesc.gameObject.SetActive(false);
    }
    public void Loot()
    {
        if(equip != null)
        {
            thisChest.equipment.Remove(equip);
        }
        if(item != null)
        {
            thisChest.items.Remove(item);
        }
        thisEquipDesc.gameObject.SetActive(false);
        thisItemDesc.gameObject.SetActive(false);
        gameObject.SetActive(false);
        foreach(Transform t in transform.parent)
        {
            ItemIconBehaviour icon = t.GetComponent<ItemIconBehaviour>();
            if(icon.index != 0 && icon.index > index)
                icon.index--;
            icon.thisEquipDesc = equipmentDescriptions.GetChild(icon.index);
            icon.thisItemDesc = itemDescription.GetChild(icon.index);
        }
        if(isEquipment)
        {
            Inventory.AddEquipmentItem(equip);
        }
        else
        {
            Inventory.AddItem(item, 1);
        }
    }
}
