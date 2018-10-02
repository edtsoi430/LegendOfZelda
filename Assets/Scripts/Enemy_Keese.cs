using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Keese : Enemy
{
    public Sprite sprite1;
    public Sprite sprite2;

    private void Start()
    {
        speed = 6f;
        flashing_time = 0.15f;
        duration_time = 2f;
        health = 1;
        movement = randomMove();
        rb.velocity = movement * speed;
    }

    public override void Update()
    {
        base.Update();

        StopCheck();

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
        float x = 0;
        float y = 0;
        float velocity = Random.Range(0, 1.0f);
        int random = Random.Range(0, 7);

        if (random == 0)
        {
            x = 1;
            y = 1;
        }
        else if (random == 1)
        {
            x = -1;
            y = 1;
        }
        else if (random == 2)
        {
            x = 1;
            y = -1;
        }
        else if (random == 3)
        {
            x = -1;
            y = -1;
        }
        else if (random == 4)
        {
            x = 0;
            y = 1;
        }
        else if (random == 5)
        {
            x = 0;
            y = -1;
        }
        else if (random == 6)
        {
            x = 1;
            y = 0;
        }
        else if (random == 7)
        {
            x = 0;
            y = -1;
        }

        x *= velocity;
        y *= velocity;

        return new Vector2(x, y);
    }
}
