using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    public GameObject MinigameWin;

    public enum ActionDuration
    {
        FAST,
        MEDIUM,
        LONG
    };

    public void Start()
    {
    }

    public void OnFastActionButtonClick()
    {
        StartMinigame(ActionDuration.FAST);
    }


    public void OnActionButtonClick()
    {
        MinigameWin.SetActive(true);
        return;
    }

    private void StartMinigame(ActionDuration actionDuration)
    {
        Calculator calc = MinigameWin.transform.GetChild(0).GetComponent<Calculator>();
        calc.over = false;
        calc.mustRestart = true;
        MinigameWin.SetActive(true);
    }
}
