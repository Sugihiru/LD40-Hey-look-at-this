using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    private GameObject MinigameWin;

    public enum ActionDuration
    {
        FAST,
        MEDIUM,
        LONG
    };

    public void Start()
    {
        MinigameWin = GameObject.Find("MinigamePanel");
    }

    public void OnFastActionButtonClick(ActionDuration actionDuration)
    {
        MinigameWin.SetActive(true);
        return;
    }


    public void OnActionButtonClick()
    {
        MinigameWin.SetActive(true);
        return;
    }
}
