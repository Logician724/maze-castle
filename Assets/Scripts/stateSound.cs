using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateSound : StateMachineBehaviour
{
    public AudioClip zWalk;
    public AudioClip punch;
    public AudioClip die;
    public AudioClip door;
    public AudioClip playerWalk;

    private AudioSource audioSrc;

    private bool tmp = false;
    private byte idx = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioSrc = animator.gameObject.GetComponent<AudioSource>();

        if (stateInfo.IsTag("walk"))
        {
            audioSrc.PlayOneShot(zWalk);
        }
        else if (stateInfo.IsTag("die"))
        {
            audioSrc.PlayOneShot(die);
        }
        else if (stateInfo.IsTag("door"))
        {
            audioSrc.PlayOneShot(door);
        }
        else if (stateInfo.IsTag("playWalk"))
        {
            audioSrc.pitch = 1.5f;
            audioSrc.PlayOneShot(playerWalk);
        }
        else if (stateInfo.IsTag("pickChest"))
        {
            audioSrc.pitch = 1;
            audioSrc.Play();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsTag("attack"))
        {
            if (idx == 3)
            {
                return;
            }

            if (audioSrc.isPlaying)
            {
                tmp = false;
            }

            if (tmp)
            {
                return;
            }

            float time = idx + 0.38f;

            float x = stateInfo.normalizedTime;
            if (x > time)
            {
                tmp = true;
                audioSrc.PlayOneShot(punch);
                idx++;
            }

        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsTag("playWalk"))
        {
            audioSrc.Stop();
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    Debug.Log("here");
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
