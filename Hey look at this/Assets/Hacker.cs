using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacker : MonoBehaviour {
	private string target;
	private string variation;
	private string double_variation;
	private int difficulty {get;set;}
	private int size;
	private bool over;
	private int focus;
	private int nbr;


	// Use this for initialization
	void Start () {
		focus = 0;
		difficulty = 0;
		size = 8;

		for (int i = 0; i < size; ++i) {
			int rnd = Random.Range(0, 2);
			target += rnd.ToString();
			if (i == 0 || Random.Range(0, 4) == 0)
				variation += (1 - rnd).ToString();
			else
				variation += rnd;
		}
		gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "h4Xx0R Binary Patching";

	}

	void Reset (int difficulty) {
		Start();
		this.difficulty = difficulty;
		gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Target = " + target;
		double_variation = "";
		for (int i = 0; i < size; ++i) {
			if (i == focus)
				double_variation += "[";
			double_variation += variation[i];
			if (i == focus)
				double_variation += "]";
		}
		gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Current = " + double_variation;

		if (!over) {
			if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
					Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.K)) {
				string tmp = "";
				for (int i = 0; i < size; ++i) {
					if (i == focus) {
						tmp += (char) ((1 - (variation[i] - '0')) + '0');
					}
					else
						tmp += variation[i];
				}
				variation = tmp;
//				Debug.Log("Variation = " + variation);
//				Debug.Log("Target = " + target);
				if (string.Equals(variation, target)) {
					if (nbr == difficulty) {
						over = true;
						gameObject.SetActive(false);
					}
					else {
						nbr += 1;
						int tmpint = difficulty;
						Start();
						difficulty = tmpint;
					}
				}
			}
			else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.H)) {
				focus = (focus + size - 1) % size;
			}
			else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.L)) {
				focus = (focus + 1) % size;
			}
		}
//		gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = variation;
	}
}
