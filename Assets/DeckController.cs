using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public List<GameObject> deckObjects;
    public GameObject currentDeck;
    public enum action { AddCard, RemoveCard, OrderByType, OrderByHP, OrderByRarity };//, SwitchDeck , AddDeck, RemoveDeck };
    public action currentAction;
    // Start is called before the first frame update
    void Start()
    {
        currentAction = action.AddCard;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectAction(action action, string cardName)
    {
        switch (action)
        {
            case (action.AddCard):
                AddCardFunction(cardName);
                break;
            case (action.RemoveCard):
                RemoveCardFunction(cardName);
                break;
            case (action.OrderByHP):
                OrderByHP();
                break;
            case (action.OrderByRarity):
                OrderByRarity();
                break;
            case (action.OrderByType):
                OrderByType();
                break;
            default:
                Debug.Log("Order Not Possible");
                break;
        }
    }

    void AddCardFunction(string name)
    {
        Debug.Log("Adding card " + name + " to " + currentDeck.name);
        currentDeck.GetComponent<DeckCardHandler>().GenerateCard(name);
    }

    void RemoveCardFunction(string name)
    {
        currentDeck.GetComponent<DeckCardHandler>().RemoveCard(name);
    }
    void OrderByHP()
    {
        Debug.Log("Calling Order By HP");
        currentDeck.GetComponent<DeckCardHandler>().OrderDeckByHP();
    }
    void OrderByType()
    {
        currentDeck.GetComponent<DeckCardHandler>().OrderDeckByType();
    }

    void OrderByRarity()
    {
        currentDeck.GetComponent<DeckCardHandler>().OrderDeckByRarity();
    }

    public void SwitchAction()//action currentAction
    {
        int intAction = (int)currentAction;
        //switch to the first action if the current one is the last
        if (currentAction == action.OrderByRarity)
            currentAction = action.AddCard;
        else
            currentAction = (action)(intAction+1);
        Debug.Log(currentAction.ToString());

        //change button text to correspond to new one
        gameObject.transform.Find("ActionButton").transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentAction.ToString();

        //
        if(currentAction.ToString().StartsWith("Order"))
        {
            Debug.Log("Order function called");
            SelectAction(currentAction, null);
        }
    }

    //change deck to next one or previous one depending on the button pressed
    public void SwitchCurrentDeck(GameObject buttonPressed)
    {
        //enable the new current deck to perform actions, while disabling the previous one
        if(currentDeck==deckObjects[deckObjects.Count-1]&&buttonPressed.name=="NextDeck")
        {
            currentDeck = deckObjects[0];
            currentDeck.SetActive(true);
            deckObjects[deckObjects.Count - 1].SetActive(false);
        }
        else if (currentDeck == deckObjects[0] && buttonPressed.name == "PrevDeck")
        {
            currentDeck = deckObjects[deckObjects.Count - 1];
            currentDeck.SetActive(true);
            deckObjects[0].SetActive(false);
        }
        else if(buttonPressed.name== "NextDeck")
        {
            int i=deckObjects.IndexOf(currentDeck);

            currentDeck = deckObjects[i+1];
            currentDeck.SetActive(true);
            deckObjects[i].SetActive(false);
        }
        else if (buttonPressed.name == "PrevDeck")
        {
            int i = deckObjects.IndexOf(currentDeck);

            currentDeck = deckObjects[i - 1];
            currentDeck.SetActive(true);
            deckObjects[i].SetActive(false);
        }
        else
        {
            Debug.Log("No such case");
        }

        //also set scroll rect to new object
        GetComponent<ScrollRect>().content = currentDeck.GetComponent<RectTransform>();
    }
}
