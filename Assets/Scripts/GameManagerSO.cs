using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Managers/Game Manager", fileName ="GameManager")]

public class GameManagerSO : ScriptableObject
{



    [SerializeField] EventManagerSO eventManager;


    [Header("Default Values")]
    [Tooltip("Default Lives")]
    public int defaultLives = 3;
    public int defaultMoney = 250;

    [Header("Current Values")]
    public int lives;
    public int money;


    private void OnEnable()
    {
        eventManager.onMakeMoney += AddMoney;
        eventManager.onReduceMoney += ReduceMoney;
        eventManager.onEnemyDestroyed += LoseLife;
        eventManager.onLevelReset += ResetLevel;
    }


    private void OnDisable()
    {
        eventManager.onMakeMoney -= AddMoney;
        eventManager.onReduceMoney -= ReduceMoney;
        eventManager.onEnemyDestroyed -= LoseLife;
        eventManager.onLevelReset -= ResetLevel;
    }


    private void AddMoney(int incomingMoney)
    {
        money += incomingMoney;
    }

    private void ReduceMoney(int amountToReduce)
    {
        money -= amountToReduce;
    }


    public void Initialize()
    {
        money = defaultMoney;
        lives = defaultLives;
    }

    private void LoseLife()
    {
        lives -= 1;
    }


    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
