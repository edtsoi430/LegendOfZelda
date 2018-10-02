using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public CamFollowing main_camera;
    public Text health_text;
    public GameObject dead_curtain;
    public GameObject black;
    public MotionControl mc;

    public float full_health;
    public float current_health;
    public bool invincible;
    
    public AudioClip pick_up_heart_sound;
    public AudioClip pick_up_bomb_sound;
    public AudioClip almostDie_sound;
    public AudioClip die_sound;
    public AudioClip disappear_sound;
    public AudioClip goldBackground_sound;

    public audioPlay aud;

    public Sprite faceUp;
    public Sprite faceDown;
    public Sprite faceLeft;
    public Sprite faceRight;
    public Sprite disappear1;
    public Sprite disappear2;

    public GameObject deadCanvas;
    public ArrowKeyMovement arm;

    private IEnumerator coroutine;
    private int count = 0;
    private bool damaged;

    void Awake() {
        current_health = 3f;
        full_health = 3f;

        health_text.text = "Health: " + current_health.ToString() + " / " + full_health.ToString();
        arm = GetComponent<ArrowKeyMovement>();
    }

    IEnumerator Blink(float time)
    {
        for (int i = 0; i < 20; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update()
    {
        if (arm.dead && Input.GetKeyDown(KeyCode.Space))
        {
            restart();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            invincible = true;
            GetComponent<Inventory>().AddRupees(99);
            GetComponent<Inventory>().AddKeys(99);
            GetComponent<Inventory>().AddBombs(99);
        }

        if (current_health <= 0 && count == 0)
        {
            PlayerDead();
            count++;
        }

        if(damaged)
        {
            damaged = false;
            coroutine = Blink(0.0005f);
            StartCoroutine(coroutine);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            GameObject Iori = GameObject.Find("Iori");
            Iori.GetComponent<MotionControl>().Level1();
            main_camera.gameObject.transform.position = new Vector3(23.5f, -4f, -20f);
            arm.gold = true;
            coroutine = Wait();
            StartCoroutine(coroutine);
            aud.PlayBackgroundAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "aisle")
        {
            main_camera.moveCam();
        }

        if (go.tag == "enterBowRoom"){
            main_camera.transform.position = new Vector3(-4.5f, 44f, -20f);
            transform.position = new Vector3(-10f, 45f, 0);
        }
        if (go.tag == "backTo")
        {
            main_camera.transform.position = new Vector3(39.5f, 62f, -20f);
            transform.position = new Vector3(39, 60, 0);
        }

        if (go.tag == "heart")
        {
            IncrementHealth(current_health, full_health);
            health_text.text = "Health: " + current_health.ToString() + " / " + full_health.ToString();
            Destroy(go);
            AudioSource.PlayClipAtPoint(pick_up_heart_sound, Camera.main.transform.position);
        }

        if (go.tag == "wall_master")
        {
            arm.catching = true;
            arm.GetCaught(go);
        }

        if (go.tag == "bomb")
        {
            Destroy(go);
            AudioSource.PlayClipAtPoint(pick_up_bomb_sound, Camera.main.transform.position);
        }

        if (go.tag == "boomerangC")
        {
            Destroy(go);
            GetComponent<WeaponControl>().has_boomerang = true;
            AudioSource.PlayClipAtPoint(pick_up_bomb_sound, Camera.main.transform.position);
        }

        if (go.tag == "bowC")
        {
            Destroy(go);
            GetComponent<WeaponControl>().has_bow = true;
            AudioSource.PlayClipAtPoint(pick_up_bomb_sound, Camera.main.transform.position);
        }


        if (go.tag == "big_heart")
        {
            Destroy(go);
            full_health++;
            health_text.text = "Health: " + current_health.ToString() + " / " + full_health.ToString();
            AudioSource.PlayClipAtPoint(pick_up_bomb_sound, Camera.main.transform.position);
        }

        if (go.tag == "full_health")
        {
            Destroy(go);
            current_health = full_health;
            health_text.text = "Health: " + current_health.ToString() + " / " + full_health.ToString();
            AudioSource.PlayClipAtPoint(pick_up_bomb_sound, Camera.main.transform.position);
        }

        if (go.tag == "gold") {
         //   GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
            GameObject Iori = GameObject.Find("Iori");
            Iori.GetComponent<MotionControl>().Level1();
            main_camera.gameObject.transform.position = new Vector3(23.5f, -4f, -20f);
            arm.gold = true;
            coroutine = Wait();
            StartCoroutine(coroutine);
            aud.PlayBackgroundAudio();
        }

    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
        main_camera.gameObject.transform.position = new Vector3(7.5f, -4f, -20f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "ghost" || go.tag == "Iori" || go.tag == "Iori2")
        {
            if(invincible == false)
            {
                if (go.tag == "Iori2")
                {
                    current_health = current_health - 1f;
                }
                else
                {
                    current_health = current_health - 0.5f;
                }
                if (current_health <= 0)
                {
                    health_text.text = "Health: 0" + " / " + full_health.ToString();
                    if (go.tag == "ghost")
                    {
                        PlayerDead();
                    }
                    else 
                    {
                        arm.gold = true;
                        mc.ResetLevel();
                    }
                }
                else if(current_health > 0){
                    health_text.text = "Health: " + current_health.ToString() + " / " + full_health.ToString();
                }
                invincible = true;
                damaged = true;
                arm.knockingBack();
                coroutine = Invinciblity(1f);
                StartCoroutine(coroutine);
            }
        }
    }

    IEnumerator Invinciblity (float time)
    {
        yield return new WaitForSeconds(time);
        invincible = false;
    }

    private void PlayerDead ()
    {
        //dead_curtain.SetActive(true);
        if (count == 0)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
            if(GameObject.Find("EnemySystem") != null){
                GameObject.Find("EnemySystem").SetActive(false);
            }
            if(GameObject.Find("Dragon - prefab") != null){
                GameObject.Find("Dragon - prefab").SetActive(false);
            }
            if(GameObject.Find("oldManRoom_prefab") != null)
            {
                GameObject.Find("oldManRoom_prefab").SetActive(false);
            }
            for (int i = 0; i < 17; i++)
            {
                var childCount = GameObject.Find("Level").transform.GetChild(i).childCount + 1;
                Transform[] allChildren = GameObject.Find("Level").transform.GetChild(i).GetComponentsInChildren<Transform>();
                for (int j = 1; j < childCount; j++)
                {
                    if (allChildren[j].childCount == 0)
                    {
                        if(allChildren[j].gameObject.GetComponent<SpriteRenderer>() != null){
                            allChildren[j].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                        }
                    }
                    else
                    {
                        childCount += allChildren[j].childCount;
                        Transform[] allChildren2 = allChildren[j].gameObject.GetComponentsInChildren<Transform>();
                        if(allChildren!=null && allChildren.Length > 0){
                            for (int k = 1; k < allChildren[j].childCount + 1; k++)
                            {
                                if(allChildren2[k].gameObject.GetComponent<SpriteRenderer>() != null){
                                    allChildren2[k].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                }
                            }
                        }
                    }
                }
            }

            // GOLD
            for (int k = 0; k < 3; k++)
            {
                var childCount = GameObject.Find("GOLD").transform.GetChild(k).childCount + 1;
                Transform[] allChildren = GameObject.Find("GOLD").transform.GetChild(k).GetComponentsInChildren<Transform>();
                for (int j = 1; j < childCount; j++){
                    if (allChildren[j].gameObject.GetComponent<SpriteRenderer>() != null)
                    {
                        allChildren[j].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
            coroutine = rotateDead(0.08f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator rotateDead(float time)
    {
        GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = faceDown;
        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(die_sound, Camera.main.transform.position);

        for (int i = 0; i < 3; i++){
            gameObject.GetComponent<SpriteRenderer>().sprite = faceRight;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().sprite = faceUp;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().sprite = faceLeft;
            yield return new WaitForSeconds(time);
            gameObject.GetComponent<SpriteRenderer>().sprite = faceDown;
        }
       //GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().sprite = disappear1;
        //deadCanvas.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        arm.dead = true;
        AudioSource.PlayClipAtPoint(disappear_sound, Camera.main.transform.position);
    }

    IEnumerator DeadInfo (float time)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        arm.dead = true;
        yield return new WaitForSeconds(time);
    }

    private void restart ()
    {
        SceneManager.LoadScene("MainScene");
    }

    public bool isFullHealth()
    {
        if (current_health < full_health)
        {
            return false;
        }
        return true;
    }

    public void GoBack()
    {
        coroutine = GoBackToOriginal(2f);
        StartCoroutine(coroutine);
    }

    IEnumerator GoBackToOriginal(float time)
    {
        arm.flying = true;
        black.SetActive(true);
        GetComponent<SpriteRenderer>().sortingOrder = -99;
        transform.position = new Vector2(39.5f, 2.5f);
        main_camera.transform.position = new Vector3(39.5f, 7f, -20f);
        yield return new WaitForSeconds(time);
        arm.flying = false;
        black.SetActive(false);
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    void IncrementHealth(float currentHeath_in, float fullHealth_in)
    {
        if(Mathf.Abs(currentHeath_in - fullHealth_in) < 0.00001 || (currentHeath_in + 1) > fullHealth_in)
        {
            current_health = fullHealth_in;
        }
        else
        {
            current_health += 1;
        }
    }
}
