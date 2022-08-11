using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    public static HPBar instance;

    public Slider hpBar;
    public RectTransform hpRect;

    public int maxHP;
    public int currentHP;

    public bool defeat;

    void Awake()
    {
        instance = this;
        defeat = false;
    }

    void Start()
    {
        currentHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = maxHP;
    }

    void Update()
    {

    }

    public void HpDamage(int amount)
    {
        if (currentHP - amount >= 1)
        {
            currentHP -= amount;
            hpBar.value = currentHP;
        }

        else
        {
            currentHP = 0;
            hpBar.fillRect.gameObject.SetActive(false);
            defeat = true;
        }
    }

    public void TakeDamage()
    {
        if (!defeat)
        {
            if (WildPokemonBattle.instance.randomMove == 1)
            {
                HpDamage(WildPokemonBattle.instance.damage[0]);
            }

            if (WildPokemonBattle.instance.randomMove == 2)
            {
                HpDamage(WildPokemonBattle.instance.damage[1]);
            }

            if (WildPokemonBattle.instance.randomMove == 3)
            {
                HpDamage(WildPokemonBattle.instance.damage[2]);
            }

            if (WildPokemonBattle.instance.randomMove == 4)
            {
                HpDamage(WildPokemonBattle.instance.damage[3]);
            }
        }

        else
        {
            IsDefeat();
        }
    }

    public void IsDefeat()
    {

    }
}
