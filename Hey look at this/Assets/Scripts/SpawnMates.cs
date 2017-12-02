using UnityEngine;

public class SpawnMates : MonoBehaviour
{
    public GameObject MatePrefab;
    public int StartSpawnTime;
    public int SpawnRateTime;

	// Use this for initialization
	void Start()
    {
        InvokeRepeating("SpawnMate", StartSpawnTime, SpawnRateTime);
    }

    void SpawnMate()
    {
        Instantiate(MatePrefab, transform.position, transform.rotation);
    }
}
