using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Unity.UI;
using System.Net;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class CardDiplay : MonoBehaviour
{
    //declare main object of root of card objects
    public static Root root;//=new Root();

    //
    bool loadingDone = false;
    static bool webLoad = false;
    int cardLoads = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://api.pokemontcg.io/v2/cards?q=set.id:base1"));
        //
        //CardLoad(null);
        //CardLoad("id-x");

        
    }
    static IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    //CardDiplay.root = Root.GetData(uri);
                    //callRoot(uri);
                    //StreamReader reader = new StreamReader(webRequest.downloadHandler.text);
                    string toRead = webRequest.downloadHandler.text;
                    //Debug.Log(toRead);
                    /*
                     StreamReader reader = new StreamReader(toRead);
                    string json = reader.ReadToEnd();
                    //string json = url;

                    Debug.Log("Json downloaded is: " + json);

                    //root= JsonUtility.FromJson<Root>(json);
                    */
                    root= JsonUtility.FromJson<Root>(toRead);
                    //root = Root.GetData(uri);
                    Debug.Log(root.data[0].artist);
                    Debug.Log(root.data[1].artist);
                    Debug.Log(root.data[10].artist);
                    Debug.Log(root.data[100].artist);

                    //Now we have connected succesfuly online
                    webLoad = true;
                    break;
            }
        }
    }
    /*public void callRoot(string url)
    {
        root = Root.GetData(url);
    }*/
    // Update is called once per frame
    void Update()
    {
        if (webLoad == true)
        {
            Debug.Log("Webloaded");
            CardLoad("id-x");
            webLoad = false;
        }
        else
        {
            //Debug.Log("Webloaded false");
        }
        //After loading the cards, disable the objects grandparent,
        //until re-activated by the menu button
        if (loadingDone == true)
        {
            Debug.Log("Loading Done!");
            Debug.Log(root.data[0].artist);
            
            gameObject.transform.parent.transform.parent.gameObject.SetActive(false);

            //remove loading image as well
            GameObject.Find("Canvas").transform.Find("LoadingImage").gameObject.SetActive(false);
            //disable aboutmenu too
            GameObject.Find("Canvas").transform.Find("AboutMenu").gameObject.SetActive(false);

            loadingDone = false;
        }

    }

    void CardLoad(string set)
    {
        Debug.Log("Called CardLoad");
        GameObject row = gameObject.transform.Find("Row").gameObject;

        //assign data from the set to the main class
        //Root root = Root.GetData(null);
        //root = Root.GetData(null);

        /* root = Root.GetData("id-x");*/

        //
        Debug.Log("Calling GenerateRows");
        Debug.Log(row.name);
        Debug.Log(row.transform.childCount);
        Debug.Log(root.data.Count);
        GenerateRows(root, row, row.transform.childCount);

        //assign images by number
        int counter = 0;
        Debug.Log("Calling loop");
        foreach (Transform rowT in row.transform.parent)
        {
            Debug.Log("first loop");
            foreach (Transform card in rowT.transform)
            {
                Debug.Log("second loop");

                //rename default card object
                Debug.Log(card.gameObject.name);
                card.gameObject.name ="Card"+ counter.ToString();

                //Debug.Log(card.name);
                Debug.Log(counter);
                Debug.Log(root.data.Count);

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
                Debug.Log("Calling GetText");
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
