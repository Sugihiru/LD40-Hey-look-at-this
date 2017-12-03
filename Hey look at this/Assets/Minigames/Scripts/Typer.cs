﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class Typer : MonoBehaviour {
	private bool over {get;set;}
	public GameObject panel;

	private string[] to_type;
	private int list_offset;
	private int word_offset;
	private string result;
	private string[] words = {
		"for",
		"each",
		"in",
		"while",
		"len",
		"if",
		"elif",
		"type",
		"def",
		"else",
		"is",
		"none",
		"not"
	};
	// Use this for initialization
	void Start () {
		to_type = new string[10];
		over = false;
		list_offset = 0;
		word_offset = 0;

		for (int i = 0; i < 10; i++) {
			int nbr = Random.Range(0, words.Length);
			to_type[i] = words[nbr];
		}

	}

	// Update is called once per frame
	void Update () {
		if (! over) {
			string word = to_type[list_offset];
			char letter = word[word_offset];
			if (Input.GetKey(letter.ToString())) {
				word_offset += 1;

				if (word_offset == word.Length) {
					word_offset = 0;
					list_offset += 1;
					if (list_offset == to_type.Length) {
						over = true;
						panel.SetActive(false);
					}
				}
			}
			Text display = gameObject.GetComponent<Text>();
			//Debug.Log("Yahaha");
			result = "";
			for (int i = list_offset; i < 10; i++) {
				result += to_type[i] + " ";
			}
			display.text = result.Substring(word_offset);
		}
	}
}
