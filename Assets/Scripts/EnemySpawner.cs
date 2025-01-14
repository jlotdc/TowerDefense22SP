using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyPath pathA;

    [SerializeField] List<Enemy> wave01Enemies;



    private void Start()
    {

        StartCoroutine(Wave01()); //start releasing wave01

    }

    private void SpawnEnemy(Enemy enemyToSpawn, EnemyPath pathToFollow)
    {
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity).SetPath(pathToFollow);
    }

    IEnumerator Wave01() //Coroutine/timer
    {

        //start delay

        yield return new WaitForSeconds(2f);

        //release each enemy on the list one by one 

        foreach(Enemy enemyToSpawn in wave01Enemies)
        {
            SpawnEnemy(enemyToSpawn, pathA);
            yield return new WaitForSeconds(1f);
        }


    }

}
