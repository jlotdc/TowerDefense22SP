using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(menuName = "Manager/Event Maneger", fileName = "EventManeger")]

public class EventManagerSO : ScriptableObject
{

    public event Action <int> onMakeMoney;
    public event Action <int> onReduceMoney;
    public event Action onEnemyDestroyed;
    public event Action onLevelReset;
    public event Action onStartPlacingTower;

    public void MakeMoney (int moneyMade)
    {
        onMakeMoney?.Invoke(moneyMade);
    }

    public void ReduceMoney(int moneyToReduce)
        { 
        onReduceMoney?.Invoke(moneyToReduce);
        }

    public void EnemyDestroyed()
    {
        onEnemyDestroyed?.Invoke();
    }


    public void ResetLevel()
    {
        onLevelReset?.Invoke();
    }

    public void StartPlacingTower()

    {
        onStartPlacingTower?.Invoke();
    }

}
