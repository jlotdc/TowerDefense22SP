using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] GameManagerSO gameManager;

    private void Awake()
    {
        gameManager.Initialize();
    }

}
