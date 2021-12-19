using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card_Properties : ScriptableObject
{
    public new string name = "None";
    public string return_val = "None";
    public string description = "None";
    public int card_value = 0;
}
