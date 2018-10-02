using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlay : MonoBehaviour {
    public AudioClip goldBackground_sound;
    // Use this for initialization

    public void PlayBackgroundAudio(){
        GetComponent<AudioSource>().clip = goldBackground_sound;
        //AudioSource.PlayClipAtPoint(goldBackground_sound, Camera.main.transform.position);
        GetComponent<AudioSource>().Play();
    }
}
