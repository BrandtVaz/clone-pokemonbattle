using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static bool dialogueEnds;

    [TextArea(3, 10)]
    public string[] sentences;

    public TMP_Text dialogBox;
    public Button bContinue;

    void Awake()
    {
        dialogueEnds = false;
    }

    void Start()
    {
        dialogBox.text = sentences[GameController.instance.dialogController].ToString();
    }

    public void Dialogue()
    {
        if (GameController.instance.dialogController >= sentences.Length)
        {
            bContinue.gameObject.SetActive(false);

            dialogueEnds = true;
        }

        else
        {
            dialogBox.text = sentences[GameController.instance.dialogController].ToString();
            GameController.instance.dialogController = GameController.instance.dialogController + 1;
        }
    }
}
