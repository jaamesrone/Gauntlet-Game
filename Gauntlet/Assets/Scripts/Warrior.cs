using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warrior : PlayerController
{
    // Start is called before the first frame update


    private  IEnumerator AttackAnimation()
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

    protected override void Attack()
    {
        StartCoroutine(AttackAnimation());
    }

    public override void UseMagicPotion()
    {
        for (int i = GameManager.Instance.enemys.Count-1; i >=0; i--)
        {
            Enemy e = GameManager.Instance.enemys[i];
            if (e!=null)
            {
                if ((e.enemyLevel<=1||e.isDeath)&&Vector3.Distance(transform.position,e.transform.position)<=10)
                {
                    GameManager.Instance.enemys.Remove(e);
                    ChangeScore(e.Dead());
                }
            }
        }
    }
}
