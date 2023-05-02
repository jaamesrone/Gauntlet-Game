using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    public float meleeAttackRange;
    public int meleeAttackForce;
    public GameObject weapon;
    protected override void Attack()
    {
        if (Time.time-lastAttackTime>=attackTimeGap)
        {
            if (Vector3.Distance(transform.position,targetPlayer.transform.position)<=1.5f)
            {
                targetPlayer.Hurt(meleeAttackForce);
            }
            else
            {
                GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity, transform);
                bullet.GetComponent<Fireball>().direction =( targetPlayer.transform.position-transform.position).normalized;
            }
            lastAttackTime = Time.time;
        }
    }
}
