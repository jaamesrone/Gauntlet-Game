using UnityEngine;

public class Thieves : Enemy
{

  

    protected override void Attack()
    {
        // tang's weapon attack
        if (Time.time - lastAttackTime >= attackTimeGap)
        {
            targetPlayer.BeStole();

            // checks for the last attack time uwu
            lastAttackTime = Time.time;
        }
    }

    public override int Dead()
    {
        GameObject treasureBag = Resources.Load<GameObject>("Prefab/Treasurebag");
        Instantiate(treasureBag, transform.position, Quaternion.identity);
        Destroy(gameObject);
        return scoreAwarded;
    }
}
