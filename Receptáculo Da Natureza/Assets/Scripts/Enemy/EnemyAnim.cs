using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] float vel;
    [SerializeField] float initialTimer;
    [SerializeField] List<Transform> paths;
    float distance;
    float CurrentVel;
    float timer;
    float timerDamage = 0.7f;
    bool waiting;
    bool Damage;
    bool Attacking;
    int i = 0;
    Animator anim;


    #region encapsulamento

    public bool attacking
    {
        set { Attacking = value; }
        get { return Attacking; }
    }
    public float currentVel
    {
        get { return CurrentVel; }
        set { CurrentVel = value; }
    }

    public bool damage
    {
        get { return Damage; }
        set { Damage = value; }
    }
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        waiting = attacking = false;
        timer = initialTimer;
        currentVel = vel;
    }
    private void Update()
    {
        if(!damage)
        {
            if (!attacking)
            {
                if (isIdle())
                    anim.SetInteger("action", 0);
                else if (!isIdle())
                    anim.SetInteger("action", 1);
                moviment();
            }
        }
        else
        {
            anim.SetInteger("action", 4);
            GetComponent<SpriteRenderer>().color = Color.red;
            timerDamage -= Time.deltaTime;
            if(timerDamage < 0)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                timerDamage = 0.7f;
                damage = false;
            }


        }
    }


    void moviment()
    {
        distance = Mathf.Abs(transform.position.x - paths[i].position.x);

        if (distance >= 0.01f)
            waiting = false;
        else
            waiting = true;

        if(!waiting)
        {
            currentVel = vel;
            move(paths[i].position.x);
        }
        else if(waiting)
        {
            currentVel = 0;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (i == paths.Count - 1)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                timer = initialTimer;
                currentVel = vel;
                waiting = false;
            }
        }
    }

    bool isIdle()
    {
        if (currentVel == 0) return true;
        else return false;
    }

    void move(float goal)
    {
        if(Mathf.Abs(transform.position.x - goal) >= 0.01f)
        {

            if(transform.position.x > goal)
            {
                transform.position = new Vector3(transform.position.x - currentVel * Time.deltaTime, transform.position.y, 0);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if(transform.position.x < goal)
            {
                transform.position = new Vector3(transform.position.x + currentVel * Time.deltaTime, transform.position.y, 0);
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
    }

}
