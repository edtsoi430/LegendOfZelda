using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostControl : MonoBehaviour
{
    public float accTime = 0.0000000001f;
    public float speed = 10f;
    private Rigidbody rb;
    private float start_time = 0.0f;
    private float duration_time = 2f;
    private float health = 2.0f;
    private Vector2 movement;

    float x = 0.0f;
    float y = 0.0f;
    public int alt = 0;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomMove();
        rb.velocity = movement * 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        if (Time.time - start_time > duration_time)
        {
            randomMove();
            rb.velocity = movement * 4;
        }
    }

    private void randomMove()
    {

        alt = Random.Range(1, 5);

        if (alt == 1)
        {
            x = -1f;
            y = 0f;

        }
        else if (alt == 2)
        {
            x = 0f;
            y = -1f;

        }
        else if (alt == 3)
        {
            x = 1f;
            y = 0f;

        }
        else if(alt == 4)
        {
            x = 0f;
            y = 1f;
        }

        movement = new Vector2(x, y);

        start_time = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            health--;
            other.gameObject.SetActive(false);
        }
    }
}
