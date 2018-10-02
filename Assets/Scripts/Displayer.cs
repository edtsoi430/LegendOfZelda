using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour {
    public Inventory inventory;

    public Text rupee_display;
    public Text key_display;
    public Text bomb_display;

    public Image bomb_image;
    public Image boomerang_image;
    public Image bow_image;

    public WeaponControl wc;

    private void Start()
    {
        rupee_display.text = "0";
        key_display.text = "0";
        bomb_display.text = "0";
    }

    private void Update()
    {
        if (inventory != null && rupee_display != null)
            rupee_display.text = inventory.GetRupees().ToString();

        if (inventory != null && key_display != null)
            key_display.text = inventory.GetKeys().ToString();


        if (inventory != null && bomb_display != null)
            bomb_display.text = inventory.GetBombs().ToString();

        if (wc.weapon2.type == WeaponType.bomb)
        {
            bomb_image.gameObject.SetActive(true);
            boomerang_image.gameObject.SetActive(false);
            bow_image.gameObject.SetActive(false);
        }
        else if (wc.weapon2.type == WeaponType.boomerang)
        {
            bomb_image.gameObject.SetActive(false);
            boomerang_image.gameObject.SetActive(true);
            bow_image.gameObject.SetActive(false);
        }
        else if (wc.weapon2.type == WeaponType.bow)
        {
            bomb_image.gameObject.SetActive(false);
            boomerang_image.gameObject.SetActive(false);
            bow_image.gameObject.SetActive(true);
        }
    }
}
