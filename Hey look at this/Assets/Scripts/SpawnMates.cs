using UnityEngine;

public class SpawnMates : MonoBehaviour
{
    public GameObject MatePrefab;
    private Progress progress;
    public int StartSpawnTime;
    public int MaxNbMates;

    private int CheckRateTime = 15;

    // Use this for initialization
    void Start()
    {
        progress = GameObject.Find("Canvas/ProgressBar/Foreground").GetComponent<Progress>();
        InvokeRepeating("SpawnMate", StartSpawnTime, CheckRateTime);
    }

    void SpawnMate()
    {
        int nbMates = GameObject.FindGameObjectsWithTag("Mate").Length;
        if (nbMates == MaxNbMates)
        {
            CancelInvoke("SpawnMate");
            return;
        }
        Debug.Log(progress.getPercentage());
        if (progress.getPercentage() >= (75 / MaxNbMates) * nbMates)
        {
            GameObject mate = Instantiate(MatePrefab, transform.position, transform.rotation);
            mate.name = "Mate" + (nbMates + 1).ToString();
        }
    }
}
