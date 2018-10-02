using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockControlOld : MonoBehaviour {
    public Transform t1_up;
    public Transform t2_down;
    public Transform t3_left;
    public Transform t4_right;

    public GameObject gel1;
    public GameObject gel2;
    public GameObject gel3;

    public AudioClip moveBlock_sound;

    private bool blockMovable = false;
    public int count = 0;
    private void Update()
    {
        if(gel1 == null && gel2 == null && gel3 == null){
            blockMovable = true;
        }

        if(transform.position == t1_up.transform.position || transform.position == t2_down.transform.position || transform.position == t3_left.transform.position || transform.position == t4_right.transform.position)
        {
            if(count == 1)
            {
                AudioSource.PlayClipAtPoint(moveBlock_sound, Camera.main.transform.position);
                count++;
            }
            blockMovable = false;
            var c = GameObject.Find("Player").GetComponent<Collector>();
            var sr = GameObject.Find("Door (1)").GetComponentsInChildren<SpriteRenderer>();
            GameObject.Find("Door (1)").GetComponent<BoxCollider>().enabled = false;
            sr[1].sprite = c.d3;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && blockMovable)
        {
            if (Mathf.Abs(transform.position.y - collision.gameObject.transform.position.y) >= 0.4)
            {
                if (collision.gameObject.transform.position.y > transform.position.y)
                {
                    transform.position = Vector3.MoveTowards(transform.position, t2_down.transform.position, Time.deltaTime * 8);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, t1_up.transform.position, Time.deltaTime * 8);
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.x - collision.gameObject.transform.position.x) >= 0.4)
                {
                    if (collision.gameObject.transform.position.x > transform.position.x)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, t3_left.transform.position, Time.deltaTime * 8);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, t4_right.transform.position, Time.deltaTime * 8);
                    }
                }
            }

            if(count == 0){
                count++;
            }
        }
    }
}
