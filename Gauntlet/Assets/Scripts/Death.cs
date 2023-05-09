using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Enemy
{
    private int[] scoreAwardedArray = new int[7] { 1000, 2000, 1000, 4000, 2000, 6000, 8000 };
    private int scoreIndex = 0;
    protected override void Attack()
    {
        if (Time.time - lastAttackTime >= attackTimeGap)
        {
            targetPlayer.Hurt(attackForce);
            lastAttackTime = Time.time;
        }
    }

    public override int Hurt(int damage)
    {
        if (damage>0)
        {
            scoreIndex = (scoreIndex + 1) % scoreAwardedArray.Length;
        }
        return 0;
    }

    public override int Dead()
    {
        Destroy(gameObject);
        return scoreAwardedArray[scoreIndex];
    }
}
