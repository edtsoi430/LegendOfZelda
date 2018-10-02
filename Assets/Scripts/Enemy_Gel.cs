using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gel : Enemy
{
    public Sprite sprite1;
    public Sprite sprite2;

    private Vector2 original_position;
    private Vector2 final_position;

    // Use this for initialization
    void Start ()
    {
        health = 1;
        duration_time = 2f;
        original_position = transform.position;
        final_position = original_position;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        StopCheck();
        transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 10);

        if (Time.time - start_time > duration_time && !stop)
        {
            start_time = Time.time;
            original_position = transform.position;
            final_position = original_position + randomMove();
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
    }

    public override Vector2 randomMove()
    {
        int x = 0;
        int y = 0;
        int random = Random.Range(0, 4);

        if (random == 0)
        {
            x = -1;
            y = 0;
        }
        else if (random == 1)
        {
            x = 0;
            y = -1;
        }
        else if (random == 2)
        {
            x = 1;
            y = 0;
        }
        else if (random == 3)
        {
            x = 0;
            y = 1;
        }
        return new Vector2(x, y);
    }
}
