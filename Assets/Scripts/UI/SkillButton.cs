using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public bool chosen;

    public Transform allSiblingButtons;

    public Skill thisSkill;

    public void ChooseSkillButton()
    {
        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("SkillButton");
        foreach(GameObject obj in allButtons)
        {
            SkillButton button = obj.GetComponent<SkillButton>();
            if (obj.name.Equals(name))
            {
                if (!button.chosen)
                {
                    button.ChooseSkill();
                    foreach (Transform t in allSiblingButtons)
                    {
                        if (!t.gameObject.name.Equals(name))
                        {
                            t.GetComponent<Button>().enabled = false;
                            t.GetComponent<Image>().color = Color.grey;
                        }
                    }

                }
                else
                {
                    button.UnchooseSkill();
                    foreach (Transform t in allSiblingButtons)
                    {
                        if (!t.gameObject.name.Equals(name))
                        {
                            t.GetComponent<Button>().enabled = true;
                            if(!t.GetChild(0).gameObject.activeSelf)
                                t.GetComponent<Image>().color = Color.white;
                        }
                    }
                }
            }
        }
        if(!chosen)
        {
            PlayerData.currentSkills.Remove(thisSkill.name);
            SkillSelectionManager.Instance.skillsToChoose++;
        } else
        {
            PlayerData.currentSkills.Add(thisSkill.name);
            SkillSelectionManager.Instance.skillsToChoose--;
        }
        SkillSelectionManager.Instance.CheckProceed();
    }

    public void ChooseSkill()
    {
        chosen = true;
        transform.GetChild(1).gameObject.SetActive(true);

    }

    public void UnchooseSkill()
    {
        chosen = false;
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
