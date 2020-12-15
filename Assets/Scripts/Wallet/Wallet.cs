using System;
using WalletDictionary = System.Collections.Generic.Dictionary<CurrencyType, int>;

public class Wallet
{
    private static readonly Lazy<Wallet> lazy = new Lazy<Wallet>(() => new Wallet());
    WalletDictionary walletDictionary = new WalletDictionary();
    private ISaveLoadable saveLoader;

    private Wallet() { }

    public static Wallet Current => lazy.Value;

    public WalletDictionary GetBalance()
    {
        return walletDictionary;
    }

    public int GetBalance(CurrencyType currencyType)
    {
        return walletDictionary.ContainsKey(currencyType) ? walletDictionary[currencyType] : default(int);
    }

    public void SetBalance(CurrencyType currencyType, int value)
    {
        if(value >= 0)
        {
            walletDictionary[currencyType] = value;
        }
    }

    public void Increment(CurrencyType currencyType)
    {
        walletDictionary[currencyType] =
            walletDictionary.ContainsKey(currencyType) ? walletDictionary[currencyType] : default(int);
        walletDictionary[currencyType] += 1;
    }

    public void Reset(CurrencyType currencyType)
    {
        walletDictionary[currencyType] = default(int);
    }

    public void Save(SaveLoadType saveLoadType)
    {
        switch(saveLoadType)
        {
            case SaveLoadType.PlayerPrefs:
                saveLoader = new PlayerPrefsSaveLoader();
                break;
            case SaveLoadType.Text:
                saveLoader = new TextSaveLoader();
                break;
            case SaveLoadType.Binary:
                saveLoader = new BinarySaveLoader();
                break;
        }

        saveLoader.Save(walletDictionary);
    }

    public void Load(SaveLoadType saveLoadType)
    {
        switch (saveLoadType)
        {
            case SaveLoadType.PlayerPrefs:
                saveLoader = new PlayerPrefsSaveLoader();
                break;
            case SaveLoadType.Text:
                saveLoader = new TextSaveLoader();
                break;
            case SaveLoadType.Binary:
                saveLoader = new BinarySaveLoader();
                break;
        }

        walletDictionary = saveLoader.Load();
    }
}