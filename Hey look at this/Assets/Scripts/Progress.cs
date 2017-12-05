using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public float MaxValue;
    public float PtsWonPerSecPerPerson;
    public Text CompletionTxt;

    private float Value = 0;
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
            Value += (PtsWonPerSecPerPerson * GetNbActiveMate()) * Time.deltaTime;
            if (Value > MaxValue)
                Value = MaxValue;
            Img.fillAmount = Value / MaxValue;
            if (Img.fillAmount >= 1)
            {
                GameOverManager.GameOverText = "Congratulations ! You won !";
                GameOverManager.LoadGameOverScene();
            }
            UpdateTxt();
        }
    }

    private void UpdateTxt()
    {
        if (Img.fillAmount <= 1)
            //CompletionTxt.text = string.Format(@"{0}/{1} - {2}%", Value.ToString("F1"), MaxValue, (Img.fillAmount * 100).ToString("F1"));
            CompletionTxt.text = string.Format(@"{0}%", (Img.fillAmount * 100).ToString("F1"));
    }

    public void AddPts(float pts)
    {
        Debug.Log(pts);
        Value += pts;
        if (Value >= MaxValue)
        {
            GameOverManager.GameOverText = "Congratulations ! You won !\nTime left: " + GameObject.Find("Canvas/DeadlineBar/Foreground").GetComponent<IncreaseTimer>().GetTimeLeft();
            GameOverManager.LoadGameOverScene();
        }
        UpdateTxt();
    }

    private int GetNbActiveMate()
    {
        int nbActiveMate = 0;
        foreach(GameObject mate in GameObject.FindGameObjectsWithTag("Mate"))
        {
            if (mate.GetComponent<InitMate>().IsWorking())
                ++nbActiveMate;
        }
        return nbActiveMate;
    }

    public float getPercentage()
    {
        return Value / MaxValue * 100;
    }
}
