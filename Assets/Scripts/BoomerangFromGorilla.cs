using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangFromGorilla : MonoBehaviour {

    public float start_time;
    public float holding_time;
    public int speed;
    public int layer_number;
    public bool has_shot;

    private SpriteRenderer sr;
    private Rigidbody rb;
    private GameObject parent;
    private string direction;

    private int deacceleration;
    private bool returning;
    private float time_interval;
    private Quaternion rotation;
    private Vector2 player_positon;
    private Vector2 weapon_position;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        start_time = Time.time;
    }

    // Use this for initialization
    void Start ()
    {
        holding_time = 0.22f;
        speed = 10;
        layer_number = 2;
        sr.sortingOrder = layer_number;
        has_shot = false;
        deacceleration = 1;
        returning = false;
        time_interval = 0.08f;

        parent = transform.parent.gameObject;
        direction = parent.GetComponent<Enemy_Gorilla>().direction;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!has_shot)
        {
            shootWeapon();
            has_shot = true;
        }

        if (speed == 0)
        {
            returning = true;
            speed = 5;
            tag = "weapon_returning";
        }

        if (Time.time - start_time > time_interval)
        {
            start_time = Time.time;
            transform.Rotate(0, 0, 30);

            if (!returning)
            {
                speed -= deacceleration;
                if (direction == "down")
                {
                    rb.velocity = new Vector2(0, -speed);
                }
                else if (direction == "left")
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
                else if (direction == "up")
                {
                    rb.velocity = new Vector2(0, speed);
                }
                else if (direction == "right")
                {
                    rb.velocity = new Vector2(speed, 0);
                }
            }
        }

        if (returning)
        {
            player_positon = parent.transform.position;
            weapon_position = transform.position;
            transform.position = Vector3.MoveTowards(weapon_position, player_positon, speed * Time.deltaTime);
        }
    }

    public void shootWeapon()
    {

        if (direction == "down")
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if (direction == "left")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (direction == "up")
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (direction == "right")
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (has_shot)
        {
            if (go.tag == "wall" || go.tag == "door" || go.tag == "aisle" || go.tag == "player")
            {
                rb.velocity = Vector2.zero;
                returning = true;
                speed = 5;
                tag = "weapon_returning";
            }
            else if (go.tag == "ghost" && tag == "weapon_returning")
            {
                endWeapons();
            }
        }
    }

    public void endWeapons()
    {
        Destroy(gameObject);
    }
}
