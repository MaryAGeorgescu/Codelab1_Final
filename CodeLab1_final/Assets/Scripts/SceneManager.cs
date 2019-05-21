using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


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

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3};
        numbers = ShuffleArray(numbers);
        
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

                int index = j * gridCols + i; // we are retrieving iDs from the shuffled list 
                int id = numbers[index]; //instead of random numbers
                card.SetCard(id, images[id]);
                
                //int id = Random.Range(0, images.Length);
                //originalCard.SetCard(id, images[id]);

                float posX = (offsetx * i) + startPos.x;
                float posY = (offsety * j) + startPos.y;
                card.transform.position = new Vector3( posX, posY, startPos.z);
            }    
        }    
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }

        return newArray;
    }

    private Memorycard _firstRevealed;
    private Memorycard _secondRevealed;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    private int _score = 0;
    
    public void CardRevealed(Memorycard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;

            StartCoroutine(CheckMatch());
            //Debug.Log("Match?" + (_firstRevealed.id == _secondRevealed.id));
        }
    }

    [SerializeField] public TextMesh scoreLabel;
    
    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            
            Debug.Log("Score:" +_score);
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            
            _firstRevealed.Unreveal(); //unreveal the cards when they do not match
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null; // clear them out whether or not the match was made
        _secondRevealed = null;
        
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene");
    }

}
