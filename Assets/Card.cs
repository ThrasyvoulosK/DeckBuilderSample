using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.IO;
using UnityEngine.Networking;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Ability
{
    public string name ;
    public string text ;
    public string type ;
}

public class Attack
{
    public string name ;
    public List<string> cost ;
    public int convertedEnergyCost ;
    public string damage ;
    public string text ;
}

public class Cardmarket
{
    public string url ;
    public string updatedAt ;
    public Prices prices ;
}

[System.Serializable]
public class Data
{
    public string id;//;
    public string name ;
    public string supertype ;
    public List<string> subtypes ;
    public string hp ;
    public List<string> types ;
    public string evolvesFrom ;
    public List<Ability> abilities ;
    public List<Attack> attacks ;
    public List<Weakness> weaknesses ;
    public List<string> retreatCost ;
    public int convertedRetreatCost ;
    public Set set ;
    public string number ;
    public string artist ;
    public string rarity ;
    public string flavorText ;
    public List<int> nationalPokedexNumbers ;
    public Legalities legalities ;
    public string regulationMark ;
    public Images images ;
    public Tcgplayer tcgplayer ;
    public Cardmarket cardmarket ;
}

/*[System.Serializable]
public class Images
{
    [SerializeField]
    public string symbol ;
    [SerializeField]
    public string logo ;
    [SerializeField]
    public string small ;
    [SerializeField]
    public string large ;
}*/

[System.Serializable]
public class Images
{
    [SerializeField]
    public string small ;
    [SerializeField]
    public string large ;
}

[System.Serializable]
public class Legalities
{
    public string unlimited ;
    public string standard ;
    public string expanded ;
}

public class Normal
{
    public double low ;
    public double mid ;
    public double high ;
    public double market ;
    public double directLow ;
}

public class Prices
{
    public Normal normal ;
    public ReverseHolofoil reverseHolofoil ;
    public double averageSellPrice ;
    public double lowPrice ;
    public double trendPrice ;
    public double reverseHoloSell ;
    public double reverseHoloLow ;
    public double reverseHoloTrend ;
    public double lowPriceExPlus ;
    public double avg1 ;
    public double avg7 ;
    public double avg30 ;
    public double reverseHoloAvg1 ;
    public double reverseHoloAvg7 ;
    public double reverseHoloAvg30 ;
}

public class ReverseHolofoil
{
    public double low ;
    public double mid ;
    public double high ;
    public double market ;
    public double directLow ;
}

[System.Serializable]
public class Root
{
    //public Data data;//;

    //Further info required for searching cards
    public List<Datum> data;
    public int page;
    public int pageSize;
    public int count;
    public int totalCount;

    //Functions

    public static Root GetData(string url)
    {
        /*
        //MonoBehaviour.StartCoroutine(GetRequest("https://error.html"));

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards/" + id);
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards?q=set.id:base1");
        string url = "https://api.pokemontcg.io/v2/cards?q=set.id:base1";         
        //WebRequest request = WebRequest.Create(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //WebResponse response = request.GetResponse();
        UnityWebRequest.Result response = request.result;
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //StreamReader reader = new StreamReader(response.ToString());
        Debug.Log(request.downloadHandler.text);
        StreamReader reader = new StreamReader(request.downloadHandler.text);
        */
        //string json = reader.ReadToEnd();

        StreamReader reader = new StreamReader(url);
        string json = reader.ReadToEnd();
        //string json = url;

        Debug.Log("Json downloaded is: " + json);

        return JsonUtility.FromJson<Root>(json);
    }

    

    /*
    public void SearchCards(string query)
    {
        Debug.Log("https://api.pokemontcg.io/v2/cards?" + query);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards?" + query);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        Debug.Log("Json downloaded for SearchCards is: " + json);

        //return JsonUtility.FromJson<Root>(json);
    }*/
}

public class Set
{
    public string id ;
    public string name ;
    public string series ;
    public int printedTotal ;
    public int total ;
    public Legalities legalities ;
    public string ptcgoCode ;
    public string releaseDate ;
    public string updatedAt ;
    public Images images ;
}

public class Tcgplayer
{
    public string url ;
    public string updatedAt ;
    public Prices prices ;
}

public class Weakness
{
    public string type ;
    public string value ;
}


