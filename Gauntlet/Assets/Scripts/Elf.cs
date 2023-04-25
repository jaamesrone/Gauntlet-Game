using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : PlayerController
{
    public GameObject weapon;


    protected override void Attack()
    {
        
        GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity, transform);
        bullet.GetComponent<Fireball>().direction = moveInput;
    }
}
