using TMPro;
using UnityEngine;
public class SavingCoins : MonoBehaviour
{
    public int mycoin;
    [SerializeField] private TMP_Text cointxt;
    void Start()
    {
        mycoin = PlayerPrefs.GetInt("Coins", 0);
        cointxt.text = "Coins: " + mycoin;
    }
}
