using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour {

    public GameObject enemy;
    public Sprite d2;
    private Sprite original;

    public SpriteRenderer[] srs;

    private void Awake()
    {
        srs = enemy.GetComponentsInChildren<SpriteRenderer>();
        original = enemy.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    IEnumerator PopUp(GameObject gameObject1)
    {
        gameObject1.GetComponent<SpriteRenderer>().sprite = d2;
        yield return new WaitForSeconds(0.15f);
        gameObject1.GetComponent<SpriteRenderer>().sprite = original;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enemy.activeSelf)
        {
            enemy.SetActive(true);
            if(srs != null){
                if (srs.Length == 3)
                {
                    Debug.Log(3);
                    StartCoroutine(PopUp(srs[0].gameObject));
                    StartCoroutine(PopUp(srs[1].gameObject));
                    StartCoroutine(PopUp(srs[2].gameObject));
                }
                else if (srs.Length == 5)
                {
                    StartCoroutine(PopUp(srs[0].gameObject));
                    StartCoroutine(PopUp(srs[1].gameObject));
                    StartCoroutine(PopUp(srs[2].gameObject));
                    StartCoroutine(PopUp(srs[3].gameObject));
                    StartCoroutine(PopUp(srs[4].gameObject));
                }
                else if (srs.Length == 8)
                {
                    StartCoroutine(PopUp(srs[0].gameObject));
                    StartCoroutine(PopUp(srs[1].gameObject));
                    StartCoroutine(PopUp(srs[2].gameObject));
                    StartCoroutine(PopUp(srs[3].gameObject));
                    StartCoroutine(PopUp(srs[4].gameObject));
                    StartCoroutine(PopUp(srs[5].gameObject));
                    StartCoroutine(PopUp(srs[6].gameObject));
                    StartCoroutine(PopUp(srs[7].gameObject));
                }
            }
            enemy.GetComponentInChildren<Enemy>().triggeredPop = true;
            enemy.GetComponent<EnemyControl>().SetPosition();
        }
    }
}
