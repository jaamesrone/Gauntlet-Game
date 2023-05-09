using UnityEngine;
using System.Collections;

public class Wizard : PlayerController
{
    public override void UseMagicPotion()
    {
        for (int i = GameManager.Instance.enemys.Count - 1; i >= 0; i--)
        {
            Enemy e = GameManager.Instance.enemys[i];
            if (e != null)
            {
                if ((e.enemyLevel <= 3 || e.isDeath) && Vector3.Distance(transform.position, e.transform.position) <= 30)
                {
                    GameManager.Instance.enemys.Remove(e);
                    ChangeScore(e.Dead());
                }
            }
        }
        EnemySpawner[] eS = GameObject.Find("EnemySpawners").GetComponentsInChildren<EnemySpawner>();
        for (int i = eS.Length-1; i >=0; i--)
        {
            if (eS[i]!=null&&Vector3.Distance(transform.position,eS[i].transform.position)<=15)
            {
                eS[i].Hurt(9999999);
            }
        }
    }


}
