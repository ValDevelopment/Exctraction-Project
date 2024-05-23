using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsBar : MonoBehaviour
{

    public List<Image> images;

    public List<Skill> allSkills;

    void Awake()
    {
        AssignSkillIcons();
    }

    public void AssignSkillIcons()
    {
        Debug.Log("ASSIGNSKILLICONS");
        for(int i = 0; i < PlayerData.currentSkills.Count; i++)
        {
            foreach (Skill skill in allSkills)
            {
                string skillName = skill.name;
                string currentSkillName = PlayerData.currentSkills[i];
                if (skillName.Equals(currentSkillName))
                {
                    images[i].sprite = skill.icon;
                    images[i].color = Color.white;
                    break;
                }
            }
        }
    }

    
}
