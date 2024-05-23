using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonOutlineBlinking : MonoBehaviour
{
    public Outline outline;
    // Start is called before the first frame update

    private void Update()
    {
        if(outline.effectColor.a <= 0.3f)
        {
            outline.effectColor = new Color(0, 0, 0, outline.effectColor.a + 0.1f);
        }
        else if (outline.effectColor.a >= 0.7f)
        {
            outline.effectColor = new Color(0, 0, 0, outline.effectColor.a - 0.1f);
        }
    }
}
