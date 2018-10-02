using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ioriControl : MonoBehaviour {

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "weapon_damage"){
            StartCoroutine(Blink(0.00005f));
        }
    }
}
