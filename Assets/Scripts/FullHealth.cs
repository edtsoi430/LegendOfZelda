using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealth : MonoBehaviour
{

    public Sprite red;
    public Sprite blue;

    private float duration = 0.2f;
    private float last_time;
    private Sprite last_sprite;

    // Use this for initialization
    void Start()
    {
        last_time = Time.time;
        last_sprite = red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_time > duration)
        {
            last_time = Time.time;
            if (last_sprite == red)
            {
                GetComponent<SpriteRenderer>().sprite = blue;
                last_sprite = blue;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = red;
                last_sprite = red;
            }
        }
    }
}
