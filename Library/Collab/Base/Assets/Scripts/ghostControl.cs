using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostControl : MonoBehaviour
{
    public float accTime = 0.0000000001f;
    public float speed = 10f;
    private Rigidbody rb;
    private float timeLeft = 0.0f;
    private float health = 2.0f;
    private Vector2 movement;

    float x = 0.0f;
    float y = 0.0f;
    public int alt = 0;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //alt = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        alt = Random.Range(1, 5);
        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        if (timeLeft <= 0)
        {
            if (alt == 1)
            {
                x = -28f;
                y = 0f;

            }
            else if (alt == 2)
            {
                x = 0f;
                y = -28f;

            }
            else if (alt == 3)
            {
                x = 28f;
                y = 0f;

            }
            else
            {
                x = 0f;
                y = 28f;
            }
            movement = new Vector2(x, y);
            timeLeft += accTime;
        }
    }

    void FixedUpdate()
    {
        //if(Mathf.Abs(movement.x) > 0f)
        //{
        //    movement.y = 0.0f;
        //}
        //else{
        //    movement.x = 0.0f;
        //}
        if (this.gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            rb.AddForce(movement * speed);
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
