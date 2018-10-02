using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject rupeePrefab;
    public GameObject heartPrefab;
    public GameObject bombPrefab;
    public GameObject bigHeartPrefab;
    public Vector2 movement;
    public AudioClip die_sound;
    public AudioClip knockBack_sound;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public Sprite last_sprite;

    public float speed;
    public float flashing_time;
    public float duration_time;
    public float sprite_time;
    public float start_time;
    public int health;
    public bool stop;
    public float stop_time;
    public float stop_duration;
    public bool is_boss = false;

    public Sprite d1;
    public Sprite d2;

    public bool triggeredPop;

    private bool damaged;
    private IEnumerator coroutine;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        last_sprite = sr.sprite;
        sprite_time = Time.time;
        start_time = Time.time;
        stop = false;
        stop_duration = 3;
        damaged = false;
        coroutine = Blink(0.05f);
        triggeredPop = false;
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (health == 0)
        {
            if (!is_boss)
            {
                ItemsReward();
            }
            else
            {
                BossReward();
            }
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(die_sound, Camera.main.transform.position);
        }

        if(damaged && !is_boss)
        {
            damaged = false;
            StartCoroutine(coroutine);
        }

        if(triggeredPop)
        {
            triggeredPop = false;
        }
    }

    IEnumerator Blink(float time)
    {
        for (int i = 0; i < 5; i++){
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


    public virtual Vector2 randomMove()
    {
        return new Vector2(0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            Debug.Log(10);
                health--;
                damaged = true;
                if (!is_boss)
                {
                    if (gameObject.transform.position.y - go.transform.position.y >= (gameObject.GetComponent<BoxCollider>().size.y * 0.3f))
                    {
                        rb.velocity = new Vector3(0, 1, 0) * 5;
                    }
                    else if (go.transform.position.y - gameObject.transform.position.y >= (gameObject.GetComponent<BoxCollider>().size.y * 0.3f))
                    {
                        rb.velocity = new Vector3(0, -1, 0) * 5;
                    }
                    else if (gameObject.transform.position.x - go.transform.position.x >= (gameObject.GetComponent<BoxCollider>().size.x * 0.3f))
                    {
                        rb.velocity = new Vector3(1, 0, 0) * 5;
                    }
                    else
                    {
                        rb.velocity = new Vector3(-1, 0, 0) * 5;
                    }
                    AudioSource.PlayClipAtPoint(knockBack_sound, Camera.main.transform.position);
                }
        }
        else if (go.tag == "weapon_returning")
        {
            stop = true;
            stop_time = Time.time;
        }
        else if (go.tag == "explosive")
        {
            health = 0;
        }
    }

    private void ItemsReward()
    {
        int random = Random.Range(0, 8);
        if (random == 0 && random == 1)
        {
            Instantiate(rupeePrefab, transform.position, Quaternion.identity);
        }
        else if (random == 2)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
        else if (random == 3)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }

    public void StopCheck()
    {
        if (Time.time - stop_time > stop_duration && stop)
        {
            stop = false;
        }
    }

    public void BossReward()
    {
        Instantiate(bigHeartPrefab, transform.position, Quaternion.identity);
    }
}
