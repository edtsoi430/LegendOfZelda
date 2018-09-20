using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public CamFollowing cm;
    public Text health_text;
    public GameObject dead_curtain;

    public float health;
    public bool invincible;

    private IEnumerator coroutine;
    // private GameObject player;

    // Use this for initialization
    void Awake() {
        // player = GetComponent<GameObject>();

        // testing purposes
             //health = 2;
        //end testing

        health = 3f;
    
        health_text.text = "Health: " + health.ToString();
	}

    private void Update()
    {
        if (GetComponent<ArrowKeyMovement>().dead && Input.GetKeyDown(KeyCode.Space))
        {
            restart();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            invincible = true;
            GetComponent<Inventory>().AddRupees(99);
            GetComponent<Inventory>().AddKeys(99);
            GetComponent<Inventory>().AddBombss(99);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "aisle")
        {
            cm.moveCam();
        }

        if (go.tag == "heart")
        {
            health = 3;
            health_text.text = "Health: " + health.ToString();
            Destroy(go);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "ghost" && invincible == false)
        {
            health = health - 0.5f;
            if (health <= 0) playerDead();
            health_text.text = "Health: " + health.ToString();
            GetComponent<SpriteRenderer>().color = Color.red;
            invincible = true;
            GetComponent<ArrowKeyMovement>().knockingBack();
            coroutine = invinciblity(1f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator invinciblity (float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible = false;
    }

    private void playerDead ()
    {
        dead_curtain.SetActive(true);
        coroutine = deadInfo(20f);
        StartCoroutine(coroutine);
    }

    IEnumerator deadInfo (float time)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<ArrowKeyMovement>().dead = true;
        yield return new WaitForSeconds(time);
    }

    private void restart ()
    {
        SceneManager.LoadScene("MainScene");
    }
}
