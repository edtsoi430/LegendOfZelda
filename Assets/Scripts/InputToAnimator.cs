using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour {

    public Animator animator;
    private WeaponControl wc;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        wc = GetComponent<WeaponControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));

        if (wc.weapon_holding)
        {
            animator.SetTrigger("weapon");
        }

        if (!wc.weapon_holding)
        {
            animator.ResetTrigger("weapon");
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && !wc.weapon_holding)
        {
            animator.speed = 0.0f;
        }
        else
        {
            animator.speed = 1.0f;
        }
    }
        
}
