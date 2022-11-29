using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (player.lookRight)
            anim.SetBool("right", true);
        else
            anim.SetBool("right", false);
        OnRun();
        OnJump();
    }


    void OnRun()
    {
        if(player.direction != 0 && player.contJump == 0)
        {
            anim.SetInteger("select", 1);
        }
        else
        {
            anim.SetInteger("select", 0);
        }
    }

    void OnJump()
    {
        if (player.contJump > 0)
        {
            anim.SetInteger("select", 2);
        }

    }
}
