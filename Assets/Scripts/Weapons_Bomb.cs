using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons_Bomb : Weapons {

    public GameObject explosivePrefab;

    private void Start()
    {
        spawnWeapons();
        type = WeaponType.bomb;
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
            Instantiate<GameObject>(explosivePrefab, transform.position, Quaternion.identity);
            endWeapons();
        }
    }

    public override void spawnWeapons()
    {
        base.spawnWeapons();
        layer_number = 2;

        if (player_arm.direction == "up")
        {
            layer_number = 1;
        }

        sr.sortingOrder = layer_number;
    }

    public override void shootWeapon()
    {
        base.shootWeapon();
    }

}
