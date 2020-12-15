using System.Collections.Generic;

internal interface ISaveLoadable
{
    void Save(Dictionary<CurrencyType, int> walletDictionary);
    Dictionary<CurrencyType, int> Load();
}
