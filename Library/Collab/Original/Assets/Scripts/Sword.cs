using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool weapon_using = false;

    public bool sword = false;

    public Sprite orignal_right;
    public Sprite sword_right;
    public Sprite orignal_left;
    public Sprite sword_left;
    public Sprite orignal_up;
    public Sprite sword_up;
    public Sprite orignal_down;
    public Sprite sword_down;

    public GameObject sr;
    public GameObject sl;
    public GameObject sd;
    public GameObject su;

    public GameObject rr;
    public GameObject rl;
    public GameObject rd;
    public GameObject ru;

    private static Vector3 originalRPos;
    private GameObject sword_out;
    private ArrowKeyMovement ARM;
    float startTime = 0.0f;
    float deactiveTime = 0.5f;

    //    private float fullHealth = 3.0f;

    private void Start()
    {
        ARM = GetComponent<ArrowKeyMovement>();
        sr.SetActive(false);
        sl.SetActive(false);
        sd.SetActive(false);
        su.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime != 0.0f && Time.time - startTime > deactiveTime)
        {
            Destroy(sword_out);
            sr.SetActive(false);
            sl.SetActive(false);
            su.SetActive(false);
            sd.SetActive(false);
            //
            weapon_using = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && !ARM.camera_moving && sword_out == null)
        {
            weapon_using = true;
            startTime = Time.time;
            // Sword
            if (ARM.direction == "right" && sr.activeSelf == false)
            {
                deactiveTime = 0.5f;
                sr.SetActive(true);
                sword_out = Instantiate<GameObject>(sr);
                sr.SetActive(false);
                if (GameObject.Find("Player").GetComponent<Player>().current_health == 3.0f)
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(15, 0);
                }
                else
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position + new Vector3(0.8f, 0, 0);
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
                }
            }
            else if (ARM.direction == "left" && sr.activeSelf == false)
            {
                sl.SetActive(true);
                sword_out = Instantiate<GameObject>(sl);
                sl.SetActive(false);
                if (GameObject.Find("Player").GetComponent<Player>().current_health == 3.0f)
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(-15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(-15, 0);
                }
                else
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position + new Vector3(-0.8f, 0, 0);
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
                }
            }
            else if (ARM.direction == "up" && su.activeSelf == false)
            {
                su.SetActive(true);
                sword_out = Instantiate<GameObject>(su);
                su.SetActive(false);
                if (GameObject.Find("Player").GetComponent<Player>().current_health == 3.0f)
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 15);
                }
                else
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 0.8f, 0);
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
                }
            }
            else if (ARM.direction == "down" && sd.activeSelf == false)
            {
                sd.SetActive(true);
                sword_out = Instantiate<GameObject>(sd);
                sd.SetActive(false);
                if (GameObject.Find("Player").GetComponent<Player>().current_health == 3.0f)
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, -15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, -15);
                }
                else
                {
                    sword_out.transform.position = GameObject.Find("Player").transform.position + new Vector3(0, -0.8f, 0);
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && GetComponent<Inventory>().GetRupees() > 0 && !ARM.camera_moving && sword_out == null)
        {
            deactiveTime = 0.3f;
            startTime = Time.time;
            weapon_using = true;
            GetComponent<Inventory>().AddRupees(-1);
            if (ARM.direction == "right")
            {
                rr.SetActive(true);
                sword_out = Instantiate<GameObject>(rr);
                rr.SetActive(false);
                sword_out.transform.position = GameObject.Find("Player").transform.position;

                sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0));
                sword_out.GetComponent<Rigidbody>().velocity = new Vector2(15, 0);
            }
            else if (ARM.direction == "left")
            {
                rl.SetActive(true);
                sword_out = Instantiate<GameObject>(rl);
                rl.SetActive(false);
                sword_out.transform.position = GameObject.Find("Player").transform.position;

                sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(-15, 0, 0));
                sword_out.GetComponent<Rigidbody>().velocity = new Vector2(-15, 0);
            }
            else if (ARM.direction == "up")
            {
                ru.SetActive(true);
                sword_out = Instantiate<GameObject>(ru);
                ru.SetActive(false);
                sword_out.transform.position = GameObject.Find("Player").transform.position;

                sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0));
                sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 15);
            }
            else if (ARM.direction == "down")
            {
                rd.SetActive(true);
                sword_out = Instantiate<GameObject>(rd);
                rd.SetActive(false);
                sword_out.transform.position = GameObject.Find("Player").transform.position;

                sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, -15, 0));
                sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, -15);
            }
        }
    }

}
