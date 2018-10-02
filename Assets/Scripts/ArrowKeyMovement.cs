using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour {

    public float movement_speed = 6;
    public string direction;
    public bool camera_moving;
    public bool knocking;
    public bool dead;
    public bool catching;
    public bool flying;
    public bool gold;
    public bool enter_oldMan;
    public AudioClip knockBack_sound;

    private Rigidbody rb;
    private WeaponControl wc;
    private IEnumerator coroutine;
    private Vector2 knocking_speed;
    private GameObject wall_master;
    // Use this for initialization
    void Awake () {
        direction = "down";
        rb = GetComponent<Rigidbody>();
        wc = GetComponent<WeaponControl>();
        camera_moving = false;
        knocking = false;
        dead = false;
        catching = false;
        flying = false;
        enter_oldMan = false;
        gold = false;
        knocking_speed = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (!camera_moving && !knocking && !dead && !wc.weapon_holding && !catching && !flying && !enter_oldMan && !gold)
        {
            Debug.Log(10);
            Vector2 current_input = GetInput();
            rb.velocity = current_input * movement_speed;
        }
        else if (knocking && !dead)
        {
            Vector2 current_input = knocking_speed;
            rb.velocity = current_input * movement_speed * 2;
            AudioSource.PlayClipAtPoint(knockBack_sound, Camera.main.transform.position);
        }
        else if (catching && !dead)
        {
            rb.velocity = Vector2.zero;
            transform.position = wall_master.transform.position;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
	}

    Vector2 GetInput ()
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

    public void knockingBack ()
    {
        knocking = true;

        if (direction == "right")
        {
            knocking_speed.x = -0.8f;
        }
        else if (direction == "left")
        {
            knocking_speed.x = 0.8f;
        }
        else if (direction == "up")
        {
            knocking_speed.y = -0.8f;
        }
        else if (direction == "down")
        {
            knocking_speed.y = 0.8f;
        }

        coroutine = Move(0.3f);
        StartCoroutine(coroutine);
    }

    IEnumerator Move (float time)
    {
        yield return new WaitForSeconds(time);
        knocking = false;
        knocking_speed = new Vector2(0, 0);
    }

    public void GetCaught (GameObject go)
    {
        wall_master = go;
    }
}
