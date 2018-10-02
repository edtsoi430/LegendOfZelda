using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeInEffect : MonoBehaviour {
    public string fullText;
    public AudioClip type_sound;
    public float delay = 0.1f;
    public bool triggered;
    public int count = 0;

    private string currentText = "";

    // Use this for initialization
    private void Update()
    {
        if (triggered)
        {
            if (count == 0)
            {
                StartCoroutine(ShowText());
            }
            triggered = false;
        } 
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            AudioSource.PlayClipAtPoint(type_sound, Camera.main.transform.position);
            yield return new WaitForSeconds(delay);
        }
        GameObject.Find("Player").GetComponent<ArrowKeyMovement>().enter_oldMan = false;
        count++;
    }
}
