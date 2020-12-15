using UnityEngine;

public class UI : MonoBehaviour
{
    private const int fontSize = 50;
    private Wallet wallet;

    void Start()
    {
        wallet = Wallet.Current;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        GUI.skin.button.fontSize = fontSize;

        GUI.Label(new Rect(0, 0, 250, 150), CurrencyType.Diamond.ToString());
        GUI.Label(new Rect(300, 0, 150, 150), wallet.GetBalance(CurrencyType.Diamond).ToString());

        GUI.Label(new Rect(0, 150, 500, 150), CurrencyType.Coin.ToString());
        GUI.Label(new Rect(300, 150, 500, 150), wallet.GetBalance(CurrencyType.Coin).ToString());

        //Increment
        if (GUI.Button(new Rect(500, 0, 450, 150), $"Add {CurrencyType.Diamond}"))
        {
            wallet.Increment(CurrencyType.Diamond);
        }

        if (GUI.Button(new Rect(500, 150, 450, 150), $"Add {CurrencyType.Coin}"))
        {
            wallet.Increment(CurrencyType.Coin);
        }

        //Reset
        if (GUI.Button(new Rect(1000, 0, 450, 150), $"Reset {CurrencyType.Diamond}"))
        {
            wallet.Reset(CurrencyType.Diamond);
        }

        if (GUI.Button(new Rect(1000, 150, 450, 150), $"Reset {CurrencyType.Coin}"))
        {
            wallet.Reset(CurrencyType.Coin);
        }

        //SaveLoad
        //PlayerPrefs
        if (GUI.Button(new Rect(0, 350, 450, 150), $"Save {SaveLoadType.PlayerPrefs}"))
        {
            wallet.Save(SaveLoadType.PlayerPrefs);
        }

        if (GUI.Button(new Rect(0, 500, 450, 150), $"Load {SaveLoadType.PlayerPrefs}"))
        {
            wallet.Load(SaveLoadType.PlayerPrefs);
        }

        //Text
        if (GUI.Button(new Rect(500, 350, 450, 150), $"Save {SaveLoadType.Text}"))
        {
            wallet.Save(SaveLoadType.Text);
        }

        if (GUI.Button(new Rect(500, 500, 450, 150), $"Load {SaveLoadType.Text}"))
        {
            wallet.Load(SaveLoadType.Text);
        }

        //Binary
        if (GUI.Button(new Rect(1000, 350, 450, 150), $"Save {SaveLoadType.Binary}"))
        {
            wallet.Save(SaveLoadType.Binary);
        }

        if (GUI.Button(new Rect(1000, 500, 450, 150), $"Load {SaveLoadType.Binary}"))
        {
            wallet.Load(SaveLoadType.Binary);
        }
    }
}
