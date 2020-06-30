using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Inventory in the scene.");
            return;
        }
        instance = this;
    }

    public void AddCoin(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoin(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }
}
