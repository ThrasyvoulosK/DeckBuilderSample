using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
public class CardClick : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(name + " Game Object Clicked!");
        //throw new System.NotImplementedException();

        //call card deck handler for possible actions to be taken
        GameObject cardDeckHandler = GameObject.Find("Canvas").transform.Find("DeckMenu").transform.Find("MyDecks").gameObject;
        DeckController deckController = cardDeckHandler.GetComponent<DeckController>();
        //search for a suitable action based on current action and card chosen
        deckController.SelectAction(deckController.currentAction, name);
    }
}
