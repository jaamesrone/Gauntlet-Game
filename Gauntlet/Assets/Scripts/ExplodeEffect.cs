using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 1.5f);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
