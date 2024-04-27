using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TownBuilding : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Outline outline;
    // Start is called before the first frame update
    void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        outline.enabled = false;
    }
}
