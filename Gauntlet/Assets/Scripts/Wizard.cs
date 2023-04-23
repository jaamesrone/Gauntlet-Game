using UnityEngine;
using System.Collections;

public class Wizard : PlayerController
{
    public GameObject fireballPrefab;

    void Update()
    {
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new fireball object
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity,transform);

            // Set the fireball's initial position to be just above the wizard's head
            fireball.transform.Translate(Vector3.up * 1.0f);
        }
    }

    protected override IEnumerator Attack()
    {
        return base.Attack();
    }
}
