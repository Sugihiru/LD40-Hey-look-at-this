using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

	// Use this for initialization
	public GameObject Parent;
	void OnMouseDown() {
		Debug.Log("Lol");
		Destroy(Parent);
		Destroy(gameObject);
	}

	void Start () {
		Debug.Log("Gnap");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log("Hey");
				Destroy(hit.transform.gameObject);
			}
		}
	}
}
