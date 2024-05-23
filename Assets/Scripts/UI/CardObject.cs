using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public bool locked;
    public GameObject lockImage;
    public Class thisClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeLockStatus()
    {
        locked = !locked;
        lockImage.SetActive(locked);
    }
    public void SetLocked()
    {
        locked = true;
        lockImage.SetActive(true);
    }
    public void SetUnocked()
    {
        locked = false;
        lockImage.SetActive(locked);
    }
}
