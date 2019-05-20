using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    [SerializeField] private SceneManager controller;

    private int _id;

    public int id
    {
        get { return _id; }
    }

    public void SetCard (int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    
}

