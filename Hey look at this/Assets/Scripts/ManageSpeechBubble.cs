using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSpeechBubble : MonoBehaviour
{
    public float lifeTime;

    private float y_offset = 2;  // Y offset for the speech bubble

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
	
	// Update is called once per frame
	void Update()
    {
        Vector3 NewPos = transform.parent.position + new Vector3(0, y_offset, 0);
        transform.position = NewPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
