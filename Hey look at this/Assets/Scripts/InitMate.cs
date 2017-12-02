using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMate : MonoBehaviour
{
    public int TimeBeforeMovingToComputer;

	// Use this for initialization
	void Start ()
    {
        // Say hello
        StartCoroutine(ExecuteAfterTime(TimeBeforeMovingToComputer));
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        MoveToComputer();
    }

    private void MoveToComputer()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Mate").Length);

        GameObject seat = GameObject.Find("Seats/Seat1");
        if (!seat)
            Debug.Log("Seat not found");
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Seats/Seat1").transform.position, 100);
    }
}
