using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] int life;
    [SerializeField] float distance;
    int direction = 1;

    [Header("References")]
    [SerializeField] Transform bullet;
    [SerializeField] Transform bulletposition;
    [SerializeField] Transform vision;

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
    }


    void fire()
    {
        Instantiate(bullet, bulletposition.position, transform.rotation);
    }

    void enemyVision()
    {
        RaycastHit2D hit = Physics2D.Raycast(vision.position, transform.TransformDirection(Vector2.right * direction), distance, 8);
        if (hit)
        {
            Debug.Log("Te achei");
        }
        Debug.DrawRay(vision.position, vision.TransformDirection(Vector2.right * distance), Color.red);
    }

}
