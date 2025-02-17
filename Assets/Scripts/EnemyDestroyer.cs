using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    [SerializeField] LayerMask enemyLayers;
    [SerializeField] EventManagerSO eventManager;
    private void OnTriggerEnter(Collider other)
    {
            //Only respond to items on enemy layer
            if ((enemyLayers.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            //you just lost a life


            eventManager.EnemyDestroyed();

            //destroy the enemy
            Destroy(other.gameObject);

        }
    }

}
