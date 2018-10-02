using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    private float duration = 0.05f;
    private float last_time;
    private bool trigger;
    private SpriteRenderer[] srs;

    private float destroy_time = 0.25f;
    private float start_time;

    // Use this for initialization
    void Start ()
    {
        start_time = Time.time;
        last_time = Time.time;
        trigger = false;
        srs = GetComponentsInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time - last_time > duration)
        {
            last_time = Time.time;
            if (!trigger)
            {
                foreach (SpriteRenderer sr in srs)
                {
                    sr.color = new Color(1, 1, 1, 0);
                }
                trigger = true;
            }
            else
            {
                foreach (SpriteRenderer sr in srs)
                {
                    sr.color = new Color(1, 1, 1, 0.75f);
                }
                trigger = false;
            }
        }

        if (Time.time - start_time > destroy_time)
        {
            Destroy(gameObject);
        }
    }
}
