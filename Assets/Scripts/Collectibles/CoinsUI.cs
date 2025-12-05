using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsCountTxt;

    public void UpdateUI(int value)
    {
        coinsCountTxt.text = "Coins : " + value;
    }
}
