using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldManFireControl : MonoBehaviour {
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject fire_child;

    private GameObject fire_out;

    private Sprite lastSprite;

    private float startTime = 0.0f;
    private float duration_time = 0.08f;

    private float fire_startTime = 0.0f;
    private float fire_duration_time = 1.5f;

    private GameObject oldMan;

    private void Start()
    {
        lastSprite = sprite1;
        oldMan = GameObject.Find("oldManRoom_prefab").transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void Update () {
		if(Time.time - startTime > duration_time)
        {
            startTime = Time.time;
            if(lastSprite == sprite1)
            {
                GetComponent<SpriteRenderer>().sprite = sprite2;
                lastSprite = sprite2;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprite1;
                lastSprite = sprite1;
            }
        }
        // 
        if(oldMan.GetComponent<oldManControl>().damageTriggered == true)
        {
            if(Time.time - fire_startTime > fire_duration_time){
                fire_startTime = Time.time;
                fire_out = Instantiate<GameObject>(fire_child, transform.position, Quaternion.identity);
                var diff = GameObject.Find("Player").transform.position - gameObject.transform.position;
                var target = (diff / diff.magnitude);
                fire_out.GetComponent<Rigidbody>().velocity = target * 4f;
            }
        }
	}
}
