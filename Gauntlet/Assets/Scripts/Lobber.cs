using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : Enemy
{
    public float escapeRange;
    public GameObject weapon;
    protected override void Update()
    {
        targetPlayer = DetectPlayer();
        if (Vector3.Distance(targetPlayer.transform.position,transform.position)<= escapeRange)
        {
            Vector3 directionToPlayer = (transform.position - targetPlayer.transform.position).normalized;
            transform.position+= directionToPlayer * moveSpeed *Time.deltaTime;
        }
        else if (Vector3.Distance(targetPlayer.transform.position, transform.position) <= attackRange)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        if (Time.time - lastAttackTime >= attackTimeGap)
        {
            GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity, transform);
            bullet.GetComponent<Fireball>().direction = (targetPlayer.transform.position - transform.position).normalized;
            bullet.GetComponent<Fireball>().shootedByLobber = true;
            lastAttackTime = Time.time;
        }
    }
}
