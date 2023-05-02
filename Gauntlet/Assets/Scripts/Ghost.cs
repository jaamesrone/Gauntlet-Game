using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private bool isAttacking;
    private MeshRenderer meshRenderer;
    public float delayExplodeTime;
    private Color originalColor;

    protected override void Start()
    {
        base.Start();
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    protected override void Update()
    {
        targetPlayer = DetectPlayer();
     
        if (!isAttacking)
        {
            if (Vector3.Distance(transform.position, targetPlayer.transform.position) <= attackRange)
            {
                isAttacking = true;
                Attack();
            }
            Vector3 directionToPlayer = (targetPlayer.transform.position - transform.position).normalized;
           transform.position+= directionToPlayer * moveSpeed*Time.deltaTime;
        }

    }
    protected override void Attack()
    {
        StartCoroutine(Explode());

    }

    private IEnumerator Explode()
    {
        float currentExplodeTime = 0;
        while (currentExplodeTime<delayExplodeTime)
        {
            meshRenderer.material.color = Color.red;
            yield return new WaitForSeconds(0.35f);
            currentExplodeTime += 0.35f;
            meshRenderer.material.color = originalColor;
            yield return new WaitForSeconds(0.35f);
            currentExplodeTime += 0.35f;
        }
        Instantiate(Resources.Load<GameObject>("Prefab/GhostExplodeEffect"),transform.position,Quaternion.identity);
        for (int i = 0; i < GameManager.Instance.players.Count; i++)
        {
            PlayerController player = GameManager.Instance.players[i];
            if (Vector3.Distance(transform.position,player.transform.position)<=attackRange)
            {
                player.Hurt(attackForce);
            }
        }
        Destroy(gameObject);
    }
}
