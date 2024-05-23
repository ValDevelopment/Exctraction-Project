
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) transition.gameObject.SetActive(false);
    }
    public void LoadNextLevel(string name)
    {

        StartCoroutine(LoadLevel((name)));
    }

    IEnumerator LoadLevel(string name)
    {
        FadeOut();
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadSceneAsync(name);
    }

    public void FadeOut()
    {
        transition.SetTrigger("Start");
    }

    public void FadeBoth()
    {
        transition.SetTrigger("Start");
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("End");
    }


}
