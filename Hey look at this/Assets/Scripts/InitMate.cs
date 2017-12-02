using System.Collections;
using UnityEngine;

public class InitMate : MonoBehaviour
{
    public int TimeBeforeMovingToComputer;
    public int MvtSpd;
    private GameObject seat = null;
    private bool seated = false;

	// Use this for initialization
	void Start ()
    {
        // Say hello
        GameObject button = GameObject.Find("ActionSidebar/MateActionsButtons/MateButton" + GameObject.FindGameObjectsWithTag("Mate").Length);
        button.SetActive(true);
        StartCoroutine(ExecuteAfterTime(TimeBeforeMovingToComputer));
	}
	
	// Update is called once per frame
	void Update ()
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
}
