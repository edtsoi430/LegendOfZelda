using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stalfo : Enemy
{
    public Sprite sprite1;
    public Sprite sprite2;

    private void Start()
    {
        speed = 2f;
        flashing_time = 0.3f;
        duration_time = 2f;
        health = 2;
        movement = randomMove();
        rb.velocity = movement * speed;
    }

    public override void Update()
    {
        base.Update();

        StopCheck();

        if (rb.velocity == Vector3.zero)
        {
            movement = randomMove();
            rb.velocity = movement * speed;
        }

        if (Time.time - start_time > duration_time && !stop)
        {
            start_time = Time.time;
            movement = randomMove();
            rb.velocity = movement * speed;
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
