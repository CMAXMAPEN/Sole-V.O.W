using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : StateMachineBehaviour
{

    public AudioSource footStep;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    footStep.enabled = true;  
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    footStep.enabled = false;  
    }
    
}
