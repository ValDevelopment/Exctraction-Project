using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectionManager : MonoBehaviour
{


    public int skillsToChoose = 3;

    public GameObject proceedButton;
    private static SkillSelectionManager _instance;
    public static SkillSelectionManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
    }

    public void CheckProceed()
    {
        if (skillsToChoose == 0)
        {
            proceedButton.SetActive(true);
        }
        else
        {
            proceedButton.SetActive(false);
        }
    }
}
