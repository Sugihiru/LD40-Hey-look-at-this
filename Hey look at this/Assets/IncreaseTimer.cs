using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseTimer : MonoBehaviour
{
    public float MaxValue;
    public float PtsLostPerSecond;
    public Text TimerTxt;

    private float Value = 0;
    private Image Img;
    private TimeSpan timeSpan = new TimeSpan(0, 10, 0);

    // Use this for initialization
    void Start()
    {
        Img = gameObject.GetComponent<Image>();
        UpdateDate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Value < MaxValue)
        {
            Value += PtsLostPerSecond * Time.deltaTime;
            Img.fillAmount = Value / MaxValue;

            TimeSpan span = TimeSpan.FromSeconds(Time.deltaTime);
            timeSpan -= span;
            UpdateDate();
        }
    }

    private void UpdateDate()
    {
        if (timeSpan.Seconds >= 0)
            TimerTxt.text = string.Format(@"{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
    }
}
