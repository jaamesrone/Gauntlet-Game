using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warrior : PlayerController
{
    public GameObject weapon;
    // Start is called before the first frame update


    protected override IEnumerator Attack()
    {
        float rotateAngle = 0;
        while (rotateAngle<360)
        {
           weapon.transform.Rotate(new Vector3(0, 0, 15));
            rotateAngle += 15;
            yield return new WaitForSeconds(0.02f);
        }
        rotateAngle = 0;
    }


}
