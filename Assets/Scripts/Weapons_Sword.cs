using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Sword : Weapons
{
    public Sprite sword_down;
    public Sprite sword_left;
    public Sprite sword_up;
    public Sprite sword_right;

    public Sprite sword_down2;
    public Sprite sword_left2;
    public Sprite sword_up2;
    public Sprite sword_right2;

    public GameObject bangPrefab;

    private Player player_info;
    private bool flying = true;

    private void Start()
    {
        spawnWeapons();
        type = WeaponType.sword;
        holding_time = 0.22f;
        speed = 10;
        has_shot = false;
        player_info = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!player_info.isFullHealth())
        {
            flying = false;
        }

        if (!has_shot && !player_wc.weapon_holding && flying)
        {
            shootWeapon();
            has_shot = true;
        }

        if (Time.time - start_time > holding_time)
        {
            player_wc.weapon_holding = false;
            if (!flying)
            {
                endWeapons();
            }
        }
    }

    public override void spawnWeapons()
    {
        base.spawnWeapons();
        if (player_arm.direction == "down")
        {
            sr.sprite = sword_down;
            layer_number = 2;
        }
        else if (player_arm.direction == "left")
        {
            sr.sprite = sword_left;
            layer_number = 2;
        }
        else if (player_arm.direction == "up")
        {
            sr.sprite = sword_up;
            layer_number = 1;
        }
        else if (player_arm.direction == "right")
        {
            sr.sprite = sword_right;
            layer_number = 2;
        }

        sr.sortingOrder = layer_number;
    }

    public override void shootWeapon()
    {
        base.shootWeapon();

        if (player_arm.direction == "down")
        {
            sr.sprite = sword_down2;
            rb.velocity = new Vector2(0, -speed);
        }
        else if (player_arm.direction == "left")
        {
            sr.sprite = sword_left2;
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (player_arm.direction == "up")
        {
            sr.sprite = sword_up2;
            rb.velocity = new Vector2(0, speed);
        }
        else if (player_arm.direction == "right")
        {
            sr.sprite = sword_right2;
            rb.velocity = new Vector2(speed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (has_shot && flying)
        {
            if (go.tag == "wall" || go.tag == "door" || go.tag == "aisle" || go.tag == "ghost" || go.tag == "oldMan" || go.tag == "wall_master")
            {
                Bang();
                endWeapons();
            }
        }
    }

    private void Bang()
    {
        Instantiate<GameObject>(bangPrefab, transform.position, Quaternion.identity);
    }
}
