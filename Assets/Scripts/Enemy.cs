using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 1f;
    // down
    public Sprite sprite1;
    public Sprite sprite2;
    public bool goriya = false;

    public string direction = "";
    public int directional = 0; // for gorilla ,directional = 1

    public float move_time;
    public float duration_time;
    public int health;
    public GameObject Goriya_weaponL;
    public GameObject Goriya_weaponR;
    public GameObject Goriya_weaponU;
    public GameObject Goriya_weaponD;
    public Animator anim;

    private float start_time = 0.0f;
    private float sprite_time = 0.0f;
    private Vector2 movement;
    private Rigidbody rb;
    private SpriteRenderer sr;
    private Sprite last_sprite;

    // 
    private GameObject weapon_out;

    // Use this for initialization

    void addForce()
    {
        rb.velocity = movement * speed;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        last_sprite = sr.sprite;
        movement = randomMove();

        if (goriya == true){
            anim = GetComponent<Animator>();
            //anim.speed = 1.0f;
            if (Mathf.Abs(movement.y) > 0)
            {
                if (movement.y > 0)
                {
                    anim.SetBool("Up", true);
                    anim.SetBool("down", false);
                }
                else
                {
                    anim.SetBool("down", true);
                    anim.SetBool("Up", false);
                    //weapon_out = Instantiate<GameObject>(Gorilla_weaponD);
                    //weapon_out.GetComponent<Rigidbody>().velocity = new Vector2(0, -5);
                }
                anim.SetBool("left", false);
                anim.SetBool("right", false);
            }
            else
            {
                if (Mathf.Abs(movement.x) > 0)
                {
                    if (movement.x > 0)
                    {
                        anim.SetBool("right", true);
                        anim.SetBool("left", false);
                    }
                    else
                    {
                        anim.SetBool("left", true);
                        anim.SetBool("right", false);
                    }
                    anim.SetBool("down", false);
                    anim.SetBool("Up", false);
                }
            }
            Invoke("addForce", 0.520f);
        }
        else{
            rb.velocity = movement * speed;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        if(rb.velocity == Vector3.zero && goriya == true){
            anim.speed = 0f;
        }
        else{
            if(goriya == true){
                anim.speed = 1.0f;
            }
        }


        if (Time.time - start_time > move_time)
        {
            start_time = Time.time;
            movement = randomMove();
            if (goriya == true){
                if (Mathf.Abs(movement.y) > 0)
                {
                    if (movement.y > 0)
                    {
                        anim.SetBool("Up", true);
                        anim.SetBool("down", false);
                        rb.velocity = movement * speed;

                        Goriya_weaponU.SetActive(true);
                        weapon_out = Instantiate<GameObject>(Goriya_weaponU);
                        Goriya_weaponU.SetActive(false);

                        weapon_out.transform.position = this.gameObject.transform.position;
                        weapon_out.transform.localScale = new Vector3(1, 1, 1);
                        weapon_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0));
                        weapon_out.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
                    }
                    else
                    {
                       
                        anim.SetBool("down", true);
                        anim.SetBool("Up", false);
                        rb.velocity = movement * speed;

                        Goriya_weaponD.SetActive(true);
                        weapon_out = Instantiate<GameObject>(Goriya_weaponD);
                        Goriya_weaponD.SetActive(false);

                        weapon_out.transform.position = this.gameObject.transform.position;
                        weapon_out.transform.localScale = new Vector3(1, 1, 1);
                        weapon_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, -5, 0));
                        weapon_out.GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 0);
                    }
                    anim.SetBool("left", false);
                    anim.SetBool("right", false);
                }
                else
                {
                    if (Mathf.Abs(movement.x) > 0)
                    {
                        if (movement.x > 0)
                        {
                            anim.SetBool("right", true);
                            anim.SetBool("left", false);
                            rb.velocity = movement * speed;

                            Goriya_weaponR.SetActive(true);
                            weapon_out = Instantiate<GameObject>(Goriya_weaponR);
                            Goriya_weaponR.SetActive(false);

                            weapon_out.transform.position = this.gameObject.transform.position;
                            weapon_out.transform.localScale = new Vector3(1, 1, 1);
                            weapon_out.GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 0));
                            weapon_out.GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
                        }
                        else
                        {
                            anim.SetBool("left", true);
                            anim.SetBool("right", false);
                            rb.velocity = movement * speed;

                            Goriya_weaponD.SetActive(true);
                            weapon_out = Instantiate<GameObject>(Goriya_weaponD);
                            Goriya_weaponD.SetActive(false);

                            weapon_out.transform.position = this.gameObject.transform.position;
                            weapon_out.transform.localScale = new Vector3(1, 1, 1);
                            weapon_out.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 0, 0));
                            weapon_out.GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
                        }
                        anim.SetBool("down", false);
                        anim.SetBool("Up", false);
                    }
                }
            }
            else{
                rb.velocity = movement * speed;
            }
        }
        if(goriya == false){
            if (Time.time - sprite_time > duration_time)
            {
                sprite_time = Time.time;

                if (last_sprite == sprite1)
                {
                    sr.sprite = sprite2;
                    last_sprite = sprite2;
                }
                else if (last_sprite == sprite2)
                {
                    sr.sprite = sprite1;
                    last_sprite = sprite1;
                }
            }
        }
    }

    public virtual Vector2 randomMove()
    {
        return new Vector2(10, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "weapon_damage")
        {
            health--;
            other.gameObject.SetActive(false);
        }
    }

}
