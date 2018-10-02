using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    sword,
    bow,
    boomerang,
    bomb
}

public class WeaponControl : MonoBehaviour {

    public bool weapon_using;
    public bool weapon_holding;
    public bool special_using;
    public Weapons[] weapons;
    public Weapons weapon1;
    public Weapons weapon2;
    public bool has_bow;
    public bool has_boomerang;

    public AudioClip useSword_soundClip;
    public AudioClip boomerang_soundClip;
    public AudioClip bow_soundClip;

    private ArrowKeyMovement arm;
    private Transform tf;
    private Inventory inventory;

    private Vector3 pos;
    private int counter;

    private void Awake()
    {
        weapon_using = false;
        weapon_holding = false;
        weapon1 = weapons[0];
        weapon2 = weapons[3];
        arm = GetComponent<ArrowKeyMovement>();
        tf = GetComponent<Transform>();
        inventory = GetComponent<Inventory>();
        has_bow = false;
        has_boomerang = false;
        counter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !arm.camera_moving && !arm.gold && !weapon_using && !special_using)
        {
            weapon_using = true;
            weapon_holding = true;
            weaponPosition();
            Instantiate<Weapons>(weapon1, pos, Quaternion.identity);
            AudioSource.PlayClipAtPoint(useSword_soundClip, Camera.main.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Z) && !arm.camera_moving && !arm.gold && !weapon_using && !special_using)
        {
            if (weapon2.type == WeaponType.bow && inventory.GetRupees() > 0)
            {
                weapon_using = true;
                weapon_holding = true;
                weaponPosition();
                Instantiate<Weapons>(weapon2, pos, Quaternion.identity);
                inventory.AddRupees(-1);
            }
            else if (weapon2.type == WeaponType.boomerang)
            {
                weapon_using = true;
                weapon_holding = true;
                weaponPosition();
                Instantiate<Weapons>(weapon2, pos, Quaternion.identity);
                AudioSource.PlayClipAtPoint(boomerang_soundClip, Camera.main.transform.position);
                special_using = true;
            }
            else if (weapon2.type == WeaponType.bomb && inventory.GetBombs() > 0)
            {
                weapon_using = true;
                weapon_holding = true;
                weaponPosition();
                Instantiate<Weapons>(weapon2, pos, Quaternion.identity);
                inventory.AddBombs(-1);
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && !arm.camera_moving && !weapon_using && !special_using)
        {
            counter++;
            if (counter == 4)
            {
                if (has_bow)
                {
                    counter = 1;
                }
                else if (!has_bow && has_boomerang)
                {
                    counter = 2;
                }
                else {
                    counter = 3;
                }
            }
            weapon2 = weapons[counter];
        }
    }

    public void weaponPosition()
    {
        pos = tf.position;

        if (arm.direction == "down")
        {
            pos.x += 0.1f;
            pos.y -= 0.73f;
        }
        else if (arm.direction == "left")
        {
            pos.x -= 0.7f;
            pos.y -= 0.125f;
        }
        else if (arm.direction == "up")
        {
            pos.x -= 0.1f;
            pos.y += 0.73f;
        }
        else if (arm.direction == "right")
        {
            pos.x += 0.7f;
            pos.y -= 0.125f;
        }
    }

}
