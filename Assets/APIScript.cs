using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.IO;

public class APIScript : MonoBehaviour
{
    public Root myRoot;
    // Start is called before the first frame update
    void Start()
    {
        /*Card myCard = new Card(); 
        myCard=Card.GetCard("xy1-1");
        //myCard.id=JsonUtility.FromJson<Card>()
        Debug.Log(myCard.id);
        Debug.Log(myCard.name);
        Debug.Log(myCard.hp);
        Debug.Log(myCard.data);

        Data myData = new Data();
        myData = Data.GetData("xy1-1");
        Debug.Log(myData.card.id);
        Debug.Log(myData.card.name);
        Debug.Log(myData.card.hp);
        Debug.Log(myData.card.data);*/
        
        //Data data = new Data();

        //myRoot = Root.GetData("xy1-1");

        //myRoot
        /*Debug.Log(myRoot.data.id);
        Debug.Log(myRoot.data.name);
        Debug.Log(myRoot.data.hp);
        Debug.Log(myRoot.data.images.small);
        Debug.Log(myRoot.data.images.large);
        Debug.Log(myRoot.data.legalities.expanded);*/

        //myRoot.SearchCards("nationalPokedexNumbers:[1 TO 2]");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
