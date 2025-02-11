using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Manager/Event Maneger", fileName = "EventManeger")]

public class EventManagerSO : ScriptableObject
{



    public event Action onEnemyDestroyed;

    public void EnemyDestroyed()
    {
        onEnemyDestroyed?.Invoke();
    }


}
