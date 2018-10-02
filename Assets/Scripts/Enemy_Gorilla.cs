using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gorilla : Enemy
{
    public GameObject boomerangPrefab;

    public string direction;

    private Animator animator;
    private Vector3 original_position;

    // public GameObject Gorilla_weapon;
    private void Start()
    {
        speed = 2.0f;
        duration_time = 4.0f;
        health = 2;
        animator = GetComponent<Animator>();
        movement = randomMove();
    }

    public override void Update()
    {
        base.Update();

        StopCheck();

        animator.SetFloat("horizontal_input", movement.x);
        animator.SetFloat("vertical_input", movement.y);

        if (rb.velocity == Vector3.zero)
        {
            movement = randomMove();
            rb.velocity = movement * speed;
        }
        else
        {
            animator.speed = 1.0f;
        }

        if (Time.time - start_time > duration_time && !stop)
        {
            start_time = Time.time;
            movement = randomMove();
            Instantiate<GameObject>(boomerangPrefab, original_position, Quaternion.identity, transform);
            rb.velocity = movement * speed;
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
            direction = "left";
            original_position = transform.position;
            original_position.x -= 0.7f;
            original_position.y -= 0.125f;
        }
        else if (random == 1)
        {
            x = 0;
            y = -1;
            direction = "down";
            original_position = transform.position;
            original_position.x += 0.1f;
            original_position.y -= 0.73f;
        }
        else if (random == 2)
        {
            x = 1;
            y = 0;
            direction = "right";
            original_position = transform.position;
            original_position.x += 0.7f;
            original_position.y -= 0.125f;
        }
        else if (random == 3)
        {
            x = 0;
            y = 1;
            direction = "up";
            original_position = transform.position;
            original_position.x -= 0.1f;
            original_position.y += 0.73f;
        }
        return new Vector2(x, y);
    }
    
}
