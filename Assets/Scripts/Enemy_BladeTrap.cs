using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BladeTrap : Enemy {

    public string direction1;
    public string direction2;

    private bool trap_trigger = false;
    private bool returning = false;
    private Vector3 direc1;
    private Vector3 direc2;
    private Vector3 final_position;
    private Vector3 original_position;

    // Use this for initialization
    void Start () {
        movement = Vector2.zero;
        speed = 6f;
        health = 1000;
        original_position = transform.position;
        direc1 = SetDirction(direction1);
        direc2 = SetDirction(direction2);
    }
	
	// Update is called once per frame
	public override void Update () {
        if (!trap_trigger)
        {
            Detection(direc1);
            Detection(direc2);
        }
        else
        {
            MoveAndReturn();
        }
	}

    private Vector3 SetDirction(string direction)
    {
        if (direction == "up")
        {
            return transform.up;
        }
        else if (direction == "down")
        {
            return -transform.up;
        }
        else if (direction == "right")
        {
            return transform.right;
        }
        return -transform.right;
    }

    private void SetDestination(Vector3 direc)
    {
        final_position = original_position;
        if (direc == transform.up)
        {
            final_position.y += 2.5f;
        }
        else if (direc == -transform.up)
        {
            final_position.y += -2.5f;
        }
        else if (direc == transform.right)
        {
            final_position.x += 5f;
        }
        else final_position.x += -5f;
    }

    private void Detection(Vector3 direc)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, direc, out hit, Mathf.Infinity);
        Transform go = hit.transform;
        if (go != null && go.tag == "Player")
        {
            trap_trigger = true;
            SetDestination(direc);
        }
    }

    private void MoveAndReturn()
    {
        if (!returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, final_position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, original_position, speed * Time.deltaTime / 3);
        }

        if (transform.position == final_position)
        {
            returning = true;
        }

        if (transform.position == original_position)
        {
            trap_trigger = false;
            returning = false;
            final_position = Vector3.zero;
        }
    }
}
