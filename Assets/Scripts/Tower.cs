using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] float range = 5f;

    //Enemy bookkeeping

    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Collider[] detectedEnemyColliders;

    private void Update()
    {
        ScanForEnemies();
    }


    private void ScanForEnemies()
    {
        detectedEnemyColliders = Physics.OverlapSphere(transform.position, range, enemyLayers);

    }

    private void OnDrawGizmosSelected ()  
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
