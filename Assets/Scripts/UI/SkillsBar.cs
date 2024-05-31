using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsBar : MonoBehaviour
{

    public List<GameObject> images;

    public List<Skill> allSkills;
    readonly int[] spacings = new int[] { 30, 33, 35, 36 };
    public GridLayoutGroup icons;
    public RectTransform background;
    public RectTransform skillsParent;

    void Awake()
    {
        AssignSkillIcons();
    }

    public void AssignSkillIcons()
    {
        int skills = PlayerStats.maxSkills;
        Debug.Log("ASSIGNSKILLICONS");
        int addWidth = (skills - 4) * 135;
        if (skills >= 5)
        {
            background.sizeDelta = new Vector2(450 + 115 * (skills - 4), 100);
            skillsParent.sizeDelta = new Vector2(450 + addWidth, 100);

            icons.spacing = new Vector2(spacings[skills - 5], icons.spacing.y);
        }
        for (int i = 0; i < skills; i++)
        {
            images[i].SetActive(true);
        }


        for(int i = 0; i < PlayerData.currentSkills.Count; i++)
        {
            foreach (Skill skill in allSkills)
            {
                string skillName = skill.name;
                string currentSkillName = PlayerData.currentSkills[i];
                if (skillName.Equals(currentSkillName))
                {
                    Image image = images[i].GetComponentInParent<Image>();
                    image.sprite = skill.icon;
                    image.color = Color.white;
                    break;
                }
            }
        }
    }

    
}
