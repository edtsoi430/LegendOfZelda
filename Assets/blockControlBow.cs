using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockControlBow : MonoBehaviour
{
    public Transform t1_up;
    public Transform t2_down;
    public AudioClip moveBlock_sound;

    private bool blockMovable = true;
    private void Update()
    {
        if (transform.position == t1_up.transform.position || transform.position == t2_down.transform.position)
        {
            if(blockMovable)
            {
                AudioSource.PlayClipAtPoint(moveBlock_sound, Camera.main.transform.position);
            }
            blockMovable = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && blockMovable)
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
        }
    }
}
