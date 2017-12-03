using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameWindow : MonoBehaviour {
	public CloseButton closeButton;
	// Use this for initialization

	void Start () {
		closeButton = (CloseButton) Instantiate(closeButton, transform.position, transform.rotation);
		closeButton.Parent = this.gameObject;
	}

	// Update is called once per frame
	void Update () {

	}
}
