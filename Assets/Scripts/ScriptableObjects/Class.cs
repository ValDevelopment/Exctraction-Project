using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class", menuName = "Class")]
public class Class : ScriptableObject
{
    public List<Skill> classSkills;
}
