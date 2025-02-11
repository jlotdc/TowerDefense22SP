using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_InGameUI : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] TMP_Text livesTextObject;
   [SerializeField] TMP_Text moneyTextObject;


    [SerializeField] GameManagerSO gameManeger;


    private void Start()
    {
         UpdateLives();
        UpdateMoney();       
        
    }

    [SerializeField] EventManagerSO eventManager;

    private void OnEnable()
    {
        eventManager.onEnemyDestroyed += UpdateMoney;
    }

    private void OnDisable()
    {
        eventManager.onEnemyDestroyed -= UpdateMoney;
    }


    private void UpdateLives()
    {
        livesTextObject.text = $"Lives: {gameManeger.lives}";
    }

    private void UpdateMoney()
    {
      moneyTextObject.text = $"Money: {gameManeger.money}"; 
    }

}
