using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dragon : Enemy {

    public GameObject fires;

    public Sprite sprite1; // left
    public Sprite sprite2; // right
    public Sprite mouth_sprite1; // open left
    public Sprite mouth_sprite2; // open right

    private GameObject fire_out;

    private Transform[] tfs;
    private Vector3 next_position;
    private float fire_time = 3f;
    private float firing_start;
    private int move;


    void Start () 
    {
        health = 4;
        firing_start = Time.time;
        is_boss = true;
        flashing_time = 0.3f;
        tfs = transform.parent.GetComponentsInChildren<Transform>();
        next_position = tfs[3].position;
    }
    
    public override void Update()
    {
        if (Time.time - firing_start > fire_time)
        {
            if (last_sprite == sprite1)
            {
                sr.sprite = mouth_sprite1;
            }
            else{
                sr.sprite = mouth_sprite2;
            }
            firing_start = Time.time;
            Instantiate<GameObject>(fires, transform.position, Quaternion.identity);
        }

        if (Time.time - sprite_time > flashing_time)
        {
            sprite_time = Time.time;

            if (last_sprite == sprite1)
            {
                sr.sprite = sprite2;
                last_sprite = sprite2;
            }
            else if (last_sprite == sprite2)
            {
                sr.sprite = sprite1;
                last_sprite = sprite1;
            }
        }
        // Random move
        transform.position = Vector3.MoveTowards(transform.position, next_position, Time.deltaTime);
        if(transform.position == next_position){
            if(transform.position == tfs[3].position || transform.position == tfs[4].position)
            {
                next_position = tfs[2].position;
            }
            else
            {
                move = Random.Range(3, 5);
                if (move == 3)
                {
                    next_position = tfs[3].position;
                }
                else
                {
                    next_position = tfs[4].position;
                }
            }
        }
        base.Update();
    }
}
