using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        SetOrientation(WeaponController.instance.gunOrientation);
        OnRun();
    }

    public void SetOrientation(int orientation)
    {
        spriteRenderer.flipX = orientation < 0;
    }

    public void OnRun(){
        if(PlayerMoviment.instance.isRuning && PlayerMoviment.instance.isMoving){
            anim.SetBool("isRuning", true);
        }
        else{
            anim.SetBool("isRuning", false);
        }
    }
}
