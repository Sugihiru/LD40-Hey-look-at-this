using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    public GameObject MinigameWin;

    private Calculator calcMinigame;
    private Typer typerMinigame;

    public enum ActionDuration
    {
        FAST,
        MEDIUM,
        LONG
    };

    public void Start()
    {
        calcMinigame = MinigameWin.transform.GetChild(1).GetComponent<Calculator>();
        typerMinigame = MinigameWin.transform.GetChild(0).GetComponent<Typer>();
    }

    public void OnFastActionButtonClick()
    {
        StartMinigame(ActionDuration.FAST);
    }

    public void OnMedActionButtonClick()
    {
        StartMinigame(ActionDuration.MEDIUM);
    }

    private void StartMinigame(ActionDuration actionDuration)
    {
        if (actionDuration == ActionDuration.FAST)
        {
            typerMinigame.gameObject.SetActive(false);
            calcMinigame.Reset();
        }
        else
        {
            calcMinigame.gameObject.SetActive(false);
            typerMinigame.Reset();
        }
        MinigameWin.SetActive(true);
    }
}
