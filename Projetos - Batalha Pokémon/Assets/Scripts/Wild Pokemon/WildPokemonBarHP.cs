using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WildPokemonBarHP : MonoBehaviour
{
    public static WildPokemonBarHP instance;

    public Slider hpBar;
    public RectTransform hpRect;

    public int maxHP;
    public int currentHP;

    public bool defeat;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = maxHP;
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

    public void WildPokemonTakeDamage()
    {
        if (Moves.instance.movesNumber == 1)
        {
            HpDamage(Moves.instance.damage[0]);
        }

        if (Moves.instance.movesNumber == 2)
        {
            HpDamage(Moves.instance.damage[1]);
        }

        if (Moves.instance.movesNumber == 3)
        {
            HpDamage(Moves.instance.damage[2]);
        }

        if (Moves.instance.movesNumber == 4)
        {
            HpDamage(Moves.instance.damage[3]);
        }
    }
}
