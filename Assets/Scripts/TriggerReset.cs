using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReset : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (enemy.activeSelf)
        {
            enemy.SetActive(false);
        }
    }

}
