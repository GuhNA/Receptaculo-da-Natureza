using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life;


    private void Update()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void changeLife(int num)
    {
        life += num;
    }
}
