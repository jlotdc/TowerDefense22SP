using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGameUI : MonoBehaviour
{
    // Start is called before the first frame update


    [Header("Managers")]
   [SerializeField] TMP_Text livesTextObject;
   [SerializeField] TMP_Text moneyTextObject;

    [Header("Text objects")]
    [SerializeField] GameManagerSO gameManeger;
    [SerializeField] EventManagerSO eventManager;


    [Header("Buttons")]
    [SerializeField] Button placeTowerAbtn;
    [SerializeField] Button ResetButton;



    private void Start()
    {

        placeTowerAbtn.onClick.AddListener(()
           => eventManager.StartPlacingTower());
            
         UpdateLives();
        UpdateMoney();
        ResetButton.onClick.AddListener(()
            => eventManager.ResetLevel());
    }

    private void OnEnable()
    {
        eventManager.onMakeMoney += UpdateMoney;
        eventManager.onReduceMoney += UpdateMoney;
        eventManager.onEnemyDestroyed += UpdateLives;
    }

    private void OnDisable()
    {
        eventManager.onMakeMoney -= UpdateMoney;
        eventManager.onReduceMoney -= UpdateMoney;
        eventManager.onEnemyDestroyed -= UpdateLives;   
    }


    private void UpdateLives()
    {
        livesTextObject.text = $"Lives: {gameManeger.lives}";
    }

    private void UpdateMoney(int UnusedValue = -1)
    {
      moneyTextObject.text = $"Money: {gameManeger.money}"; 
    }

}
