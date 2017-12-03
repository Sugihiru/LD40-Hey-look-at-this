using System;
using UnityEngine;
using UnityEngine.UI;


public class IncreaseTimer : MonoBehaviour
{
    public Text TimerTxt;
    public int NbMinDeadline;

    private float Value = 0;
    private Image Img;
    private TimeSpan timeSpan;
    private float MaxValue;

    // Use this for initialization
    void Start()
    {
        timeSpan = new TimeSpan(0, NbMinDeadline, 0);
        MaxValue = NbMinDeadline * 60;
        Img = gameObject.GetComponent<Image>();
        UpdateDate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Value < MaxValue)
        {
            Value += Time.deltaTime;
            Img.fillAmount = 1 - (Value / MaxValue);

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
