using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] Enemy basicEnemy;
    [SerializeField] EnemyPath pathA;

    private void Start()
    {

        SpawnEnemy(basicEnemy, pathA);
        SpawnEnemy(basicEnemy, pathA);
        SpawnEnemy(basicEnemy, pathA);

    }

    private void SpawnEnemy(Enemy enemyToSpawn, EnemyPath pathToFollow)
    {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity).SetPath(pathToFollow);
    }



}
