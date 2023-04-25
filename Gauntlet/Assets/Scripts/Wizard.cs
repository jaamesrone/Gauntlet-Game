using UnityEngine;
using System.Collections;

public class Wizard : PlayerController
{
    public GameObject fireballPrefab;


    protected override void Attack()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity, transform);

        // Set the fireball's initial position to be just above the wizard's head
        fireball.transform.Translate(Vector3.up * 1.0f);
    }
}
