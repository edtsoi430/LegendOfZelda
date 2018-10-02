using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Boomerang : Weapons {

    private int deacceleration;
    private bool returning;
    private float time_interval;
    private Quaternion rotation;
    private Vector2 player_positon;
    private Vector2 weapon_position;

	// Use this for initialization
	void Start () {
        spawnWeapons();
        type = WeaponType.boomerang;
        holding_time = 0.22f;
        speed = 10;
        has_shot = false;

        deacceleration = 1;
        returning = false;
        time_interval = 0.04f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!has_shot)
        {
            shootWeapon();
            has_shot = true;
        }

        if (Time.time - start_time > holding_time)
        {
            player_wc.weapon_holding = false;
        }

        if (speed == 0)
        {
            returning = true;
            speed = 5;
            player_wc.weapon_holding = false;
            tag = "weapon_returning";
        }

        if (Time.time - start_time > time_interval)
        {
            start_time = Time.time;
            transform.Rotate(0, 0, 30);

            if (!returning)
            {
                speed -= deacceleration;
                if (player_arm.direction == "down")
                {
                    rb.velocity = new Vector2(0, -speed);
                }
                else if (player_arm.direction == "left")
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
                else if (player_arm.direction == "up")
                {
                    rb.velocity = new Vector2(0, speed);
                }
                else if (player_arm.direction == "right")
                {
                    rb.velocity = new Vector2(speed, 0);
                }
            }
        }

        if (returning)
        {
            player_positon = player_tf.position;
            weapon_position = transform.position;
            transform.position = Vector3.MoveTowards(weapon_position, player_positon, speed * Time.deltaTime);
        }
    }

    public override void spawnWeapons()
    {
        base.spawnWeapons();
        layer_number = 2;
        sr.sortingOrder = layer_number;
    }

    public override void shootWeapon()
    {
        base.shootWeapon();

        if (player_arm.direction == "down")
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else if (player_arm.direction == "left")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (player_arm.direction == "up")
        {
            rb.velocity = new Vector2(0, speed);
        }
        else if (player_arm.direction == "right")
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (has_shot)
        {
            if (go.tag == "wall" || go.tag == "door" || go.tag == "aisle" || go.tag == "ghost")
            {
                rb.velocity = Vector2.zero;
                returning = true;
                speed = 5;
                player_wc.weapon_holding = false;
                tag = "weapon_returning";
            }   
            else if (go.tag == "Player" && tag == "weapon_returning")
            {
                player_wc.special_using = false;
                endWeapons();
            }
        }
    }
}
