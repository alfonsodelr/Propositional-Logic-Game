using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReader : MonoBehaviour
{
    // Start is called before the first frame update
    public Card_Properties card;
    public int GetCardValue(){
        return card.card_value;
    }

    public string GetCardRV(){
        return card.return_val;
    }

    public string GetCardName(){
        return card.name;
    }

    public string GetCardDescription(){
        return card.description;
    }

    public void PrintAll(){
        Debug.Log("Value: " + GetCardValue());
        Debug.Log("Return: " + GetCardRV());
        Debug.Log("Name: " + GetCardName());
        Debug.Log("Description: " + GetCardDescription());
    }

}
