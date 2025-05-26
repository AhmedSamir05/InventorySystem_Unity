using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    private const string CoinKey = "PlayerCoins";
    private int coins;

    // Fired on coin changes
    public event Action<int> OnCoinUpdated; 

    private void Awake()
    {
        Instance = this;
        LoadCoins();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt(CoinKey, 9999);
        OnCoinUpdated?.Invoke(coins);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinKey, coins);
    }

    public int GetCoins() => coins;

    public void AddCoins(int amount)
    {
        coins += amount;
        SaveCoins();
        OnCoinUpdated?.Invoke(coins);
    }

    public bool SpendCoins(int amount)
    {
        if (coins < amount) 
            return false;
        coins -= amount;
        SaveCoins();
        OnCoinUpdated?.Invoke(coins);
        return true;
    }
}
