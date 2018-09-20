using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour {
    public Inventory inventory;

    public Text rupee_display;
    public Text key_display;
    public Text bomb_display;

    private void Start()
    {
        rupee_display.text = "Rupees: 0";
        key_display.text = "Keys: 0";
        bomb_display.text = "Bombs: 0";
    }

    private void Update()
    {
        if (inventory != null && rupee_display != null)
            rupee_display.text = "Rupees: " + inventory.GetRupees().ToString();

        if (inventory != null && key_display != null)
            key_display.text = "Keys: " + inventory.GetKeys().ToString();


        if (inventory != null && bomb_display != null)
            bomb_display.text = "Bombs: " + inventory.GetBombs().ToString();
    }
}
