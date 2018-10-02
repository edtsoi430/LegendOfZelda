using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    private Animator animator;
    private BoxCollider bc;

    private Vector3 original_size;
    private Vector3 dipan_size;
    private Vector3 taodang_size;
    private Vector3 xiapan_size;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
        animator.speed = 0.6f;
        original_size = bc.size;
        dipan_size = new Vector3(0.5f, 0.3f, 0);
        taodang_size = new Vector3(0.5f, 0.35f, 0);
        xiapan_size = new Vector3(0.6f, 0.4f, 0);
    }

    private void Update()
    {
        
    }

    public void SetDipan()
    {
        animator.SetTrigger("dipan");
        bc.size = dipan_size;
        Invoke("Reset", 1f);
    }

    public void SetTaodang()
    {
        animator.SetTrigger("taodang");
        bc.size = taodang_size;
        Invoke("Reset", 1f);
    }

    public void SetXiapan()
    {
        animator.SetTrigger("xiapan");
        bc.size = xiapan_size;
        Invoke("Reset", 1f);
    }

    public void SetLose()
    {
        animator.SetTrigger("lose");
        Invoke("Reset", 10f);
    }

    public void SetIdle()
    {
        animator.SetTrigger("idle");
        Invoke("Reset", 4f);
    }

    public void SetFeibiao()
    {
        animator.SetTrigger("feibiao");
        Invoke("Reset", 1f);
    }

    public void SetBazhinv()
    {
        animator.SetTrigger("jiguang");
        Invoke("Reset", 1f);
    }

    private void Reset()
    {
        animator.ResetTrigger("dipan");
        animator.ResetTrigger("taodang");
        animator.ResetTrigger("xiapan");
        animator.ResetTrigger("lose");
        animator.ResetTrigger("idle");
        animator.ResetTrigger("feibiao");
        animator.ResetTrigger("jiguang");
        bc.size = original_size;
    }
}
