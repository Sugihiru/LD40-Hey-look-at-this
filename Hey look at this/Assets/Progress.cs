using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    private float Value = 0;
    public float MaxValue;
    public float PtsWonByTime;
    private Image Img;

    void Start()
    {
        Img = gameObject.GetComponent<Image>(); 
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("space") && Value < MaxValue)
        {
            Value += PtsWonByTime;
            Debug.Log(Value / MaxValue);
            Img.fillAmount = Value / MaxValue;
        }
    }
}
