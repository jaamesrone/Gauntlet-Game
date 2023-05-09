using UnityEngine;
using System;

public class TreasureBag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            other.GetComponent<PlayerController>().ChangeScore(500);
            Destroy(gameObject);
        }
    }
}
