using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    
    public GameObject highScorePanel;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
    }

    public void ResetScene()
    {
        // find all the cards and remove them
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        foreach(UpdateSprite card in cards)
        {
            Destroy(card.gameObject);
        }
        ClearTopValues();
        //deal new cards
        FindObjectOfType<Solitaire>().PlayCards();
    }

    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach(Selectable selectable in selectables)
        {
            if(selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }
}
