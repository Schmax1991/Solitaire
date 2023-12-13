using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject slot1;
    private Solitaire solitaire;



    void Start()
    {
        solitaire = FindObjectOfType<Solitaire>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit)
            {
                //what has been hit? Deck/card/EpmtySlot...
                if(hit.collider.CompareTag("Deck"))
                {
                    //clicked deck
                    Deck();
                }
                if(hit.collider.CompareTag("Card"))
                {
                    //clicked card
                    Card(hit.collider.gameObject);
                }
                if(hit.collider.CompareTag("Top"))
                {
                    //clicked top
                    Top();
                }
                if(hit.collider.CompareTag("Bottom"))
                {
                    //clicked bottom
                    Bottom();
                }
            }
        }
    }

    void Top()
    {
        print("clicked top");
    }

    void Card(GameObject selected)
    {
        print("clicked card");
        //if the card clicked on is facedown  and etc...
        if(slot1 == this.gameObject)
        {
            slot1 = selected;
        }
        else if(slot1 != selected)
        {
            if(Stackable(selected))
            {

            }
            else
            {
                slot1 = selected;

            }



            
            
        }
    }
    void Bottom()
    {
        print("clicked bottom");
    }
    void Deck()
    {
        print("clicked deck");
        solitaire.DealFromDeck();
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        //compare them to see if they stack
        
        //if in the top pile must stack suited Ace to King
        if(s2.top)
        {
            if(s1.suit == s2.suit || (s1.value == 1 && s2.suit == null))
            {
                if(s1.value == s2.value + 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else //if in the bottom pile must stack alternate colours king to Ace
        {
            if(s1.value == s2.value - 1)
            {
                bool card1Red = true;
                bool card2Red = true;

                if(s1.suit == "C" || s1.suit == "S")
                {
                    card1Red = false;
                }

                if(s2.suit == "C" || s2.suit == "S")
                {
                    card2Red = false;
                }

                if(card1Red == card2Red)
                {
                    print("Not stackable");
                    return false;
                }
                else
                {
                    print("stackable");
                    return true;
                }


            }
        }

        return false;
    }
}
