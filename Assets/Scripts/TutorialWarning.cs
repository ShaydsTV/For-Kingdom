using UnityEngine;
using UnityEngine.UI;

public class TutorialWarning : MonoBehaviour
{

    private bool isInRange;

    private PlayerController playerController;
    private Text tutorialWarningUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tutorialWarningUI = GameObject.FindGameObjectWithTag("TutorialWarningUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialWarningUI.enabled = true;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialWarningUI.enabled = false;
    }
}
