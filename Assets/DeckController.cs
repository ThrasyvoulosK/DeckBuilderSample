using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public List<GameObject> deckObjects;
    public GameObject currentDeck;
    public enum action { AddCard, RemoveCard, OrderByType, OrderByHP, OrderByRarity, SwitchDeck, AddDeck, RemoveDeck };
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
        Debug.Log("Adding card " + name);
    }
}
