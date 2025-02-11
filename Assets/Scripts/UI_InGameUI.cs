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
        eventManager.onMakeMoney += UpdateMoney;
        eventManager.onReduceMoney += UpdateMoney;
    }

    private void OnDisable()
    {
        eventManager.onMakeMoney -= UpdateMoney;
        eventManager.onReduceMoney -= UpdateMoney;
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
