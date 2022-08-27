using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.UI;
using System.Net;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardDiplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CardLoad(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CardLoad(string set)
    {
        GameObject row = gameObject.transform.Find("Row").gameObject;
        foreach(Transform card in row.transform)
        {
            Debug.Log(card.name);
            Root root = Root.GetData("xy1-1");

            SpriteRenderer spriteRenderer = card.gameObject.GetComponent<Image>().GetComponent<SpriteRenderer>();

            //card.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = root.data.images.symbol;
            /*Debug.Log(root.data.id);
            Debug.Log(root.data.name);
            Debug.Log(root.data.hp);
            Debug.Log(root.data.images.logo);
            */

            //spriteRenderer.sprite= root.data.images.small;

            //UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(root.data.images.small);
            //spriteRenderer.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0, 0, 50,50), new Vector2(0, 0));

            StartCoroutine(GetText(card.gameObject,spriteRenderer));

            //spriteRenderer.sprite = Resources.Load<Sprite>("https://images.pokemontcg.io/xy1/logo.png");

            //card.gameObject.GetComponent<UnityEngine.UI.Image>().sprite= Resources.Load<Sprite>("https://images.pokemontcg.io/xy1/logo.png");
            //Debug.Log(card.gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name);

            //Image image = card.gameObject.GetComponent<Image>();
            //image.sprite= Resources.Load<Sprite>("https://images.pokemontcg.io/xy1/logo.png");
            //spriteRenderer.sprite= Resources.Load<Sprite>("https://images.pokemontcg.io/xy1/logo.png");
        }
    }

    IEnumerator GetText(GameObject gameObject,SpriteRenderer spriteRenderer)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("https://www.my-server.com/myimage.png");
        yield return uwr.SendWebRequest();
        //spriteRenderer.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0, 0, 50, 50), new Vector2(0, 0));
        //Debug.Log(spriteRenderer.sprite.name);

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            // Get downloaded asset bundle
            //var texture = DownloadHandlerTexture.GetContent(uwr);
            //Debug.Log(texture.width);
            Texture2D webTexture = ((DownloadHandlerTexture)uwr.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            gameObject.GetComponent<Image>().sprite = webSprite;
        }

        /*using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture("https://www.my-server.com/myimage.png"))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                var texture = DownloadHandlerTexture.GetContent(uwr);
                Debug.Log(texture.width);
            }
            spriteRenderer.sprite = Sprite.Create(DownloadHandlerTexture.GetContent(uwr), new Rect(0, 0, 50, 50), new Vector2(0, 0));
            Debug.Log(spriteRenderer.sprite.name);
        }*/
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
