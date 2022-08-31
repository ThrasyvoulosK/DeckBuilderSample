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

    //Root root;

    // Start is called before the first frame update
    void Start()
    {
        //root = GameObject.Find("Canvas").transform.Find("DeckMenu").transform.Find("CardSelect").Find("CardDisplay").GetComponent<CardDiplay>().root;
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

        Debug.Log(root.data[0].name);
        Debug.Log(root.data[cardId].id);

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
        //Debug.Log(newCard.GetComponent<CardStatsCondensed>().rarity);

        //cardObjects.Add(name);

        //change name to cardname
        newCard.GetComponent<TextMeshProUGUI>().SetText(newCard.GetComponent<CardStatsCondensed>().cardName);
        newCard.name=newCard.GetComponent<CardStatsCondensed>().cardName;
        cardObjects.Add(newCard.gameObject);

        //
        root = null;
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

    public void OrderDeckByHP()
    {
        if (cardObjects.Count <= 1)
            return;

        Debug.Log("OrderDeckByHP called");

        cardObjects.Sort((p1, p2) => (p1.GetComponent<CardStatsCondensed>().HP).CompareTo(p2.GetComponent<CardStatsCondensed>().HP));
        int counter = 1;
        //RectTransform rectTransform = new RectTransform;
        //rectTransform = gameObject.transform.GetChild(1).position;
        //keep original position to rebuild later
        Vector2 vector2 = gameObject.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition;
        //Debug.Log(Vector2.y.ToString())
        foreach (GameObject gameObject in cardObjects)
        {
            /*Debug.Log("Clone" + gameObject.name);
            Debug.Log("Clone" + gameObject.GetComponent<CardStatsCondensed>().HP);
            Debug.Log("Clone" + gameObject.GetComponent<CardStatsCondensed>().cardName);*/
            //change position between siblings in transform
            gameObject.transform.SetSiblingIndex(counter);
            //gameObject.GetComponent<RectTransform>().anchoredPosition= new Vector2(0, vector2.y - 15f*(counter-1));
            gameObject.GetComponent<RectTransform>().anchoredPosition= new Vector2(vector2.x, vector2.y - 15f*(counter-1));
            counter++;
        }
    }
    public void OrderDeckByType()
    {
        if (cardObjects.Count <= 1)
            return;

        Debug.Log("OrderDeckByType called");

        cardObjects.Sort((p1, p2) => (p1.GetComponent<CardStatsCondensed>().type).CompareTo(p2.GetComponent<CardStatsCondensed>().type));
        int counter = 1;
        //keep original position to rebuild later
        Vector2 vector2 = gameObject.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition;
        foreach (GameObject gameObject in cardObjects)
        {
            //change position between siblings in transform
            gameObject.transform.SetSiblingIndex(counter);
            //gameObject.GetComponent<RectTransform>().anchoredPosition= new Vector2(0, vector2.y - 15f*(counter-1));
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(vector2.x, vector2.y - 15f * (counter - 1));
            counter++;
        }
    }

    public void OrderDeckByRarity()
    {
        if (cardObjects.Count <= 1)
            return;

        Debug.Log("OrderDeckByRarity called");

        cardObjects.Sort((p1, p2) => (p1.GetComponent<CardStatsCondensed>().rarity).CompareTo(p2.GetComponent<CardStatsCondensed>().rarity));
        int counter = 1;
        //keep original position to rebuild later
        Vector2 vector2 = gameObject.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition;
        foreach (GameObject gameObject in cardObjects)
        {
            //change position between siblings in transform
            gameObject.transform.SetSiblingIndex(counter);
            //gameObject.GetComponent<RectTransform>().anchoredPosition= new Vector2(0, vector2.y - 15f*(counter-1));
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(vector2.x, vector2.y - 15f * (counter - 1));
            counter++;
        }
    }

    public void OrderDeckByHP2()
    {
        //create a clone of the original list
        List<GameObject> cardObjectsClone = new List<GameObject>();
        foreach (GameObject gameObject in cardObjects)
        {
            GameObject newObject = Instantiate(gameObject);
            
            cardObjectsClone.Add(newObject);
            Debug.Log(gameObject.name);
        }
        //sort clone
        //cardObjectsClone.Sort(SortByHP);
        cardObjectsClone.Sort((p1, p2) => (p1.GetComponent<CardStatsCondensed>().HP).CompareTo(p2.GetComponent<CardStatsCondensed>().HP));
        foreach (GameObject gameObject in cardObjectsClone)
        {
            Debug.Log("Clone"+gameObject.name);
            Debug.Log("Clone"+gameObject.GetComponent<CardStatsCondensed>().HP);
            Debug.Log("Clone"+gameObject.GetComponent<CardStatsCondensed>().cardName);
            
        }

        cardObjects.Clear();
        //assign new objects on list
        //cardObjects.Sort(SortByHP);
        for (int i = 0; i < cardObjectsClone.Count; i++)
        {
            //cardObjects[i] = cardObjectsClone[i];
            //cardObjects[i].name = cardObjectsClone[i].name;
            //GameObject newGameObject=new GameObject();
            //newGameObject= Instatiate(cardObjectsClone[i]);
            //cardObjectsClone[i].name.Remove(-6);//remove clone from name
            //cardObjectsClone[i].name = cardObjectsClone[i].name.Substring(0,cardObjectsClone[i].name.Length- 7);
            Debug.Log(cardObjectsClone[i].name);
            cardObjects.Add(cardObjectsClone[i]);
            cardObjects[i].GetComponent<TextMeshProUGUI>().SetText(cardObjectsClone[i].name.Substring(0, cardObjectsClone[i].name.Length - 7));
        }
        
        /*for (int i=0;i<cardObjects.Count;i++)
        {
            CardStatsCondensed cardStats = cardObjects[i].GetComponent<CardStatsCondensed>();
            CardStatsCondensed cardStatsClone = cardObjectsClone[i].GetComponent<CardStatsCondensed>();

            Debug.Log("Clone's HPs:" + cardStatsClone.HP);
            cardObjects[i].name = cardObjectsClone[i].name;
            //
            //cardObjects[i].GetComponent<CardStatsCondensed>().HP = 9;
            cardStats.HP = cardStatsClone.HP;
            cardStats.id = cardStatsClone.id;
            cardStats.type = cardStatsClone.type;
            cardStats.rarity = cardStatsClone.rarity;
            cardStats.cardName = cardStatsClone.cardName;

            cardObjects[i].GetComponent<TextMeshProUGUI>().text = cardObjectsClone[i].GetComponent<TextMeshProUGUI>().text;
        }*/
        cardObjectsClone.Clear();
        int newCounter = 0;
        foreach(Transform game in gameObject.transform)
        {
            if (game.name == "DeckName")
                continue;
            game.name = cardObjects[newCounter].name;
            newCounter++;
        }
        Debug.Log("Sorting Ends");

    }
    static int SortByHP(GameObject p1, GameObject p2)
    {
        Debug.Log("Sort by hp minifunc");
        Debug.Log(p1.GetComponent<CardStatsCondensed>().HP.CompareTo(p2.GetComponent<CardStatsCondensed>().HP));
        return p1.GetComponent<CardStatsCondensed>().HP.CompareTo(p2.GetComponent<CardStatsCondensed>().HP);
    }


}
