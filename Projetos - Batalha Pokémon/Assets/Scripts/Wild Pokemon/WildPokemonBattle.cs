using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WildPokemonBattle : MonoBehaviour
{
    public static WildPokemonBattle instance;

    public Coroutine attackTurn;

    public string[] moves = new string[4];
    public int[] damage = new int[4];

    public int randomMove;

    public TMP_Text dialog;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    void UseMove()
    {
        if (randomMove == 1)
        {
            dialog.text = "BULBASAUR used " + moves[0] + "!";
        }

        if (randomMove == 2)
        {
            dialog.text = "BULBASAUR used " + moves[1] + "!";
        }

        if (randomMove == 3)
        {
            dialog.text = "BULBASAUR used " + moves[2] + "!";
        }

        if (randomMove == 4)
        {
            dialog.text = "BULBASAUR used " + moves[3] + "!";
        }
    }

    public IEnumerator WaitAttackEnds()
    {
        if (GameController.instance.turn == 2)
        {
            randomMove = Random.Range(1, 5);

            UseMove();
            HPBar.instance.TakeDamage();

            yield return new WaitForSeconds(2);
        }

        GameController.instance.turn = 1;
    }
}