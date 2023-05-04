using UnityEngine;

public class TreasureBag : MonoBehaviour
{
    public int points;//

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
