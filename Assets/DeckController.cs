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
            default:
                break;
        }
    }

    void AddCardFunction(string name)
    {
        Debug.Log("Adding card " + name+" to "+currentDeck.name);
        currentDeck.GetComponent<DeckCardHandler>().GenerateCard(name);
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
}
