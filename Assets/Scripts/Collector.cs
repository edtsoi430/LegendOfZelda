using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {
    public AudioClip rupee_collection_sound_clip;
    public Sprite d0;
    public Sprite d1;
    public Sprite d2;
    public Sprite d3;

    public SpriteRenderer[] sr;

    Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collector has no inventory to store things in!");
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        GameObject object_collided_with = coll.gameObject;

        if (object_collided_with.tag == "rupee")
        {
            if (inventory != null)
                inventory.AddRupees(1);
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "key")
        {
            if (inventory != null)
                inventory.AddKeys(1);
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "bomb")
        {
            if (inventory != null)
                inventory.AddBombs(1);
            Destroy(object_collided_with);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }

        if (object_collided_with.tag == "door" || object_collided_with.tag == "door2" || object_collided_with.tag == "door3")
        {
            if (inventory != null && inventory.GetKeys() > 0)
            {
                inventory.AddKeys(-1);
                object_collided_with.GetComponent<BoxCollider>().enabled = false;
                sr = object_collided_with.GetComponentsInChildren<SpriteRenderer>();
                if (object_collided_with.tag == "door")
                {
                    sr[0].sprite = d0;
                    sr[1].sprite = d1;
                }
                if (object_collided_with.tag == "door2")
                {
                    sr[1].sprite = d2;
                }
                if (object_collided_with.tag == "door3")
                {
                    sr[1].sprite = d3;
                }
            }
        }
    }
}
