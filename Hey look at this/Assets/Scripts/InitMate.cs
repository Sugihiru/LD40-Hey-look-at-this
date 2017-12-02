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
        ExecuteAfterTime(TimeBeforeMovingToComputer);
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
        GameObject seat = GameObject.Find("Seats/Seat");
        if (!seat)
            Debug.Log("Seat not found");
    }
}
