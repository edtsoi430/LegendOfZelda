using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public int speed;
    private Rigidbody[] rbs;
    private Vector3 diff;
    private void Awake()
    {
        speed = 5;
        diff = GameObject.Find("Player").transform.position - transform.position;
        rbs = GetComponentsInChildren<Rigidbody>();
        rbs[0].velocity = (speed * diff)/diff.magnitude;
        rbs[1].velocity = (speed * diff)/diff.magnitude;
        rbs[2].velocity = (speed * diff)/diff.magnitude;
    }
}
