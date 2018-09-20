using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowing : MonoBehaviour {

    public ArrowKeyMovement ARM;
    public GameObject player;

    private IEnumerator coroutine;
    private Vector3 player_position;
    private Vector3 final_position;
    private Vector3 inmoving_position;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (ARM.inMoving == true && inmoving_position.x < final_position.x && ARM.direction == "right")
        {
            inmoving_position = transform.position;
            inmoving_position.x = inmoving_position.x + Time.deltaTime * 8f;
            if (inmoving_position.x > final_position.x)
            {
                inmoving_position.x = final_position.x;
            }
            transform.position = inmoving_position;
        }
        else if (ARM.inMoving == true && inmoving_position.x > final_position.x && ARM.direction == "left")
        {
            inmoving_position = transform.position;
            inmoving_position.x = inmoving_position.x - Time.deltaTime * 8f;
            if (inmoving_position.x < final_position.x)
            {
                inmoving_position.x = final_position.x;
            }
            transform.position = inmoving_position;
        }
        else if (ARM.inMoving == true && inmoving_position.y < final_position.y && ARM.direction == "up")
        {
            inmoving_position = transform.position;
            inmoving_position.y = inmoving_position.y + Time.deltaTime * 6;
            if (inmoving_position.y > final_position.y)
            {
                inmoving_position.y = final_position.y;
            }
            transform.position = inmoving_position;
        }
        else if (ARM.inMoving == true && inmoving_position.y > final_position.y && ARM.direction == "down")
        {
            inmoving_position = transform.position;
            inmoving_position.y = inmoving_position.y - Time.deltaTime * 6;
            if (inmoving_position.y < final_position.y)
            {
                inmoving_position.y = final_position.y;
            }
            transform.position = inmoving_position;
        }
    }

    public void moveCam()
    {
        player.GetComponent<SpriteRenderer>().sortingOrder = -99;
        ARM.inMoving = true;
        final_position = transform.position;
        inmoving_position = transform.position;
        if (ARM.direction == "right")
        {
            final_position.x = final_position.x + 16f;
            coroutine = move("right", 2.01f);
            StartCoroutine(coroutine);
        }
        else if (ARM.direction == "left")
        {
            final_position.x = final_position.x - 16f;
            coroutine = move("left", -2.01f);
            StartCoroutine(coroutine);
        }
        else if (ARM.direction == "up")
        {
            final_position.y = final_position.y + 11f;
            Debug.Log(final_position.y);
            coroutine = move("up", 2.01f);
            StartCoroutine(coroutine);
        }
        else if (ARM.direction == "down")
        {
            final_position.y = final_position.y - 11f;
            coroutine = move("down", -2.01f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator move(string dir, float player_move)
    {
        yield return new WaitForSeconds(2f);
        player_position = player.transform.position;
        if (dir == "right" || dir == "left")
        {
            player_position.x = player_position.x + player_move;
        }
        else if (dir == "up" || dir == "down")
        {
            player_position.y = player_position.y + player_move;
        }
        player.transform.position = player_position;
        ARM.inMoving = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
