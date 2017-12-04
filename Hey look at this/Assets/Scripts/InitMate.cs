using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InitMate : MonoBehaviour
{
    public int TimeBeforeMovingToComputer;
    public int MvtSpd;
    public GameObject SpeechBubble;
    public Sprite sp1;
    public Sprite sp2;
    public Sprite sp3;
    public Sprite sp4;
    public Sprite sp5;
    public Sprite sp6;
    public Sprite sp7;
    public Sprite sp8;

    private int id;

    private GameObject seat = null;
    private bool seated = false;

    // Bother action variables
    private float timeBeforeBotheringYou = 10.0f;
    private bool isBotheringYou = false;

    // Use this for initialization
    void Start()
    {
        id = GameObject.FindGameObjectsWithTag("Mate").Length;
        SayHello();
        int rnd = Random.Range(1,9);
        if (rnd == 1)
            GetComponent<SpriteRenderer>().sprite = sp1;
        else if (rnd == 2)
            GetComponent<SpriteRenderer>().sprite = sp2;
        else if (rnd == 3)
            GetComponent<SpriteRenderer>().sprite = sp3;
        else if (rnd == 4)
            GetComponent<SpriteRenderer>().sprite = sp4;
        else if (rnd == 5)
            GetComponent<SpriteRenderer>().sprite = sp5;
        else if (rnd == 6)
            GetComponent<SpriteRenderer>().sprite = sp6;
        else if (rnd == 7)
            GetComponent<SpriteRenderer>().sprite = sp7;
        else
            GetComponent<SpriteRenderer>().sprite = sp8;
        StartCoroutine(MoveAfterTime(TimeBeforeMovingToComputer));
	}

	// Update is called once per frame
	void Update()
    {
        if (seat && transform.position == seat.transform.position && !seated)
        {
            seated = true;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (seat && !seated)
        {
            float step = MvtSpd * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, seat.transform.position, step);
        }
        else if (seat && seated && transform.childCount == 0)
        {
            int rnd = Random.Range(1,100);
            if (rnd == 1 && !isBotheringYou)
                SayShit();
            timeBeforeBotheringYou -= Time.deltaTime;
            if (timeBeforeBotheringYou <= 0 && !isBotheringYou)
            {
                TriggerMateAction();
            }
        }
    }

    IEnumerator MoveAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        MoveToComputer();
    }

    private void MoveToComputer()
    {
        seat = GameObject.Find("Seats/Seat" + id);
        if (!seat)
        {
            Debug.Log("Seat not found");
            return;
        }
        transform.rotation = Quaternion.FromToRotation(seat.transform.position, transform.position);
    }

    private Text CreateSpeechBubbleAndGetTxtComponent(Vector3 vector)
    {
        GameObject bubbleGameObject = Instantiate(SpeechBubble, vector, transform.rotation);
        bubbleGameObject.transform.SetParent(transform);
        return (bubbleGameObject.transform.GetChild(1).gameObject.GetComponent<Text>());
    }

    private void SayShit()
    {
        int rnd = Random.Range(-4, 5);
        Vector3 bubblePosition = new Vector3(transform.position.x, transform.position.y + rnd, transform.position.z);
        Text textGameObject = CreateSpeechBubbleAndGetTxtComponent(bubblePosition);
        SetShitText(textGameObject);
    }

    private void SetShitText(Text textGameObject)
    {
        var Shit = new string[]
        {
            "Have you checked 9gag ?",
            "How do you git pull ?",
            "What's your pants' color bro ?",
            "Oops forgot to push",
            "Is git reset --hard this bad ?",
            "What to do when unity crash ?",
            "Do you know RNGesus ?",
            "I'm a pirate, be my princess",
            "Yamcha died last DBS' episode",
            "Wanna play my LudumDare ?",
            "Antis are all homophobes!",
            "Let's watch LOL Championships!",
            "These days have been so cold",
            "Don't bother me Kevin !",
            "Nani desu ka !?",
            "Don't lick my keyboard Kevin !",
            "My microwave broke today",
            "What do you think of Kevin ?",
            "♪ Never gonna give you up ♫"
        };
        int rnd = Random.Range(0, Shit.Length);
        textGameObject.text = Shit[rnd];
    }

    private void SayHello()
    {
        Vector3 bubblePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Text textGameObject = CreateSpeechBubbleAndGetTxtComponent(bubblePosition);
        SetHelloTextOnId(textGameObject);
    }

    private void SetHelloTextOnId(Text textGameObject)
    {
        int nbOtherMate = GameObject.FindGameObjectsWithTag("Mate").Length;
        var HelloSentences = new string[]
        {
            "Yo boi", "Hey dude", "Wassup bro", "Gimme money",
            "Hey you, you look funny", "Would you have some food ?",
            "Is it the cat fanclub ?", "Hey ! It's me, Mister Riichi!"
        };

        textGameObject.text = HelloSentences[nbOtherMate - 1];
    }

    private void SayBotherSentence()
    {
        Vector3 bubblePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        Text textGameObject = CreateSpeechBubbleAndGetTxtComponent(bubblePosition);
        SetBotherText(textGameObject);
    }

    private void SetBotherText(Text textGameObject)
    {
        int nbOtherMate = GameObject.FindGameObjectsWithTag("Mate").Length;
        var BotherSentences = new string[]
        {
            "Can you help me ? I have merge issues!",
            "Hey dude, can you show me how to fix this problem ?",
            "I pull'ed ur code and it doesn't work ! Help me!"
        };

        int rnd = Random.Range(0, BotherSentences.Length);
        textGameObject.text = BotherSentences[rnd];
    }

    private void TriggerMateAction()
    {
        isBotheringYou = true;
        GameObject button = GameObject.Find("ActionSidebar/MateActionsButtons/MateButton" + id);
        button.SetActive(true);
        SayBotherSentence();
    }
}
