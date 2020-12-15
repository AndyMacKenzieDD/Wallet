using System;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerPrefsSaveLoader : ISaveLoadable
{
    public void Save(Dictionary<CurrencyType, int> walletDictionary)
    {
        foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
        {
            PlayerPrefs.SetInt(currencyType.ToString(),
                walletDictionary.ContainsKey(currencyType) ? walletDictionary[currencyType] : default(int));
        }
    }

    public Dictionary<CurrencyType, int> Load()
    {
        var walletDictionary = new Dictionary<CurrencyType, int>();

        foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
        {
            walletDictionary[currencyType] = PlayerPrefs.GetInt(currencyType.ToString());
        }

        return walletDictionary;
    }
}
