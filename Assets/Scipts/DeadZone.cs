using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject spawn;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.OnTeleportPlayer(spawn.transform.position);
        }
    }
}
