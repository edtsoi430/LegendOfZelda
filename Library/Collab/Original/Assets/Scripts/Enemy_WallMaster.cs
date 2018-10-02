using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WallMaster : Enemy {

    private Transform[] tfs;
    private Transform wall_master;

   // private Vector3 original_position;
    private Vector3 next_position;
    private int counter = 3;

    // Use this for initialization
    void Start ()
    {
        tfs = GetComponentsInChildren<Transform>();
        wall_master = tfs[1];
      //  original_position = transform.position;
        next_position = tfs[2].position;
    }

    // Update is called once per frame
    public override void Update ()
    {
        wall_master.position = Vector3.MoveTowards(wall_master.position, next_position, Time.deltaTime);

        if (next_position == wall_master.position && counter < 5)
        {
            next_position = tfs[counter].position;
            counter++;
        }
    }
}
