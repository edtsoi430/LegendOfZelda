using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour {
    Rigidbody rb;

    public float movement_speed = 4;
    public string direction;
    public bool inMoving;
    public bool dead;
    public bool player_moving;

    private Sword s;
    private IEnumerator coroutine;
    private bool knocking;
    private Vector2 knocking_speed;

    // Use this for initialization
    void Awake () {
        direction = "down";
        s = GetComponent<Sword>();
        rb = GetComponent<Rigidbody>();
        inMoving = false;
        knocking = false;
        player_moving = true;
        knocking_speed = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!inMoving && !knocking && !dead && !s.weapon_using)
        {
            Vector2 current_input = GetInput();
            rb.velocity = current_input * movement_speed;
        }
        else if (knocking && !dead)
        {
            player_moving = false;
            Vector2 current_input = knocking_speed;
            rb.velocity = current_input * movement_speed * 2;
        }
        else
        {
            player_moving = false;
            rb.velocity = new Vector2(0, 0);
        }
	}

    Vector2 GetInput()
    {
        float horizantal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizantal_input) > 0.0f)
        {
            vertical_input = 0.0f;
            if (horizantal_input > 0) {
                horizantal_input = Mathf.Ceil(horizantal_input);
                direction = "right";
            }
            else
            {
                horizantal_input = Mathf.Floor(horizantal_input);
                direction = "left";
            }
        }
        else
        {
            if (vertical_input > 0)
            {
                vertical_input = Mathf.Ceil(vertical_input);
                direction = "up";
            }
            else if(vertical_input < 0)
            {
                vertical_input = Mathf.Floor(vertical_input);
                direction = "down";
            }
        }

        return new Vector2(horizantal_input, vertical_input);
    }

    public void knockingBack()
    {
        knocking = true;
        if (direction == "right")
        {
            knocking_speed.x = -1;
            coroutine = move(0.5f);
            StartCoroutine(coroutine);
        }
        else if (direction == "left")
        {
            knocking_speed.x = 1;
            coroutine = move(0.5f);
            StartCoroutine(coroutine);
        }
        else if (direction == "up")
        {
            knocking_speed.y = -1;
            coroutine = move(0.5f);
            StartCoroutine(coroutine);
        }
        else if (direction == "down")
        {
            knocking_speed.y = 1;
            coroutine = move(0.5f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator move (float time)
    {
        yield return new WaitForSeconds(time);
        knocking = false;
        knocking_speed = new Vector2(0, 0);
    }
}
