using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Moves : MonoBehaviour
{
    public static Moves instance;

    public TMP_Text dialogText;

    public Button[] moves = new Button[4];
    public TMP_Text[] ppMoves = new TMP_Text[4];
    public string[] moveName = new string[4];

    public int[] maxPP = new int[4];
    public int[] currentPP = new int[4];
    public int[] damage = new int[4];

    public int movesNumber;

    public GameObject buttonsController;

    void Awake()
    {
        instance = this;
        movesNumber = 0;

        buttonsController.SetActive(false);
    }

    void Start()
    {
        currentPP[0] = maxPP[0];
        currentPP[1] = maxPP[1];
        currentPP[2] = maxPP[2];
        currentPP[3] = maxPP[3];

        ppMoves[0].text = "PP " + currentPP[0] + "/" + maxPP[0];
        ppMoves[1].text = "PP " + currentPP[1] + "/" + maxPP[1];
        ppMoves[2].text = "PP " + currentPP[2] + "/" + maxPP[2];
        ppMoves[3].text = "PP " + currentPP[3] + "/" + maxPP[3];
    }

    void Update()
    {
        if (GameController.instance.fight && GameController.instance.turn == 1)
        {
            buttonsController.SetActive(true);
        }

        else
        {
            buttonsController.SetActive(false);
        }
    }

    public void Move01()
    {
        movesNumber = 1;
        currentPP[0]--;

        ppMoves[0].text = "PP " + currentPP[0] + "/" + maxPP[0];

        StartCoroutine(ShowAttackName());
    }

    public void Move02()
    {
        movesNumber = 2;
        currentPP[1]--;

        ppMoves[1].text = "PP " + currentPP[1] + "/" + maxPP[1];

        StartCoroutine(ShowAttackName());
    }

    public void Move03()
    {
        movesNumber = 3;
        currentPP[2]--;

        ppMoves[2].text = "PP " + currentPP[2] + "/" + maxPP[2];

        StartCoroutine(ShowAttackName());
    }

    public void Move04()
    {
        movesNumber = 4;
        currentPP[3]--;

        ppMoves[3].text = "PP " + currentPP[3] + "/" + maxPP[3];

        StartCoroutine(ShowAttackName());
    }

    public IEnumerator ShowAttackName()
    {
        if (movesNumber == 1)
        {
            dialogText.text = "CLEFAIRY used " + moveName[0] + "!";
        }

        if (movesNumber == 2)
        {
            dialogText.text = "CLEFAIRY used " + moveName[1] + "!";
        }

        if (movesNumber == 3)
        {
            dialogText.text = "CLEFAIRY used " + moveName[2] + "!";
        }

        if (movesNumber == 4)
        {
            dialogText.text = "CLEFAIRY used " + moveName[3] + "!";
        }

        GameController.instance.turn = 2;
        yield return new WaitForSeconds(2);

        StartCoroutine(WildPokemonBattle.instance.WaitAttackEnds());
    }
}
