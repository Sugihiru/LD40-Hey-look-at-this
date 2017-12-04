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

    public void OnCancelActionButtonClick()
    {
        if (!calcMinigame.isActiveAndEnabled)
            typerMinigame.gameObject.SetActive(false);
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

    public void OnMateActionButtonClick(int MateId)
    {
        StartMinigameMate(MateId);
    }

    private void StartMinigame(ActionType actionType)
    {
        if (IsThereMinigameRunning())
            return;
        if (actionType == ActionType.FAST)
        {
            cancelAllMinigames();
            typerMinigame.Reset(0);
        }
        else if (actionType == ActionType.MEDIUM)
        {
            cancelAllMinigames();
            typerMinigame.Reset(1);
        }
        else if (actionType == ActionType.LONG)
        {
            cancelAllMinigames();
            typerMinigame.Reset(4);
        }
        MinigameWin.SetActive(true);
    }

    private void StartMinigameMate(int MateId)
    {
        if (IsThereMinigameRunning())
            return;
        GameObject.Find("Canvas/ActionSidebar/MateActionsButtons/MateButton" + MateId.ToString()).SetActive(false);
        cancelAllMinigames();
        calcMinigame.Reset(0, MateId);
        MinigameWin.SetActive(true);
    }

    private void cancelAllMinigames()
    {
        typerMinigame.gameObject.SetActive(false);
        calcMinigame.gameObject.SetActive(false);
    }

    private bool IsThereMinigameRunning()
    {
        return (calcMinigame.isActiveAndEnabled || typerMinigame.isActiveAndEnabled);
    }
}
