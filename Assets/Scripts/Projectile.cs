using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speedMultiplayer = 1f;   
   private Rigidbody rb;
    private Enemy targetedEnemy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void Setup(Enemy enemyToTarget, Vector3 enemyDirection)
    {
        targetedEnemy = enemyToTarget;
        rb.AddForce(enemyDirection * speedMultiplayer, ForceMode.Impulse);
    }

    public void Update()
    {
        if (targetedEnemy != null)
        {
            transform.position = Vector3.MoveTowards(

                transform.position,
                targetedEnemy.transform.position + new Vector3 (0, 1, 0),
                speedMultiplayer * Time.deltaTime

                );
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (targetedEnemy != null)
        {
            if(other.gameObject == targetedEnemy.gameObject)
            {
                Destroy(targetedEnemy.gameObject);
            }
        }

        Destroy(this.gameObject);
    }
}
