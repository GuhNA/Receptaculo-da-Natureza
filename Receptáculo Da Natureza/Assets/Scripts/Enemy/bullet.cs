using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float vel;
    Rigidbody2D rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.AddForce(transform.right * vel);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().ChangeLife(-10);
            Destroy(gameObject);
        }
        if(collision.CompareTag("chao"))
        {
            Destroy(gameObject);
        }
    }
}
