using UnityEngine;
using System.Collections;

public class Valkyrie : PlayerController
{
    public GameObject weapon;

    protected override void Attack()
    {

        GameObject bullet = Instantiate(weapon, transform.position, Quaternion.identity, transform);
        bullet.GetComponent<Fireball>().direction = moveInput;
    }


}
