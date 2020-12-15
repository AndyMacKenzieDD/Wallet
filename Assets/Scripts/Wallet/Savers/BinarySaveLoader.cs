using System;
using System.Collections.Generic;
using System.IO;

internal class BinarySaveLoader : ISaveLoadable
{
    private const string path = "Assets/save.dat";

    public void Save(Dictionary<CurrencyType, int> walletDictionary)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                writer.Write(currencyType.ToString());
                writer.Write(walletDictionary.ContainsKey(currencyType) ? walletDictionary[currencyType] : default(int));
            }
        }
    }

    public Dictionary<CurrencyType, int> Load()
    {
        Dictionary<CurrencyType, int> walletDictionary = new Dictionary<CurrencyType, int>();

        if(File.Exists(path))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    CurrencyType currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), reader.ReadString());
                    walletDictionary[currencyType] = reader.ReadInt32();
                }
            }
        }

        return walletDictionary;
    }
}
