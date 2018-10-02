using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Vector2 movement;
    public AudioClip die_sound;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Sprite last_sprite;

    public float speed;
    public float flashing_time;
    public float duration_time;
    public float sprite_time;
    public float start_time;
    public int health;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        last_sprite = sr.sprite;
        sprite_time = Time.time;
        start_time = Time.time;
    }


    // Update is called once per frame
    public virtual void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(die_sound, Camera.main.transform.position);
        }

    }

    public virtual Vector2 randomMove()
    {
        return new Vector2(0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            health--;
        }
        if (go.tag == "explosive")
        {
            Debug.Log(health);
            health = 0;
        }
    }

}
