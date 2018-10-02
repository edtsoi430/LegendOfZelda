using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaster : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public Enemy_WallMaster root;

    private float duration_time = 0.3f;
    private float last_time;
    private float health;
    private Sprite last_sprite;


    // Use this for initialization
    void Start()
    {
        last_time = Time.time;
        last_sprite = sprite1;
        health = 2;
       // root = gameObject.transform.parent.GetComponent<Enemy_WallMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_time > duration_time)
        {
            last_time = Time.time;
            if (last_sprite == sprite1)
            {
                GetComponent<SpriteRenderer>().sprite = sprite2;
                last_sprite = sprite2;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = sprite1;
                last_sprite = sprite1;
            }
        }

        if(health == 0f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            root.health--;
            health--;
        }
        else if (go.tag == "weapon_returning")
        {
            root.stop = true;
            root.stop_time = Time.time;
        }
        else if (go.tag == "explosive")
        {
            root.health = 0;
            health = 0;
        }
    }
}
