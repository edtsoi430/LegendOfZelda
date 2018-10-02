using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldmanTriggerControl : MonoBehaviour {
    public AudioClip enterOldManRoom_sound;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(count == 0){
                AudioSource.PlayClipAtPoint(enterOldManRoom_sound, Camera.main.transform.position);
                count++;
            }
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.GetComponent<typeInEffect>().triggered = true;
            //if (GameObject.Find("Text").GetComponent<typeInEffect>().count == 0)
            //{
                GameObject.Find("Player").GetComponent<ArrowKeyMovement>().enter_oldMan = false;
           // }
            gameObject.SetActive(false);
        }
    }
}
