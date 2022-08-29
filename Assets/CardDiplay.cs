using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.UI;
using System.Net;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardDiplay : MonoBehaviour
{
    //declare main object of root of card objects
    Root root;

    //
    bool loadingDone = false;
    int cardLoads = 0;

    // Start is called before the first frame update
    void Start()
    {
        //
        CardLoad(null);

        
    }

    // Update is called once per frame
    void Update()
    {
        //After loading the cards, disable the objects grandparent,
        //until re-activated by the menu button
        if (loadingDone == true)
        {
            Debug.Log("Loading Done!");
            Debug.Log(root.data[0].artist);
            
            gameObject.transform.parent.transform.parent.gameObject.SetActive(false);

            loadingDone = false;
        }

    }

    void CardLoad(string set)
    {
        GameObject row = gameObject.transform.Find("Row").gameObject;

        //assign data from the set to the main class
        //Root root = Root.GetData(null);
        root = Root.GetData(null);

        //
        GenerateRows(root, row, row.transform.childCount);

        //assign images by number
        int counter = 0;
        foreach (Transform rowT in row.transform.parent)
        {
            foreach (Transform card in rowT.transform)
            {
                //rename default card object
                card.gameObject.name ="Card"+ counter.ToString();

                //Debug.Log(card.name);
                Debug.Log(counter);

                //do not try to assign more cards than those in the set
                if (counter >= root.data.Count)
                {
                    /*
                    //We are also finished with loading cards
                    loadingDone = true;

                    Debug.Log(root.data[counter - 1].images.small);
                    Debug.Log(card.gameObject.GetComponent<Image>().sprite.name);
                    */
                    break;
                }
                StartCoroutine(GetText(card.gameObject, root, counter));
                counter++;
                
            }
        }
    }

    IEnumerator GetText(GameObject gameObject,Root root,int counter)
    {

        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(root.data[counter].images.small);
        
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            // Get downloaded asset bundle
            //Debug.Log(texture.width);
            Texture2D webTexture = ((DownloadHandlerTexture)uwr.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            gameObject.GetComponent<Image>().sprite = webSprite;

            gameObject.GetComponent<Image>().preserveAspect = true;

            cardLoads++;
            //Debug.Log(gameObject.GetComponent<Image>().sprite.name);
            if (cardLoads == root.data.Count)
            {
                Debug.Log("coroutines finish");
                loadingDone = true;
            }
        }

        
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    //generate as many rows as needed to include every card in the set
    void GenerateRows(Root root,GameObject row, int entriesInRow)
    {
        int numberOfEntries = root.data.Count;
        //Debug.Log(numberOfEntries);

        int numberOfRows = numberOfEntries / entriesInRow;
        //Debug.Log(numberOfRows);

        for(int i=1;i<numberOfRows;i++)
        {
            GameObject newRow = Instantiate(row, row.transform.parent);

            //Set new entry's position relatively to the original
            newRow.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, row.GetComponent<RectTransform>().anchoredPosition.y - i * 50f);
        }

    }
}
