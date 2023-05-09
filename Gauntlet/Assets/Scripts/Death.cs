using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    protected override void Attack()
    {
        if (Time.time - lastAttackTime >= attackTimeGap)
        {
            targetPlayer.Hurt(attackForce);
            Hurt(-50);  
            lastAttackTime = Time.time;
        }
    }
}
