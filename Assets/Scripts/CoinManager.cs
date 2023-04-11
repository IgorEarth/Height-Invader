using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class CoinManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);


    public int NumberOfCoins;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _advButton;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
        
#endif
        _text.text = NumberOfCoins.ToString();

        transform.parent = null;
    }

    public void AddOne()
    {
        NumberOfCoins++;
        _text.text = NumberOfCoins.ToString();
    }

    public void SaveToProgress()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        Progress.Instance.PlayerInfo.Coins = NumberOfCoins;
#endif
    }

    public void SpendMoney(int value)
    {
        NumberOfCoins -= value;
        _text.text = NumberOfCoins.ToString();
    }

    public void ShowAdvButton()
    {
        AddCoinsExtern(100);
        _advButton.SetActive(false);
    }

    public void AddCoins(int value)
    {
        NumberOfCoins += value;
        _text.text = NumberOfCoins.ToString();
        SaveToProgress();
    }
}
