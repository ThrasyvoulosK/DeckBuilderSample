using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using TMPro;
public class DeckCardHandler : MonoBehaviour //,IPointerClickHandler
{
    public List<string> cardObjects=new List<string>();
    //write down available actions for the deck
    //enum action { AddCard, RemoveCard,OrderByType,OrderByHP,OrderByRarity,SwitchDeck,AddDeck,RemoveDeck };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void ClickAction()
    {

    }*/
    public void GenerateCard(string name)
    {
        Transform newCard,lastCard;
        //re-write empty entry if it's the only one on the list
        if(cardObjects.Count==0)
        {
            Debug.Log("Zero cards in deck");
            newCard = transform.Find("DeckCard").gameObject.transform;
            
        }
        else
        {
            //Find the last card and generate after it
            Debug.Log("Deck not empty");
            //int numberOfChildren = transform.Find("DeckCard").gameObject.transform.childCount;
            //int numberOfChildren = transform.parent.gameObject.transform.childCount;
            int numberOfChildren = transform.childCount;
            Debug.Log(numberOfChildren);
            //lastCard = transform.parent.gameObject.transform.GetChild(numberOfChildren-1);
            Debug.Log(transform.name);
            lastCard = transform.GetChild(numberOfChildren-1);
            Debug.Log(lastCard.name);

            GameObject addedCard = Instantiate(lastCard.gameObject, lastCard.transform.parent);
            addedCard.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, lastCard.GetComponent<RectTransform>().anchoredPosition.y - 15f);
            newCard = addedCard.transform;
        }
        Debug.Log("Editing attributes");
        //edit its attributes
        newCard.GetComponent<TextMeshProUGUI>().text = name;
        newCard.name = name;

        cardObjects.Add(name);
    }

    public void RemoveCard(string name)
    {
        //first check if the clicked card is included in the deck
        if(cardObjects.Count==0)
        {
            Debug.Log("no cards in this deck. Please add before removing!");
            return;
        }

    }

  
}
