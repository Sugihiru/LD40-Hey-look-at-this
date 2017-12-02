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
        if (GameObject.FindGameObjectsWithTag("Mate").Length == MaxNbMates)
        {
            CancelInvoke("SpawnMate");
            return;
        }
        Instantiate(MatePrefab, transform.position, transform.rotation);
    }
}
