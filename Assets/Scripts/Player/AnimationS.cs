using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class AnimationS : NetworkBehaviour {
    Animator animator;
    // Use this for initialization
    void Start () {
       
            animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walk", true);
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool("Run", true);
                }
                else
                {
                    animator.SetBool("Run", false);
                    animator.SetBool("Walk", true);
                }
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", false);
            }
            }
    }

 
}
