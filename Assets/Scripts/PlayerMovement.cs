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
    int vert = 1;
     

    [Header ("SFX")]
    [SerializeField]public AudioSource stepSound;
    [SerializeField] private AudioClip jumpSound;

    


    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpd;  //take the horizontal input and multiply it by player spd

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); //if Speed is positive then it switches to running anim. This sees if it is moving
        
       if(Input.GetButton("Horizontal") == true && vert ==0)
       {
        stepSound.enabled = true;
       }
       
        else
        {
            stepSound.enabled = false;
        }


        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            vert = 1;
        }
        
    }

        public void OnLanding(){
            vert = 0;
            animator.SetBool("IsJumping", false);
        }

    void FixedUpdate ()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        
        jump = false;
       
       
    }
}
