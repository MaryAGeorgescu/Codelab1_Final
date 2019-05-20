using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Memorycard originalCard;

    [SerializeField] private Sprite[] images;
    // Start is called before the first frame update
    void Start()
    {
        int id = Random.Range(0, images.Length);
        originalCard.SetCard(id, images[id]);
    }

 
}
