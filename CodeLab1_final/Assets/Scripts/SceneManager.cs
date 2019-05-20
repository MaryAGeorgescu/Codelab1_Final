using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class SceneManager : MonoBehaviour
{
   
    public const int gridRows = 2;
    public const int gridCols = 4;
    public float offsetx = 2f;
    public float offsety = 2.5f;
    
    [SerializeField] private Memorycard originalCard;
    [SerializeField] private Sprite[] images;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                Memorycard card;
                if ( i== 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as Memorycard;
                }
                int id = Random.Range(0, images.Length);
                originalCard.SetCard(id, images[id]);

                float posX = (offsetx * i) + startPos.x;
                float posY = (offsety * j) + startPos.y;
                card.transform.position = new Vector3( posX, posY, startPos.z);
            }    
        }
        
        
        
    }

 
}
