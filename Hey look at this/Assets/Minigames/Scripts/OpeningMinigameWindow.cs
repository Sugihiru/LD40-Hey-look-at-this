﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningMinigameWindow : MonoBehaviour {
	public MinigameWindow minigameWindow;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			Debug.Log("MDR");
			minigameWindow = (MinigameWindow) Instantiate(minigameWindow, transform.position, transform.rotation);
		}
	}
}
