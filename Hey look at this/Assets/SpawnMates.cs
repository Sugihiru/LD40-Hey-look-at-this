using UnityEngine;

public class SpawnMates : MonoBehaviour
{
    public GameObject MatePrefab;
	// Use this for initialization
	void Start()
    {
        InvokeRepeating("SpawnMate", 60, 30);
    }

    void SpawnMate()
    {
        Instantiate(MatePrefab);
    }
}
