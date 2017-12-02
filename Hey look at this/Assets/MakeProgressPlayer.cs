using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeProgressPlayer : MonoBehaviour
{
    private int Value = 0;
    public int PtsWonByTime;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey("space"))
        {
            Value += PtsWonByTime;
            Debug.Log(Value);
        }
    }
}
