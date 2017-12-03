using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InitMate : MonoBehaviour
{
    public int TimeBeforeMovingToComputer;
    public int MvtSpd;
    public GameObject SpeechBubble;

    private GameObject seat = null;
    private bool seated = false;

    // Use this for initialization
    void Start()
    {
        SayHello();
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
