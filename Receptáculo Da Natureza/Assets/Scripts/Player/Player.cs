using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] float speed;
    [SerializeField] int Life;
    [SerializeField] int Mana;
    [SerializeField] float jumpForce;
    int LifeMax;
    int ManaMax;
    public int ContJump;
    float _direction;
    bool LookRight;
    bool damage;
    bool Attack;
    bool AtkPressed;
    public Vector2 checkpoint;

    float cont, contMax;
    int times;

    Color iniColor;

    SpriteRenderer sprite;
    DownfallDamage df;
    Rigidbody2D rig;

    #region Encapsulamento
    public int life
    {
        get { return Life; }
        set { Life = value; }
    }

    public int mana
    {
        get { return Mana; }
        set { Mana = value; }
    }

    public int manaMax
    {
        get { return ManaMax; }
        set { ManaMax = value; }
    }

    public int lifeMax
    {
        get { return LifeMax; }
        set { LifeMax = value; }
    }

    public float direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public int contJump
    {
        get { return ContJump; }
        set { ContJump = value; }
    }

    public bool lookRight
    {
        get { return LookRight; }
        set { LookRight = value; }
    }

    public bool attack
    {
        get { return Attack; }
        set { Attack = value; }
    }

    public bool atkPressed
    {
        get { return AtkPressed; }
        set { AtkPressed = value; }
    }
    #endregion
    private void Awake()
    {
        df = FindObjectOfType<DownfallDamage>();
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        LifeMax = life = 100;
        ManaMax = mana = 60;
    }
    void Start()
    {
        iniColor = sprite.color;
        cont = contMax = 1.3f;
        times = 0;
        contJump = 0;
    }
    private void Update()
    {
        if (direction > 0)
        {
            lookRight = true;
        }
        else if (direction < 0)
        {
            lookRight = false;
        }

        //Piscando
        if (damage)
        {
            cont -= Time.deltaTime;
            if (cont < 1f)
            {
                cont = contMax;
                times++;
            }

            if(times % 2 != 0)
            {
                sprite.color = iniColor;
            }
            else if(times % 2 == 0)
            {
                sprite.color = new Color(255f, 255f, 255f, 0.1f);
            }

            if(times == 5)
            {
                cont = contMax;
                times = 0;
                sprite.color = iniColor;
                damage = false;
            }


        }

    }
    private void FixedUpdate()
    {
        rig.position = rig.position + new Vector2(direction, 0) * speed * Time.deltaTime;
    }

    #region move/attack
    public void move(float direction)
    {
        this.direction = direction;

        if (direction < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    public void jump()
    {
        if (contJump < 2)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            contJump++;
        }
    }

    public void attacking(bool state)
    {
        AtkPressed = state;
    }
    #endregion

    public void ChangeLife(int modifier)
    {
        life = Mathf.Clamp(life + modifier, 0, 100);

        if (modifier < 0)
        {
            damage = true;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            contJump = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spots"))
        {
            checkpoint = rig.position;

        }
        if (collision.CompareTag("fallCheck"))
        {
            ChangeLife(-10);
            rig.position = checkpoint;

        }

    }
}
