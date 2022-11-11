using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpd = 40f;
    bool jump = false;
    
     


    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpd;  //take the horizontal input and multiply it by player spd

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //if Speed is positive then it switches to running anim. This sees if it is moving

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
    }

        public void OnLanding(){
            
            animator.SetBool("IsJumping", false);
        }

    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
       
       
    }
}
