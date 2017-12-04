using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonScript : MonoBehaviour
{
    public GameObject MinigameWin;

    private Calculator calcMinigame;
    private Typer typerMinigame;

    public enum ActionType
    {
        FAST,
        MEDIUM,
        LONG,
        MATE_ACTION
    };

    public void Start()
    {
        calcMinigame = MinigameWin.transform.GetChild(1).GetComponent<Calculator>();
        typerMinigame = MinigameWin.transform.GetChild(0).GetComponent<Typer>();
    }

    public void OnFastActionButtonClick()
    {
        StartMinigame(ActionType.FAST);
    }

    public void OnMedActionButtonClick()
    {
        StartMinigame(ActionType.MEDIUM);
    }

    public void OnLongActionButtonClick()
    {
        StartMinigame(ActionType.LONG);
    }

    public void OnMateActionButtonClick()
    {
        StartMinigame(ActionType.MATE_ACTION);
    }

    private void StartMinigame(ActionType actionType)
    {
        if (actionType == ActionType.FAST)
        {
            cancelAllMinigames();
            calcMinigame.Reset();
        }
        else if (actionType == ActionType.MATE_ACTION)
        {
            cancelAllMinigames();
            calcMinigame.Reset();
        }
        else
        {
            cancelAllMinigames();
            typerMinigame.Reset();
        }
        MinigameWin.SetActive(true);
    }

    private void cancelAllMinigames()
    {
        typerMinigame.gameObject.SetActive(false);
        calcMinigame.gameObject.SetActive(false);
    }
}
