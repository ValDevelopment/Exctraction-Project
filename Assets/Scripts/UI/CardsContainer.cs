using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsContainer : MonoBehaviour
{
    public List<Card> cards;

    public Transform cardsGrid;
    public GameObject cardObject;

    public int rerollsLeft = 2;

    public Button proceedButton;

    public GameObject deckObject;
    public GameObject rerollButton;
    public GameObject hotbar;

    public AudioSource sound;

    private void Awake()
    {
        Invoke(nameof(DrawCards), 0.5f);
    }

    private void Update()
    {
        proceedButton.gameObject.SetActive(cardsGrid.childCount>0 && CheckCardsLocked() && rerollsLeft > 0);
    }

    bool CheckCardsLocked()
    {
        foreach(Transform t in cardsGrid)
        {
            if (!t.gameObject.GetComponent<CardObject>().locked)
            {
                return false;
            }
        }
        return true;
    }

    public void EnterSkillSelection()
    {
        deckObject.SetActive(false);
        rerollButton.SetActive(false);
        hotbar.SetActive(true);
        rerollsLeft = 0;
        proceedButton.gameObject.SetActive(false);
        cardsGrid.transform.position = new Vector2(0f, 1f);
        cardsGrid.transform.localScale = new Vector2(1.7f, 1.7f);
        foreach (Transform t in cardsGrid)
        {
            t.gameObject.GetComponent<Button>().enabled = false;
            t.gameObject.GetComponent<CardObject>().SetUnocked();
            t.GetChild(2).gameObject.SetActive(true);
            SetSkillIcons(t.GetChild(2), t.gameObject.GetComponent<CardObject>());
        }
    }

    void SetSkillIcons(Transform t, CardObject card)
    {
        Debug.Log(t.name);
        for(int i = 0; i < 4; i++)
        {
            Transform icon = t.GetChild(i);
            icon.GetComponent<SkillButton>().thisSkill = card.thisClass.classSkills[i];
            icon.GetComponent<Image>().sprite = card.thisClass.classSkills[i].icon;
            icon.name = card.thisClass.classSkills[i].name;
            if (i >= 2)
            {
                icon.GetComponent<Image>().color = Color.grey;
                icon.GetChild(0).gameObject.SetActive(true);
                icon.GetComponent<Button>().enabled = false;
            }
        }
    }

    void DrawCards()
    {
        for(int i = 0; i < 3 - cardsGrid.childCount; i++)
        {
            int index = Random.Range(0, cards.Count);
            Card card = cards[index];
            StartCoroutine(DrawCardDelayed(i, card));
        }
        foreach (Transform t in cardsGrid)
        {
            t.gameObject.GetComponent<Button>().enabled = false;
        }
        Invoke(nameof(CheckLastRerolls), 0.4f);
        
    }

    void CheckLastRerolls()
    {
        Debug.Log(rerollsLeft);
        if (rerollsLeft == 0)
        {
            foreach (Transform t in cardsGrid)
            {
                t.gameObject.GetComponent<Button>().enabled = false;
                t.gameObject.GetComponent<CardObject>().SetLocked();
            }
            EnterSkillSelection();
        }
    }

    void DrawCard(Card card)
    {
        GameObject obj = Instantiate(cardObject, cardsGrid);
        Image objImage = obj.GetComponent<Image>();
        objImage.sprite = card.sprite;
        obj.transform.GetChild(0).GetComponent<Text>().text = card._name;
        obj.GetComponent<CardObject>().thisClass = card.associatedClass;
        sound.Play();
    }

    IEnumerator DrawCardDelayed(int i, Card c)
    {
        yield return new WaitForSeconds(0.1f * i);
        DrawCard(c);
    }

    public void Reroll()
    {
        if (rerollsLeft > 0)
        {
            for (int i = 0; i < cardsGrid.childCount; i++)
            {
                Transform t = cardsGrid.GetChild(i);
                t.gameObject.GetComponent<Button>().enabled = false;
                if (!t.gameObject.GetComponent<CardObject>().locked)
                {
                    Destroy(t.gameObject, 0.1f * i);
                }
                else
                {

                }
            }
            rerollsLeft--;
            Invoke(nameof(DrawCards), 0.8f);
        }
    }
}
