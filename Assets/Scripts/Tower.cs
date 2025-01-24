using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Projectile projectile;
    [SerializeField] Transform firingPoint;


    [SerializeField] float range = 5f;

    //Enemy bookkeeping

    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Collider[] detectedEnemyColliders;
    [SerializeField] List<Enemy> enemiesInRange;
    [SerializeField] Enemy targetedEnemy;

    private float firingTimer;
    [SerializeField] float firingDelay = 1f;


    private void Awake()
    {
        enemiesInRange = new List<Enemy>(); 
    }

    private void Update()
    {
        ScanForEnemies();


        if(firingTimer < firingDelay)
        {
            firingTimer += Time.deltaTime;
        }

        if ( firingTimer >= firingDelay && targetedEnemy != null)
        {

            Fire();
            firingTimer = 0f;

        }

        
    }


    private void ScanForEnemies()
    {
        detectedEnemyColliders = Physics.OverlapSphere(transform.position, range, enemyLayers);


        enemiesInRange.Clear();

        foreach(Collider collider in detectedEnemyColliders)
        {
            enemiesInRange.Add(collider.GetComponent<Enemy>()); 
        }


        if (enemiesInRange.Count != 0)
        {
            targetedEnemy = enemiesInRange[0];

        }

        if(targetedEnemy != null && Vector3.Distance(transform.position, 
            targetedEnemy.transform.position) >range)
        {
            targetedEnemy = null;
        }


    }

    private void Fire()
    {
     if (targetedEnemy == null)
        {
            return;
        }


     Vector3 enemyDirection = (targetedEnemy.transform.position - firingPoint.position).normalized;


        Instantiate(projectile, firingPoint.position, Quaternion.identity).Setup(targetedEnemy, enemyDirection);
    }



    private void OnDrawGizmosSelected ()  
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        if (targetedEnemy != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(targetedEnemy.transform.position, 2);
        }
    }

 
}
