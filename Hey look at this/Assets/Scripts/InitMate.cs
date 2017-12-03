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


    private GameObject seat = null;
    private bool seated = false;

    // Use this for initialization
    void Start()
    {
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

        GameObject button = GameObject.Find("ActionSidebar/MateActionsButtons/MateButton" + GameObject.FindGameObjectsWithTag("Mate").Length);
        button.SetActive(true);
        StartCoroutine(ExecuteAfterTime(TimeBeforeMovingToComputer));
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
            int rnd = Random.Range(1,1337);
            if (rnd == 1)
                SayShit();
            //Here is when your mate want to bother you
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        MoveToComputer();
    }

    private void MoveToComputer()
    {
        seat = GameObject.Find("Seats/Seat" + GameObject.FindGameObjectsWithTag("Mate").Length);
        if (!seat)
        {
            Debug.Log("Seat not found");
            return;
        }
        transform.rotation = Quaternion.FromToRotation(seat.transform.position, transform.position);
    }

    private void SayShit()
    {
        Vector3 bubblePosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        GameObject bubbleGameObject = Instantiate(SpeechBubble, bubblePosition, transform.rotation);
        Text textGameObject = bubbleGameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        SetShitText(textGameObject);

        bubbleGameObject.transform.SetParent(transform);
    }

    private void SetShitText(Text textGameObject)
    {
        var Shit = new string[]
        {
            "Did you checked 9gag ?",
            "How do you git pull ?",
            "What's your pants color bro ?",
            "Oups forgot to push",
            "Is git reset --hard this bad ?",
            "What to do when unity crash ?",
            "Do you know RNGesus ?",
            "I'm a pirate, be my princess",
            "Goku died last DBS' episode",
            "Wanna play my LudumDare ?",
            "Antis are all homophobes!",
            "Let's watch LOL Championships!",
            "These day have been so cold",
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

        GameObject bubbleGameObject = Instantiate(SpeechBubble, bubblePosition, transform.rotation);
        Text textGameObject = bubbleGameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        SetHelloTextOnId(textGameObject);

        bubbleGameObject.transform.SetParent(transform);
    }

    private void SetHelloTextOnId(Text textGameObject)
    {
        int nbOtherMate = GameObject.FindGameObjectsWithTag("Mate").Length;
        var HelloSentences = new string[]
        {
            "Yo bois", "Hey dude", "Wassup bro", "Gimme money",
            "Hey u, you look funny", "Woul'd you have some food ?",
            "Is it the cat fanclub ?", "Hey ! It's me, Mister Riichi!"
        };

        textGameObject.text = HelloSentences[nbOtherMate - 1];
    }
}
