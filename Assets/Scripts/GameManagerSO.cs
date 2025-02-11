using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Managers/Game Manager", fileName ="GameManager")]

public class GameManagerSO : ScriptableObject
{



    [SerializeField] EventManagerSO eventManager;


    [Header("Default Values")]
    [Tooltip("Default Lives")]public int defaultLives = 3;
    public int defaultMoney = 250;

    [Header("Current Values")]
    public int lives;
    public int money;


    private void OnEnable()
    {
        eventManager.onEnemyDestroyed += AddMoney;
    }


    private void OnDisable()
    {
        eventManager.onEnemyDestroyed -= AddMoney;
    }


    private void AddMoney()
    {
        money++;
    }


    public void Initialize()
    {
        money = defaultMoney;
        lives = defaultLives;
    }


}
