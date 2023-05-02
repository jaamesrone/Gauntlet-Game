using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : Enemy
{
    private MeshRenderer meshRenderer;
    private SphereCollider _collider;
    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        meshRenderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<SphereCollider>();
        Invisible(false);
    }

    // Update is called once per frame
   

    private void Invisible(bool isVisible)
    {
        meshRenderer.enabled = _collider.enabled = isVisible;
    }

    protected override void Attack()
    {
        Invisible(true);
        if (Time.time-lastAttackTime>=attackTimeGap)
        {
            targetPlayer.Hurt(attackForce);
            lastAttackTime = Time.time;
        }
    }
}
