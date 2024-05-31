using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private static PlayerHP _instance;
    public static PlayerHP Instance { get { return _instance; } }

    public Slider hpSlider;
    public Slider hpSliderWhite;
    public int currentHealth;

    void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        currentHealth = PlayerStats.maxHealth;
        hpSliderWhite.minValue = 0;
        hpSliderWhite.maxValue = PlayerStats.maxHealth;
        hpSliderWhite.value = currentHealth;
        hpSlider.minValue = 0;
        hpSlider.maxValue = PlayerStats.maxHealth;
        hpSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth - damage > 0)
        {
            currentHealth -= damage;
            hpSlider.value = currentHealth;
        } else
        {
            currentHealth = 0;
        }
        Invoke("Erase", 0.5f);
    }

    void Erase()
    {
        hpSliderWhite.value = currentHealth;
    }

    public void RecoverHealth()
    {

    }

    public void GainShield()
    {

    }
}
