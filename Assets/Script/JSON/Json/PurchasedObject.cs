using System;
using System.Collections.Generic;

[Serializable]
public class PurchasingData
{
    public int Coins = 0;
    public int LastSelectedShip = 0;
    public List<string> PurchasedObjects = new List<string>();
}

[Serializable]
public class PurchasedObject
{
    public string ObjectName;
    public bool Bougth;
    public int Index;
}

