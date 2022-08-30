using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using TMPro;
public class DeckCardHandler : MonoBehaviour //,IPointerClickHandler
{
    public List<GameObject> cardObjects=new List<GameObject>();
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
        //also edit its stats by consulting the root object
        Root root = GameObject.Find("Canvas").transform.Find("DeckMenu").transform.Find("CardSelect").Find("CardDisplay").GetComponent<CardDiplay>().root;
        string idName = name.Remove(0, 4);//remove word 'Card' from name
        Debug.Log(idName);
        int cardId = int.Parse(idName);
        newCard.GetComponent<CardStatsCondensed>().id = root.data[cardId].id;
        newCard.GetComponent<CardStatsCondensed>().cardName = root.data[cardId].name;
        //Debug.Log(root.data[cardId].hp);
        if (root.data[cardId].hp == null)
            root.data[cardId].hp = "-1";
        newCard.GetComponent<CardStatsCondensed>().HP = int.Parse(root.data[cardId].hp);
        //Debug.Log(root.data[cardId].types[0]);
        if (root.data[cardId].types.Count == 0)
        {
            Debug.Log("Empty Type");
            root.data[cardId].types.Add("NoType");
        }
        /*if (root.data[cardId].types[0] == null)
            root.data[cardId].types[0] = "NoType";*/
        newCard.GetComponent<CardStatsCondensed>().type = root.data[cardId].types[0];
        newCard.GetComponent<CardStatsCondensed>().rarity = root.data[cardId].rarity;

        //cardObjects.Add(name);
        cardObjects.Add(newCard.gameObject);
    }

    public void RemoveCard(string name)
    {
        //first check if the clicked card is included in the deck
        if(cardObjects.Count<=1)
        {
            //Debug.Log("no cards in this deck. Please add before removing!");
            Debug.Log("The Deck must have at least one card!");
            return;
        }
        GameObject gameObjectToDelete = gameObject.transform.Find(name).gameObject;
        //
        int counter=-1;
        if (gameObjectToDelete)
        {
            Debug.Log("Will remove" + gameObjectToDelete.name);
            //cardObjects.Remove
            for(int i=0;i<cardObjects.Count;i++)
            {
                if(cardObjects[i].name==gameObjectToDelete.name)
                {
                    counter = i;
                    break;
                }
            }

            if(counter==-1)
            { 
                Debug.Log("Object not found");
            }
            else
            {
                //delete from list and gameobject
                cardObjects.RemoveAt(counter);
                Destroy(gameObjectToDelete);
                //sort again gameobjects in the list
                for (int i = counter; i < cardObjects.Count; i++)
                {
                    cardObjects[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, cardObjects[i].GetComponent<RectTransform>().anchoredPosition.y + 15f);
                }

            }
        }

    }

  
}
