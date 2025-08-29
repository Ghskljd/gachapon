using UnityEngine;

[System.Serializable]
public class CurrencyData
{
    private int currencyData;

    public CurrencyData(int currency)
    {
        currencyData = currency;
    }

    public int getCurrencyData()
    {
        return currencyData;
    }
}
