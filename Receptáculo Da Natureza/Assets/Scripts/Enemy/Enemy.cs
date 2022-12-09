using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] int life;
    [SerializeField] float distance;

    [Header("References")]
    [SerializeField] Transform bullet;
    [SerializeField] Transform bulletposition;
    [SerializeField] Transform vision;
    Animator anim;
    EnemyAnim enemyAnim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAnim = GetComponent<EnemyAnim>();
    }

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        enemyVision();
    }

    public void changeLife(int num)
    {
        life += num;
        if (num < 0)
            enemyAnim.damage = true;
    }

    //Used by animation atk
    void fire()
    {
        Instantiate(bullet, bulletposition.position, transform.rotation);
    }

    void enemyVision()
    {
        RaycastHit2D hit = Physics2D.Raycast(vision.position, transform.TransformDirection(Vector2.right), distance, -1, 0);

        //For some reason we can't use directly hit.collider...
        if (hit)
        {
            if(hit.collider.CompareTag("Player"))
            {
                if(enemyAnim.currentVel > 0)
                    enemyAnim.currentVel = 0;
                if(!enemyAnim.attacking)
                    enemyAnim.attacking = true;
                anim.SetInteger("action", 2);

            }
            //if hit with something else
            else
            {
                if (enemyAnim.attacking)
                    enemyAnim.attacking = false;
            }
        }
        //if don't hit nothing
        else
        {
            if (enemyAnim.attacking)
                enemyAnim.attacking = false;
        }

        Debug.DrawRay(vision.position, vision.TransformDirection(Vector2.right * distance), Color.red);
    }

}
