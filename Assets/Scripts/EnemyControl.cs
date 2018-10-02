using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public Enemy[] enemies;
    public Vector3[] spawn_position;
    public GameObject keyPrefab;

    public GameObject room;
    public bool Key = false;

    private int counter = 0;
    private bool all_clear = false;

    // Use this for initialization
    void Awake () {
        enemies = GetComponentsInChildren<Enemy>();
        SetPosition();
    }
	
	// Update is called once per frame
	void Update () {
		if (Key)
        {
            all_clear = true;
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    all_clear = false;
                }
            }
        }
        if (Key && all_clear)
        {
            Debug.Log(11);
            Vector2 Pos = room.transform.position;
            Pos.x += 7;
            Pos.y += 4;
            Instantiate(keyPrefab, Pos, Quaternion.identity, transform);
            Key = false;
        }
	}

    public void SetPosition()
    {
        counter = 0;
        foreach (Enemy enemy in enemies)
        {
            if(enemy != null){
                enemy.transform.position = spawn_position[counter];
                enemy.GetComponent<BoundryCheck>().enabled = true;
                enemy.GetComponent<BoundryCheck>().SetRoom(room);
                counter++;
            }
        }
    }
}
