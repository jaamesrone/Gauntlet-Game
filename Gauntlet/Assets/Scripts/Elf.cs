using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : PlayerController
{
    public override void UseMagicPotion()
    {
        for (int i = GameManager.Instance.enemys.Count - 1; i >= 0; i--)
        {
            Enemy e = GameManager.Instance.enemys[i];
            if (e != null)
            {
                if ((e.enemyLevel <= 3 || e.isDeath) && Vector3.Distance(transform.position, e.transform.position) <= 20)
                {
                    GameManager.Instance.enemys.Remove(e);
                    ChangeScore( e.Dead());
                }
            }
        }
    }



}
