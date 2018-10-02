using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour {

    private Rigidbody[] rbs;
    private SpriteRenderer[] srs;
    private int multiplier = 2;

    private float start_time;
    private float fading_time = 0.2f;
    private bool has_faded = false;
    private float destroy_time = 0.5f;

    // Use this for initialization
    void Start () {
        rbs = GetComponentsInChildren<Rigidbody>();
        srs = GetComponentsInChildren<SpriteRenderer>();
        rbs[0].velocity = new Vector2(-1, 1) * multiplier;
        rbs[1].velocity = new Vector2(1, 1) * multiplier;
        rbs[2].velocity = new Vector2(-1, -1) * multiplier;
        rbs[3].velocity = new Vector2(1, -1) * multiplier;
        start_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if (!has_faded && Time.time - start_time > fading_time)
        {
            foreach (SpriteRenderer sr in srs)
            {
                sr.sortingOrder = -1;
            }
            has_faded = true;
        }

        if (Time.time - start_time > destroy_time)
        {
            Destroy(gameObject);
        }
	}
}
