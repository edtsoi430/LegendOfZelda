using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wusao : MonoBehaviour {

    public GameObject player;
    public Sprite s1;
    public Sprite s2;
    public GameObject bang_prefab;

    private float start_time;
    private float start_time1;
    private float start_time2;
    private float flashing_start;
    private float duration_time = 0.4f;
    private float flashing_time = 0.04f;
    private float life_time = 1.1f;
    private Color orignal_color;
    private Color flashing_color;

    private SpriteRenderer sr;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
        start_time = Time.time;
        start_time1 = Time.time;
        start_time2 = Time.time + duration_time;
        flashing_start = Time.time;
        sr = GetComponent<SpriteRenderer>();
        orignal_color = sr.color;
        flashing_color = orignal_color;
        flashing_color.a = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 5);

        if (Time.time - start_time > life_time)
        {
            EndWusao();
        }
        if (Time.time - start_time1 > duration_time)
        {
            sr.sprite = s1;
        }
        if (Time.time - start_time2 > duration_time)
        {
            sr.sprite = s2;
        }
        if (Time.time - flashing_start > flashing_time)
        {
            flashing_start = Time.time; 
            if (sr.color == flashing_color)
            {
                sr.color = orignal_color;
            }
            else {
                sr.color = flashing_color;
            }
        }
    }

    private void EndWusao()
    {
        Destroy(gameObject);
        Instantiate<GameObject>(bang_prefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Player")
        {
            EndWusao();
        }
    }
}
