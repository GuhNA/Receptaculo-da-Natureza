using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] LayerMask enemyLayer;

    [Header("References")]
    [SerializeField] Animator anim;
    [SerializeField] Player player;

    [Header("Combos")]
    [SerializeField] int length;
    public int combo = 0;
    
    #region damageReference

    public void onAttack(int damage)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.Find("basicAttack").position, radius, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit)
            {
                hit.GetComponent<Enemy>().changeLife(-damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.Find("basicAttack").position, radius);
    }
    #endregion

    private void Update()
    {
        if(!player.attack && player.atkPressed)
        {
            anim.SetTrigger(""+combo);
            player.attack = true;
        }
    }

    public void StartCombo()
    {
        player.attack = false;

        if(combo < length)
        {
            combo++;
        }
    }

    public void FinishCombo()
    {
        player.attack = false;
        combo = 0;
    }
}

