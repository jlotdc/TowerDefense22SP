using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Manager/Event Maneger", fileName = "EventManeger")]

public class EventManagerSO : ScriptableObject
{

    public event Action <int> onMakeMoney;
    public event Action <int> onReduceMoney;

    public void MakeMoney (int moneyMade)
    {
        onMakeMoney?.Invoke(moneyMade);
    }

    public void ReduceMoney(int moneyToReduce)
        { 
        onReduceMoney?.Invoke(moneyToReduce);
        }
}
