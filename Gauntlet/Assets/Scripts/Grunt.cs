using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    protected override void Attack()
    {
        if (Time.time-lastAttackTime>=attackTimeGap)
        {
            targetPlayer.Hurt(attackForce);
            lastAttackTime = Time.time;
        }
    }
}
