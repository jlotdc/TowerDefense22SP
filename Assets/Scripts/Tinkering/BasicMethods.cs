using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class BasicMethods : MonoBehaviour
{
    [SerializeField] string personOfInterest = "Jon";
    [SerializeField] string badMan = "The horrors";
    [SerializeField] string myPet = "Jurgen Leitner";


    private void Start()
    {


        //Call the methods/functions here 

        float bagOfCrisps = 3.0f;

        float bagOfCrispsWithTaxAdded = AddTax(bagOfCrisps, 0.25f);

        Debug.Log($"Bag originally cost {bagOfCrisps}" +
            $"but once tax is added price comes to" +
            $"{bagOfCrispsWithTaxAdded} euros");


        //ctrl+k, ctrl +c to comment a whole session out

        //sayHello(); //call sayHello()
        //Greeting("Jon");
        //Greeting("Martin");

        //Greeting(personOfInterest);
        //Greeting(badMan);

        Add(1, 3);
        Add(1, 1);
        Add(15, 300);
        Add(-1, 1);
        
        int money = 0;

        int sum = Add(50, 10);
        Debug.Log($"Currently Í have {money} money");

        money = Add(money, 100);

        Debug.Log($"I went to work and now I have {money} money");


    }


    void sayHello()
    {
        Debug.Log("Hello");
    }


    void Greeting(string personToGreet)
    {
        Debug.Log($"Nice to meet you, {personToGreet}");
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    float AddTax(float originalValue, float taxAmount)
    {
        return originalValue * (1 + taxAmount);
    }
    

}
