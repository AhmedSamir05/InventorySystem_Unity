using UnityEngine;
[DefaultExecutionOrder(2000)]
public class CoinUIController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI coinText;

    private void OnEnable()
    {
        CoinManager.Instance.OnCoinUpdated += UpdateCoinUI;
        UpdateCoinUI(CoinManager.Instance.GetCoins());
    }

    private void OnDisable()
    {
        if (CoinManager.Instance != null)
            CoinManager.Instance.OnCoinUpdated -= UpdateCoinUI;
    }

    private void UpdateCoinUI(int newCoinAmount)
    {
        if (coinText != null)
            coinText.text = newCoinAmount.ToString();
    }
}
