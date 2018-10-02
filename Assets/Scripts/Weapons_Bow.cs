using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Bow : Weapons
{
    public Sprite bow_down;
    public Sprite bow_left;
    public Sprite bow_up;
    public Sprite bow_right;

    private void Start()
    {
        spawnWeapons();
        type = WeaponType.bow;
        holding_time = 0.22f;
        speed = 10;
        has_shot = false;
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
    }

    public override void spawnWeapons()
    {
        base.spawnWeapons();
        if (player_arm.direction == "down")
        {
            sr.sprite = bow_down;
            layer_number = 2;
        }
        else if (player_arm.direction == "left")
        {
            sr.sprite = bow_left;
            layer_number = 2;
        }
        else if (player_arm.direction == "up")
        {
            sr.sprite = bow_up;
            layer_number = 1;
        }
        else if (player_arm.direction == "right")
        {
            sr.sprite = bow_right;
            layer_number = 2;
        }

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
                player_wc.weapon_holding = false;
                endWeapons();
            }
        }
    }
}
