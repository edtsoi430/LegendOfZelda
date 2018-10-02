using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazhinvJiguang : MonoBehaviour {

    public Sprite s1;
    public Sprite s2;

    private float start_time;
    private float start_time1;
    private float start_time2;
    private float flashing_start;
    private float start_move;
    private float duration_time = 1.8f;
    private float sprite_time = 0.05f;
    private float flashing_time = 0.03f;
    private float move_time = 0.8f;
    private float life_time = 5f;
    private Color orignal_color;
    private Color flashing_color;

    private SpriteRenderer sr;
    private BoxCollider bc;
    private Vector2 original_position;
    private Vector2 final_position;
    private bool set;

    // Use this for initialization
    void Awake()
    {
        start_time = Time.time;
        start_time1 = Time.time;
        start_time2 = Time.time + duration_time;
        flashing_start = Time.time;
        start_move = Time.time;
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider>();
        orignal_color = sr.color;
        flashing_color = orignal_color;
        flashing_color.a = 0;
        set = false;
        original_position = transform.position;
        final_position = original_position + randomMove();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 10);

        if (Time.time - start_time > life_time)
        {
            Destroy(gameObject);
        }

        if (Time.time - start_move > move_time)
        {
            start_move = Time.time;
            original_position = transform.position;
            final_position = original_position + randomMove();
        }
        if (Time.time - start_time1 > duration_time)
        {
            sr.sprite = s1;
            if (!set)
            {
                Vector3 pos = transform.position;
                pos.y += 1;
                transform.position = pos;
                set = true;
                bc.size = new Vector3(0.1f, 0.85f, 0.2f);
            }
        }
        if (Time.time - start_time2 > sprite_time)
        {
            start_time2 = Time.time;
            if (sr.sprite == s1)
            {
                sr.sprite = s2;
            }
            else
            {
                sr.sprite = s1;
            }
        }
        if (Time.time - flashing_start > flashing_time)
        {
            flashing_start = Time.time;
            if (sr.color == flashing_color)
            {
                sr.color = orignal_color;
            }
            else
            {
                sr.color = flashing_color;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Player")
        {
            go.GetComponent<Player>().current_health -= 1;
        }
    }

    public Vector2 randomMove()
    {
        int x = 0;
        int y = 0;
        int random = Random.Range(0, 4);

        if (random == 0)
        {
            x = -1;
            y = 0;
        }
        else if (random == 1)
        {
            x = 0;
            y = -1;
        }
        else if (random == 2)
        {
            x = 1;
            y = 0;
        }
        else if (random == 3)
        {
            x = 0;
            y = 1;
        }
        return new Vector2(x, y);
    }
}
