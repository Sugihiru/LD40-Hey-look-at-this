using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public float nbPts;

    private Progress progress;
	private bool over {get;set;}

	private Text display;
    private List<string> to_type = new List<string>();
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
		"continue",
		"not",
		"class",
		"and",
		"as",
		"assert",
		"break",
		"except",
		"finally",
		"from",
		"global",
		"import",
		"lambda",
		"or",
		"pass",
		"raise",
		"return",
		"try",
		"with",
		"yield",
        "enumerate",
        "print",
        "int",
        "input",
        "str",
        "open",
        "range",
        "zip",
	};
	private int difficulty;

	// Use this for initialization
	void Start ()
    {
		gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Coding for the project";
		display = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
		display.text = "";
        ResetWordList();
        progress = GameObject.Find("Canvas/ProgressBar/Foreground").GetComponent<Progress>();
	}

	public void Reset(int difficulty)
    {
		Start();
		over = false;
		gameObject.SetActive(true);
		this.difficulty = difficulty;
        ResetWordList();
	}


    void ResetWordList()
    {
        over = false;
        word_offset = 0;

        to_type.Clear();

        for (int i = 0; i < 10 * (difficulty + 1); i++)
        {
            int nbr = Random.Range(0, words.Length);
            to_type.Add(words[nbr]);
        }
    }

	// Update is called once per frame
	void Update()
    {
		if (!over)
        {
			string word = to_type[0];
			char letter = word[word_offset];
			if (Input.GetKeyUp(letter.ToString()))
            {
				word_offset += 1;

				if (word_offset == word.Length)
                {
					word_offset = 0;
                    // list_offset += 1;
                    to_type.RemoveAt(0);
                    if (to_type.Count == 0)
					// if (list_offset == to_type.Length)
                    {
						over = true;
						gameObject.SetActive(false);
					}
				}
			}
			result = "";
            int maxWordPrinted = (to_type.Count < 10) ? to_type.Count : 10;
			for (int i = 0; i < maxWordPrinted; i++)
            {
				result += to_type[i] + " ";
			}
			display.text = "> " + result.Substring(word_offset);
		}
	}

    void OnDisable()
    {
        if (over)
        {
            progress.AddPts(nbPts * (difficulty + 1));
        }
    }
}
