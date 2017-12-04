using UnityEngine;

public class SpawnMates : MonoBehaviour
{
    public GameObject MatePrefab;
    public int StartSpawnTime;
    public int SpawnRateTime;
    public int MaxNbMates;

	// Use this for initialization
	void Start()
    {
        InvokeRepeating("SpawnMate", StartSpawnTime, SpawnRateTime);
    }

    void SpawnMate()
    {
        int nbMates = GameObject.FindGameObjectsWithTag("Mate").Length;
        if (nbMates == MaxNbMates)
        {
            CancelInvoke("SpawnMate");
            return;
        }
        GameObject mate = Instantiate(MatePrefab, transform.position, transform.rotation);
        mate.name = "Mate" + (nbMates + 1).ToString();
    }
}
