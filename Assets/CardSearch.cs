using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
[System.Serializable]
public class Datum
{
    public string id;
    public string name;
    public string supertype;
    public List<string> subtypes;
    public string level;
    public string hp;
    public List<string> types;
    public List<Attack> attacks;
    public List<Weakness> weaknesses;
    public List<Resistance> resistances;
    public List<string> retreatCost;
    public int convertedRetreatCost;
    public Set set;
    public string number;
    public string artist;
    public string rarity;
    public List<int> nationalPokedexNumbers;
    public Legalities legalities;
    public Images images;
    public Tcgplayer tcgplayer;
    public Cardmarket cardmarket;
    public string evolvesFrom;
    public List<Ability> abilities;
    public List<string> evolvesTo;
    public string flavorText;
    public List<string> rules;
    public string regulationMark;
}

public class Resistance
{
    public string type;
    public string value;
}

/*
public class _1stEditionHolofoil
{
    public double low ;
    public double mid ;
    public double high ;
    public double market ;
    public double? directLow ;
}

public class Holofoil
{
    public double low ;
    public double mid ;
    public double high ;
    public double market ;
    public double? directLow ;
}



[System.Serializable]
public  class Root
{
    public List<Datum> data ;
    public int page ;
    public int pageSize ;
    public int count ;
    public int totalCount ;
}

public class UnlimitedHolofoil
{
    public double low ;
    public double mid ;
    public double high ;
    public double market ;
    public double directLow ;
}

*/

