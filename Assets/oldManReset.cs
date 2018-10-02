using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldManReset : MonoBehaviour {
    public GameObject trigger1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            trigger1.SetActive(true);
        }
    }
}
