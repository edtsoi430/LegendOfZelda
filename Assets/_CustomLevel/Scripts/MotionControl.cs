using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {

    public GameObject player;
    public ArrowKeyMovement player_arm;
    public Inventory player_inventory;
    public Player player_p;
    public GameObject canvas;
    public GameObject cam;
    public GameObject c;
    public GameObject wusao;
    public GameObject bazhinv;
    public GameObject WinL;
    public bool trigger;
    public int level;
    public int damaged;

    public AudioClip dipan_sound;
    public AudioClip feibiao_sound;
    public AudioClip taoDang_sound;

    private float health;
    private float start_time;
    private float duration_time;
    private float start_acting;
    private float acting_time;
    private float speed;
    
    private Transform player_transform;
    private ConversationControl cc;
    private Rigidbody rb;
    private AnimationControl ac;

    private bool chu_zhao;
    private bool reset;
    private int bomb_number;
    private float enter_health;
    private Vector3 direction = Vector3.zero;
    private Vector3 facing;

    private IEnumerator coroutine;

    private void Awake()
    {
        damaged = 1;

        player_transform = player.GetComponent<Transform>();
        cc = canvas.GetComponent<ConversationControl>();
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AnimationControl>();

        trigger = false;
        chu_zhao = false;
        reset = false;
    }

    private void Update()
    {
        //Debug.Log(health);
        if (trigger && Time.time - start_time > duration_time)
        {
            start_time = Time.time;
            Direction();
            CheckDirection();
            ChuZhao();
        }

        if (chu_zhao && Time.time - start_acting <= acting_time)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            chu_zhao = false;
            rb.velocity = Vector3.zero;
        }

        if (health < 0 && level == 1)
        {
            trigger = false;
            player_arm.gold = true;
            ac.SetLose();
            health = 100000;
            cc.Text2();
            Invoke("Level2", 8);
        }
        if (health < 0 && level == 2)
        {
            trigger = false;
            player_arm.gold = true;
            ac.SetLose();
            health = 100000;
            cc.Text2();
            Invoke("Level3", 8);
        }
        if (health < 0 && level == 3)
        {
            trigger = false;
            player_arm.gold = true;
            ac.SetLose();
            health = 100000;
            cc.Text4();
            Invoke("Win", 8);
            player_p.GetComponent<Player>().arm.dead = true;
        }
    }

    private void Direction()
    {
        Vector3 player_position = player_transform.position;
        direction.x = player_position.x - transform.position.x;
        direction.y = player_position.y - transform.position.y;
        direction = direction.normalized;
    }

    private void CheckDirection()
    {
        if (direction.x < 0)
        {
            facing = transform.rotation.eulerAngles;
            facing.y = 180;
            transform.rotation = Quaternion.Euler(facing);

        }
        else if (direction.x > 0)
        {
            facing = transform.rotation.eulerAngles;
            facing.y = 0;
            transform.rotation = Quaternion.Euler(facing);
        }
    }

    private void ChuZhao()
    {
        chu_zhao = true;
        int num;
        if (level == 1) {
            num = Random.Range(0, 3);
        }
        else if (level == 2)
        {
            num = Random.Range(1, 5);
        }
        else
        {
            num = Random.Range(2, 7);
        }

        if (num == 0)
        {
            ac.SetDipan();
            speed = 6f;
            start_acting = Time.time;
            acting_time = 1;
            AudioSource.PlayClipAtPoint(dipan_sound, Camera.main.transform.position);
        }
        else if (num == 1)
        {
            ac.SetTaodang();
            speed = 10f;
            start_acting = Time.time;
            acting_time = 1;
            AudioSource.PlayClipAtPoint(taoDang_sound, Camera.main.transform.position);
        }
        else if (num == 2)
        {
            ac.SetXiapan();
            speed = 15f;
            start_acting = Time.time;
            acting_time = 1;
            AudioSource.PlayClipAtPoint(dipan_sound, Camera.main.transform.position);
        }
        else if (num == 3 || num == 4)
        {
            ac.SetFeibiao();
            speed = 3f;
            start_acting = Time.time;
            acting_time = 0.8f;
            Invoke("GenerationWusuo", 0.8f);
            AudioSource.PlayClipAtPoint(feibiao_sound, Camera.main.transform.position);
        }
        else if (num == 5 || num == 6)
        {
            ac.SetBazhinv();
            speed = 5f;
            start_acting = Time.time;
            acting_time = 0.8f;
            Invoke("GenerationBazhinv", 0.8f);
            AudioSource.PlayClipAtPoint(dipan_sound, Camera.main.transform.position);
        }
    }

    public void Level1()
    {
        level = 1;
        c.GetComponent<Closing>().ResetOpen();
        c.GetComponent<Closing>().Close();
        coroutine = Level1Set();
        StartCoroutine(coroutine);
    }

    public void Level2()
    {
        level = 2;
        c.GetComponent<Closing>().ResetOpen();
        c.GetComponent<Closing>().Close();
        coroutine = Level2Set();
        StartCoroutine(coroutine);
    }

    public void Level3()
    {
        level = 3;
        c.GetComponent<Closing>().ResetOpen();
        c.GetComponent<Closing>().Close();
        coroutine = Level3Set();
        StartCoroutine(coroutine);
    }

    public void Win()
    {
        WinL.SetActive(true);
    }

    IEnumerator Level1Set()
    {
        yield return new WaitForSeconds(3);
        Vector3 pos = new Vector3(4.5f, -5.5f, 0);
        transform.position = pos;

        pos = new Vector3(12f, -6f, 0);
        player.transform.position = pos;
        
        pos = new Vector3(7.5f, -4f, -20f);
        cam.transform.position = pos;

        health = 10f;
        start_time = Time.time;
        duration_time = 3f;
        speed = 6f;

        ac.SetIdle();

        yield return new WaitForSeconds(3);
        if (!reset)
        {
            cc.Text1();
        }
        else
        {
            player_arm.gold = false;
            trigger = true;
        }
        reset = false;
    }

    IEnumerator Level2Set()
    {
        yield return new WaitForSeconds(3);
        Vector3 pos = new Vector3(4.5f, 5.5f, 0);
        transform.position = pos;

        pos = new Vector3(12f, 5f, 0);
        player.transform.position = pos;

        pos = new Vector3(7.5f, 7f, -20f);
        cam.transform.position = pos;

        health = 25f;
        start_time = Time.time;
        duration_time = 2.2f;
        speed = 6f;

        ac.SetIdle();

        yield return new WaitForSeconds(3);
        if (!reset)
        {
            cc.Text3();
        }
        else
        {
            player_arm.gold = false;
            trigger = true;
        }
        reset = false;
    }

    IEnumerator Level3Set()
    {
        yield return new WaitForSeconds(3);
        Vector3 pos = new Vector3(4.5f, 16.5f, 0);
        transform.position = pos;
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.7f);

        pos = new Vector3(12f, 16f, 0);
        player.transform.position = pos;

        pos = new Vector3(7.5f, 18f, -20f);
        cam.transform.position = pos;

        health = 40f;
        start_time = Time.time;
        duration_time = 1.7f;
        speed = 6f;

        ac.SetIdle();

        yield return new WaitForSeconds(3);
        if (!reset)
        {
            cc.Text3();
        }
        else
        {
            player_arm.gold = false;
            trigger = true;
        }
        reset = false;
    }

    public void ResetLevel()
    {
        trigger = false;
        reset = true;
        player_inventory.SetBombs(bomb_number);
        player_p.current_health = enter_health;
        player_p.health_text.text = "Health: " + player_p.current_health.ToString() + " / " + player_p.full_health.ToString();
        if (level == 1)
        {
            Level1();
        }
        else if (level == 2)
        {
            Level2();
        }
        else if (level == 3)
        {
            Level3();
        }
    }

    public void GetBomb()
    {
        bomb_number = player_inventory.GetBombs();
        enter_health = player_p.current_health;
    }

    private void GenerationWusuo()
    {
        Vector3 pos = transform.position;
        if (direction.x >= 0)
        {
            pos.x += 1.5f;
        }
        else 
        {
            pos.x -= 1.5f;
        }

        pos.y -= 0.5f;
        Instantiate<GameObject>(wusao, pos, Quaternion.identity);
    }

    private void GenerationBazhinv()
    {
        Vector3 pos = transform.position;
        if (direction.x >= 0)
        {
            pos.x += 1.5f;
        }
        else
        {
            pos.x -= 1.5f;
        }

        pos.y -= 0.5f;
        Instantiate<GameObject>(bazhinv, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            health -= damaged;
        }
        if (go.tag == "explosive")
        {
            health -= damaged;
            health -= 2;
        }
    }
}
