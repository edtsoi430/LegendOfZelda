using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public WeaponType type;
    public float start_time;
    public float holding_time;
    public int speed;
    public int layer_number;

    public bool has_shot;

    public GameObject player;
    public ArrowKeyMovement player_arm;
    public Transform player_tf;
    public WeaponControl player_wc;
    public SpriteRenderer sr;
    public Rigidbody rb;

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.Find("Player");
        player_arm = player.GetComponent<ArrowKeyMovement>();
        player_tf = player.GetComponent<Transform>();
        player_wc = player.GetComponent<WeaponControl>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        start_time = Time.time;
    }

    public virtual void spawnWeapons()
    {

    }

    public virtual void shootWeapon()
    {

    }

    public virtual void endWeapons()
    {
        player_wc.weapon_using = false;
        Destroy(gameObject);
    }
}
