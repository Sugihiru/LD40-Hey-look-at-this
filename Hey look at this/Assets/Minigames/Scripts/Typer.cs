using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour {
	private bool over {get;set;}
	private bool mustRestart {get;set;}

	private Text display;
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
		"yield"
	};
	private bool isMate {get;set;}
	private int difficulty;
	// Use this for initialization
	void Start () {
		gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Coding for the project";
		display = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
		display.text = "";
		mustRestart = true;
	}

	public void Reset(int difficulty, bool isMate) {
		Start();
		over = false;
		gameObject.SetActive(true);
		this.difficulty = difficulty;
		this.isMate = isMate;
	}
	// Update is called once per frame
	void Update () {
		if (mustRestart) {
			to_type = new string[10 * (difficulty + 1)];
			over = false;
			list_offset = 0;
			word_offset = 0;

			for (int i = 0; i < 10 * (difficulty + 1); i++) {
				int nbr = Random.Range(0, words.Length);
				to_type[i] = words[nbr];
			}
			mustRestart = false;
		}
		if (! over) {
			string word = to_type[list_offset];
			char letter = word[word_offset];
			if (Input.GetKeyUp(letter.ToString())) {
				word_offset += 1;

				if (word_offset == word.Length) {
					word_offset = 0;
					list_offset += 1;
					if (list_offset == to_type.Length) {
						over = true;
						gameObject.SetActive(false);
					}
				}
			}
			//Debug.Log("Yahaha");
			result = "";
			for (int i = list_offset; i < 10; i++) {
				result += to_type[i] + " ";
			}
			display.text = "> " + result.Substring(word_offset);
		}
	}
}
