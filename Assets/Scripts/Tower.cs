using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour

{

    [SerializeField] int price = 50;

    public int Price => price;


    //shooting related
    [SerializeField] Transform firingPoint;
    [SerializeField] Projectile projectile;

    [SerializeField] float range = 5f;
    // enemy bookkeeping
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Collider[] detectedEnemyColliders;
    [SerializeField] List<Enemy> enemiesInRange;
    [SerializeField] Enemy targetedEnemy;

    //timers
    private float firingTimer;
    [SerializeField] float firingDelay = 1f;
    private float scanningTimer;
    private float scanningDelay = 0.1f;

    bool isActive;





    private void Awake()
    {
        enemiesInRange = new List<Enemy>(); //initialize the list
        isActive = false;   
    }

    public void ActivateTower()
    {
        isActive = true;
    }

    public void DeactivateTower()
    {
        isActive = false;
    }

    // "public void DeactivateTower() => isActive = false;" also works for methods with just a single line of code

    private void Update()
    {

        if (isActive)
        {
            //===SCANNING TIMER===
            scanningTimer += Time.deltaTime;
            if (scanningTimer > scanningDelay)
            {
                ScanForEnemies();
                scanningTimer = 0f;
            }


            //===FIRING TIMER===
            //charge up timer
            if (firingTimer < firingDelay)
            {
                firingTimer += Time.deltaTime; //add time to the timer
            }

            if (firingTimer >= firingDelay && targetedEnemy != null)  //if timer is ready and enemy is not null, fire.
            {
                Fire();
                firingTimer = 0f;
            }

        }

    }

    private void ScanForEnemies()
    {
        detectedEnemyColliders = Physics.OverlapSphere(transform.position, range, enemyLayers); //detect any nearby colloders that are on the enemy layers

        enemiesInRange.Clear(); //clear the list

        foreach (Collider collider in detectedEnemyColliders) //go over each detected collider and fetch the enemy component if present
        {
            enemiesInRange.Add(collider.GetComponent<Enemy>());
        }

        //are there enemies in range?
        //if so, pick a target
        if (enemiesInRange.Count != 0)
        {
            targetedEnemy = enemiesInRange[0]; //attack the first enemy on the list
            //targetedEnemy = enemiesInRange[enemiesInRange.Count - 1]; //attack the last enemy that enters area
        }

        //if targeted enemy is out of range allow enemy to forget
        if (targetedEnemy != null && Vector3.Distance(transform.position, targetedEnemy.transform.position) > range)
        {
            targetedEnemy = null;
        }
    }

    private void Fire()
    {
        if (targetedEnemy == null) // see if there is no enemy to shoot at
        {
            return; //stop here if there's no-one to shoot at
        }

        //get enemy position        
        Vector3 enemyDirection = (targetedEnemy.transform.position - firingPoint.position).normalized;

        Instantiate(projectile, firingPoint.position, Quaternion.identity).Setup(targetedEnemy, enemyDirection); //instantiate projcectile and run setup on it. No rotation.

    }

    private void OnDrawGizmosSelected()
    {
        //visualize range of selected tower
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);

        //visualize targeted enemy
        if (targetedEnemy != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(targetedEnemy.transform.position, 2);
        }
    }

}
