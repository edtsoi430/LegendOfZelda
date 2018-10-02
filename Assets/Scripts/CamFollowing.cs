using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowing : MonoBehaviour {

    public GameObject player;
    public ArrowKeyMovement arm;

    private IEnumerator coroutine;
    private Vector3 player_position;
    private Vector3 final_position;

    private void Awake()
    {
        arm = player.GetComponent<ArrowKeyMovement>();
    }
    
    void Update () {
        if (arm.camera_moving && transform.position.x < final_position.x && arm.direction == "right")
        {
            transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 8);
            if (transform.position.x > final_position.x)
            {
                transform.position = final_position;
            }
        }
        else if (arm.camera_moving && transform.position.x > final_position.x && arm.direction == "left")
        {
            transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 8);
            if (transform.position.x < final_position.x)
            {
                transform.position = final_position;
            }
        }
        else if (arm.camera_moving && transform.position.y < final_position.y && arm.direction == "up")
        {
            transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 6);
            if (transform.position.y > final_position.y)
            {
                transform.position = final_position;
            }
        }
        else if (arm.camera_moving && transform.position.y > final_position.y && arm.direction == "down")
        {
            transform.position = Vector3.MoveTowards(transform.position, final_position, Time.deltaTime * 6);
            if (transform.position.y < final_position.y)
            {
                transform.position = final_position;
            }
        }
    }

    public void moveCam()
    {
        player.GetComponent<SpriteRenderer>().sortingOrder = -99;
        arm.camera_moving = true;
        final_position = transform.position;
        if (arm.direction == "right")
        {
            final_position.x = final_position.x + 16f;
            coroutine = move("right", 2.01f);
            StartCoroutine(coroutine);
        }
        else if (arm.direction == "left")
        {
            final_position.x = final_position.x - 16f;
            coroutine = move("left", -2.01f);
            StartCoroutine(coroutine);
        }
        else if (arm.direction == "up")
        {
            final_position.y = final_position.y + 11f;
            coroutine = move("up", 2.01f);
            StartCoroutine(coroutine);
        }
        else if (arm.direction == "down")
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
        arm.camera_moving = false;
        player.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

}
