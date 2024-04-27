using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsStart : MonoBehaviour
{
    public GameObject[] buttons;
    public AudioSource buttonAudio;
    // Start is called before the first frame update
    void Awake()
    {
        ActivateButtons();
    }

    void ActivateButtons()
    {
        for(int i = 0; i < 4; i++)
        {
            StartCoroutine(ActivateButton(buttons[i], i));
        }
    }

    IEnumerator ActivateButton(GameObject button, int i)
    {
        yield return new WaitForSeconds(0.3f * i + 0.1f);
        buttonAudio.Play();
        button.SetActive(true);
    }
}
