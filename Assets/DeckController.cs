using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public void SelectAction(action action,string cardName)
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
                break;
            case (action.OrderByRarity):
                break;
            case (action.OrderByType):
                break;
            default:
                break;
        }
    }

    void AddCardFunction(string name)
    {
        Debug.Log("Adding card " + name+" to "+currentDeck.name);
        currentDeck.GetComponent<DeckCardHandler>().GenerateCard(name);
    }

    void RemoveCardFunction(string name)
    {
        currentDeck.GetComponent<DeckCardHandler>().RemoveCard(name);
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
    }
}
