using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallMaster : MonoBehaviour {
    public GameObject[] wall_masters;
    public int move = 0;
    public int counter;
    
	// Use this for initialization
	void Start () {
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (counter < 2)
        {
            wall_masters[counter].gameObject.SetActive(true);
            counter++;
        }
    }
}
