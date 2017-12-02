using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    private float Value = 0;
    public float MaxValue;
    public float PtsWonPerSecPerPerson;
    private Image Img;

    void Start()
    {
        Img = gameObject.GetComponent<Image>(); 
    }

	// Update is called once per frame
	void Update ()
    {
        if (Value < MaxValue)
        {
            Value += (PtsWonPerSecPerPerson * GameObject.FindGameObjectsWithTag("Mate").Length) * Time.deltaTime;
            Img.fillAmount = Value / MaxValue;
        }
    }
}
