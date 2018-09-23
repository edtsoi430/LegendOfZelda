using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{


    public bool sword = false;
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

    private float fullHealth = 3.0f;
    // access ArrowKeymovement

    private void Start()
    {
        ARM = GetComponent<ArrowKeyMovement>();
        sr.SetActive(false);
        sl.SetActive(false);
        sd.SetActive(false);
        su.SetActive(false);
        // originalRPos = sr.transform.position;
    }
    float startTime = 0.0f;
    float deactiveTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (GameObject.Find("Player").GetComponent<Player>().health == fullHealth)
        {
            deactiveTime = 0.8f;
        }
        */
        if (startTime != 0.0f && Time.time - startTime > deactiveTime)
        {
            if (GameObject.Find("Player").GetComponent<Player>().health == fullHealth)
            {
                sword_out.SetActive(false);
            }
            sr.SetActive(false);
            sl.SetActive(false);
            su.SetActive(false);
            sd.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X) && !ARM.inMoving)
        {
            // Sword
            if (GetComponent<ArrowKeyMovement>().direction == "right" && sr.activeSelf == false)
            {
                startTime = Time.time;
                sr.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(sr);
                    sr.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;

                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(15, 0);
                }
                // sr.SetActive(false);
            }
            else if (GetComponent<ArrowKeyMovement>().direction == "left" && sr.activeSelf == false)
            {
                startTime = Time.time;
                sl.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(sl);
                    sl.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;

                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(-15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(-15, 0);
                }
            }
            else if (GetComponent<ArrowKeyMovement>().direction == "up" && su.activeSelf == false)
            {
                startTime = Time.time;
                su.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(su);
                    su.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 15);
                }
            }
            else if (GetComponent<ArrowKeyMovement>().direction == "down" && sd.activeSelf == false)
            {
                startTime = Time.time;
                sd.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(sd);
                    sd.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, -15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, -15);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Z) && GetComponent<Inventory>().GetRupees() > 0 && !ARM.inMoving)
        {
            GetComponent<Inventory>().AddRupees(-1);
            if (GameObject.Find("Player").GetComponent<ArrowKeyMovement>().direction == "right")
            {
                startTime = Time.time;
                rr.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(rr);
                    rr.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;

                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(15, 0);
                }
            }
            else if (GameObject.Find("Player").GetComponent<ArrowKeyMovement>().direction == "left")
            {
                startTime = Time.time;
                rl.SetActive(true);
                // if full health
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(rl);
                    rl.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;

                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(-15, 0, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(-15, 0);
                }
            }
            else if (GameObject.Find("Player").GetComponent<ArrowKeyMovement>().direction == "up")
            {
                startTime = Time.time;
                ru.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(ru);
                    ru.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, 15);
                }
            }
            else
            {
                startTime = Time.time;
                rd.SetActive(true);
                if (GameObject.Find("Player").GetComponent<Player>().health == 3.0f)
                {
                    sword_out = Instantiate<GameObject>(rd);
                    rd.SetActive(false);
                    sword_out.transform.position = GameObject.Find("Player").transform.position;
                    sword_out.GetComponent<Rigidbody>().AddForce(new Vector3(0, -15, 0));
                    sword_out.GetComponent<Rigidbody>().velocity = new Vector2(0, -15);
                }

            }
        }

        //if (Input.GetKeyUp(KeyCode.X)){
        //    //GameObject.Find("Player").SetActive(true);
        //    sr.SetActive(false);
        //    sl.SetActive(false);
        //    su.SetActive(false);
        //    sd.SetActive(false);
        //}

        //if (Input.GetKeyUp(KeyCode.X))
        //{
        //    sword = false;
        //}
    }

}
