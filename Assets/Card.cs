using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.IO;

/*[System.Serializable]
public class Data
{
    public Card card;

    public static Data GetData(string id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards/" + id);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        Debug.Log("Json downloaded is: " + json);

        return JsonUtility.FromJson<Data>(json);
    }
}

[System.Serializable]
public class Card
{
    public string id;
    public string name;

    public string hp;
    public List<string> types;
    public string rarity;

    public string data;
    //public class da

    public static Card GetCard(string id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards/" + id);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        Debug.Log("Json downloaded is: " + json);

        return JsonUtility.FromJson<Card>(json);
    }

    
}
*/

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

public class Images
{
    public string symbol ;
    public string logo ;
    public string small ;
    public string large ;
}

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
    public Data data;//;

    public static Root GetData(string id)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.pokemontcg.io/v2/cards/" + id);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();

        Debug.Log("Json downloaded is: " + json);

        return JsonUtility.FromJson<Root>(json);
    }
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


