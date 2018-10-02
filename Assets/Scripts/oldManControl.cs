using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldManControl : MonoBehaviour {
    public bool damageTriggered;
    private IEnumerator coroutine;

    private void Start()
    {
        damageTriggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon_damage")
        {
            damageTriggered = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            coroutine = Invinciblity(0.2f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator Invinciblity(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
