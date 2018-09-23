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
    private Vector3 movement;

    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    public int alt = 0;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomMove();
        if ((rb.velocity.x - 0) < 0.000000000001 || (rb.velocity.y - 0) < 0.00000000000001)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.velocity = movement * 4;
        }
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
        }
    }

    private void randomMove()
    {

        alt = Random.Range(1, 5);

        if (alt == 1)
        {
            x = -1f;
            y = 0f;
            z = 0f;
        }
        else if (alt == 2)
        {
            x = 0f;
            y = -1f;
            z = 0f;
        }
        else if (alt == 3)
        {
            x = 1f;
            y = 0f;
            z = 0f;
        }
        else if(alt == 4)
        {
            x = 0f;
            y = 1f;
            z = 0f;
        }

        movement = new Vector3(x, y, z);

        start_time = Time.time;
    }
    void FixedUpdate()
    {
       if ((rb.velocity.x - 0) < 0.000000000001 || (rb.velocity.y - 0) < 0.00000000000001)
           {
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(movement * 130);
           }
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
