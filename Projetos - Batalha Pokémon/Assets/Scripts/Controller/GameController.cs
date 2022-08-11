using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool fight;
    public bool run;
    public bool start;
    public int turn;

    public Button bFight;
    public Button bRun;

    public TMP_Text dialog;
    public GameObject bush;
    public GameObject pokemon;

    public int dialogController;

    void Awake()
    {
        instance = this;
        start = true;

        dialogController = 0;
        turn = 0;
    }

    void Start()
    {
        bFight.gameObject.SetActive(false);
        bRun.gameObject.SetActive(false);
    }

    void Update()
    {
        if (DialogueBox.dialogueEnds)
        {
            bFight.gameObject.SetActive(true);
            bRun.gameObject.SetActive(true);
        }

        if (HPBar.instance.defeat)
        {
            turn = 0;

            fight = false;
            run = false;

            bFight.gameObject.SetActive(false);
            bRun.gameObject.SetActive(false);

            dialog.text = "Clefairy is DEFEAT...";
        }

        if (WildPokemonBarHP.instance.defeat)
        {
            turn = 0;

            fight = false;
            run = false;

            bFight.gameObject.SetActive(false);
            bRun.gameObject.SetActive(false);

            dialog.text = "Bulbasaur is DEFEAT. Clefairy wins the battle!";
        }
    }

    public void StartDialogue()
    {
        bush.SetActive(false);
        pokemon.SetActive(true);
    }

    public void FightButton()
    {
        fight = true;
        run = false;

        turn = 1;

        bFight.gameObject.SetActive(false);
        bRun.gameObject.SetActive(false);
    }

    public void RunButton()
    {
        bFight.gameObject.SetActive(false);
        bRun.gameObject.SetActive(false);

        fight = false;
        run = true;

        // Acontece algo aqui...
    }
}
