using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameOverText : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {
        Text GameOverTxt = GetComponent<Text>();
        GameOverTxt.text = GameOverManager.GameOverText;
	}
}
