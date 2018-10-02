using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSingleton : MonoBehaviour {
    public Sprite blue;
    public Sprite green;
    public Sprite red;

    private float duration = 0.10f;
    private float last_time = 0.0f;
    private Sprite last_sprite;
    private Color sprite_color;

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "wall" || go.tag == "door" || go.tag == "aisle" || go.tag == "Player")
        {
            Destroy(gameObject);
            if(go.tag == "Player" && go.GetComponent<Player>().invincible == false)
            {
                GameObject.Find("Player").GetComponent<Player>().current_health -= 0.5f;
                GameObject.Find("Player").GetComponent<Player>().health_text.text = "Health: " + GameObject.Find("Player").GetComponent<Player>().current_health.ToString();
            }
        }

    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Start()
    {
        last_sprite = blue;
        sprite_color = GetComponent<SpriteRenderer>().color;
        sprite_color = Color.blue;
    }

    private void Update()
    {
        if(Time.time - last_time > duration)
        {
            last_time = Time.time;
           if(sprite_color == Color.blue)
           {
                GetComponent<SpriteRenderer>().color = Color.green;
                sprite_color = Color.green;
           }
           else if(sprite_color == Color.green)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                sprite_color = Color.red;
            }
           else
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
                sprite_color = Color.blue;
            }
        }
    }

}
