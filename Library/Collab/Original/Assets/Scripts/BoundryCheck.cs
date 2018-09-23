using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryCheck : MonoBehaviour {

    public GameObject room;

    private float minX;
    private float minY;
    private float maxX;
    private float maxY;

    // Use this for initialization
    void Awake () {
        minX = room.transform.position.x;
        minY = room.transform.position.y;
        maxX = room.transform.position.x + 16f;
        maxY = room.transform.position.y + 11f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

		if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        else if (pos.x < minX)
        {
            pos.x = minX;
        }
        else if (pos.y > maxY)
        {
            pos.y = maxY;
        }
        else if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.position = pos;
    }
}
