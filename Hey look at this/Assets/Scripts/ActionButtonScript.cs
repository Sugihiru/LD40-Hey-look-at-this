using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    private GameObject TypingGameWin;

    public enum ActionDuration
    {
        FAST,
        MEDIUM,
        LONG
    };

    public void Start()
    {
        TypingGameWin = GameObject.Find("Canvas/TypingGameWindow");
    }

    public void OnFastActionButtonClick(ActionDuration actionDuration)
    {
        TypingGameWin.SetActive(true);
        return;
    }


    public void OnActionButtonClick()
    {
        TypingGameWin.SetActive(true);
        return;
    }
}
