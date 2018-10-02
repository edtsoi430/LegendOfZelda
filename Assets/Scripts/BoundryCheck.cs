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
        minX = room.transform.position.x + 1;
        minY = room.transform.position.y + 1;
        maxX = room.transform.position.x + 14;
        maxY = room.transform.position.y + 9;
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
        if (pos.y > maxY)
        {
            pos.y = maxY;
        }
        else if (pos.y < minY)
        {
            pos.y = minY;
        }

        transform.position = pos;
    }

    public void SetRoom(GameObject R)
    {
        room = R;
    }
}
