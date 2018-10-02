using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazhinv : MonoBehaviour {

    public GameObject player;
    public GameObject jiguang_prefab;

    private float start_time;
    private float flashing_start;
    private float life_time = 0.5f;
    private float flashing_time = 0.03f;
    private Color orignal_color;
    private Color flashing_color;

    private SpriteRenderer sr;

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.Find("Player");
        start_time = Time.time;
        flashing_start = Time.time;
        sr = GetComponent<SpriteRenderer>();
        orignal_color = sr.color;
        flashing_color = orignal_color;
        flashing_color.a = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 7);

        if (Time.time - start_time > life_time)
        {
            EndBazhinv();
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

    private void EndBazhinv()
    {
        Destroy(gameObject);
        Instantiate<GameObject>(jiguang_prefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Player")
        {
            EndBazhinv();
        }
    }
}
