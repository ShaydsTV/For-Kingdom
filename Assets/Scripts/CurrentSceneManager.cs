using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerEnabled = false;
    public int coinsPickedUp;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène.");
            return;
        }

        instance = this;
    }
}
