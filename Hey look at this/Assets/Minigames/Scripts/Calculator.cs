//﻿using System.Collections;
//using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public bool over { get; set; }
    public bool mustRestart { get; set; }


    private Text operation;
    private InputField answer;
    private int expected;
    private int nbr1;
    private int nbr2;
    private int operationType;
    private int input;
    private int nbrSuccess;
    private int requiredSuccess;
    private int difficulty;
    private int MateId;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Dude, help me, what's the answer ?";
        requiredSuccess = 5 * (difficulty + 1);
        nbrSuccess = 0;
        mustRestart = true;
        answer = gameObject.transform.GetChild(2).gameObject.GetComponent<InputField>();
        operation = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    public void Reset(int difficulty, int mateId)
    {
        MateId = mateId;
        Start();
        over = false;
        gameObject.SetActive(true);
        this.difficulty = difficulty;
        SetFocusOnInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (mustRestart)
        {
            operationType = Random.Range(0, 2);
            nbr2 = Random.Range(1, 100);
            nbr1 = Random.Range(1, 100);
            if (operationType == 0)
            {
                operation.text = nbr1.ToString() + " + " + nbr2.ToString();
                expected = nbr1 + nbr2;
            }
            if (operationType == 1)
            {
                operation.text = nbr1.ToString() + " - " + nbr2.ToString();
                expected = nbr1 - nbr2;
            }
            mustRestart = false;
        }

        if (!over && answer.text != "")
        {
            try
            {
                input = int.Parse(answer.text);
            }
            catch (System.FormatException)
            {
                return;
            }
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
            {
                answer.text = "";

                if (input != expected)
                    return;

                // Correct input
                nbrSuccess += 1;
                if (nbrSuccess == requiredSuccess)
                {
                    over = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    mustRestart = true;
                }
            }
        }
        SetFocusOnInputField();
    }

    private void SetFocusOnInputField()
    {
        EventSystem.current.SetSelectedGameObject(answer.gameObject, null);
        answer.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    void OnDisable()
    {
        if (over)
        {
            InitMate mateScript = GameObject.Find("Mate" + MateId.ToString()).GetComponent<InitMate>();
            mateScript.StopBothering();
        }
    }
}
