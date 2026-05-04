using System;
using UnityEngine;

public class DeleteOnContact : MonoBehaviour
{
    public GameObject target;
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (target is not null) Destroy(target);
    }
}
