using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class DeckCardHandler : MonoBehaviour //,IPointerClickHandler
{
    List<string> cardObjects;
    //write down available actions for the deck
    enum action { AddCard, RemoveCard,OrderByType,OrderByHP,OrderByRarity,SwitchDeck,AddDeck,RemoveDeck };

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit2D.collider != null)
            {
                Debug.Log("raycast hits " + hit2D.collider.name);
                
            }
        }*/

        //if(mouse)
    }

    void ClickAction()
    {

    }

    /*public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " Game Object Clicked!");
        //throw new System.NotImplementedException();
    }*/
}
