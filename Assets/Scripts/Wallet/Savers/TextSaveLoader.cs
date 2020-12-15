using System;
using System.Collections.Generic;
using System.IO;

internal class TextSaveLoader : ISaveLoadable
{
    private const string path = "Assets/save.txt";

    public void Save(Dictionary<CurrencyType, int> walletDictionary)
    {
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                writer.WriteLine(currencyType + " " +
                    (walletDictionary.ContainsKey(currencyType) ? walletDictionary[currencyType] : default(int)));
            }
        }
    }

    public Dictionary<CurrencyType, int> Load()
    {
        string line;
        Dictionary<CurrencyType, int> walletDictionary = new Dictionary<CurrencyType, int>();

        if(File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] keyValue = line.Split(' ');
                    CurrencyType currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), keyValue[0]);
                    walletDictionary[currencyType] = int.Parse(keyValue[1]);
                }
            }
        }

        return walletDictionary;
    }
}