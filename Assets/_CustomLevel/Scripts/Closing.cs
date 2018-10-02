using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closing : MonoBehaviour {

    public GameObject cube1;
    public GameObject cube2;
    public GameObject Iori;
    public Text text;
    public bool close;
    public bool open;

    private Vector3 final_position;
    private Vector3 cube1_position;
    private Vector3 cube2_position;
    private int level;

    private IEnumerator coroutine;

    // Use this for initialization
    void Awake () {
        Iori = GameObject.Find("Iori");
        cube1_position = cube1.transform.position;
        cube2_position = cube2.transform.position;
        final_position = cube1.transform.position;
        final_position.x += 16;
        close = false;
        open = false;
        level = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (close)
        {
            cube1.transform.position = Vector3.MoveTowards(cube1.transform.position, final_position, Time.deltaTime * 10);
            cube2.transform.position = Vector3.MoveTowards(cube2.transform.position, final_position, Time.deltaTime * 10);
        }
        if (open)
        {
            cube1.transform.position = Vector3.MoveTowards(cube1.transform.position, cube1_position, Time.deltaTime * 10);
            cube2.transform.position = Vector3.MoveTowards(cube2.transform.position, cube2_position, Time.deltaTime * 10);
        }
    }

    public void ResetOpen()
    {
        open = false;
    }

    public void Close()
    {
        level = Iori.GetComponent<MotionControl>().level;
        close = true;

        coroutine = Wait();
        StartCoroutine(coroutine);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        text.gameObject.SetActive(true);
        text.text = "Level " + level.ToString();

        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(false);
        open = true;
        close = false;
    }
}
