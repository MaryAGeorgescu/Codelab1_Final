using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Intent: This script hides the card back when the card is clicked
//Usage: Place on


public class Memorycard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack; //our variable in the inspector
    
    
    private void OnMouseDown() 
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false);
        }
    }
}
