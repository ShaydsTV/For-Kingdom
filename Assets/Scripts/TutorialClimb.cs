using UnityEngine;
using UnityEngine.UI;

public class TutorialClimb : MonoBehaviour
{

    private bool isInRange;

    private PlayerController playerController;
    private Text tutorialClimbUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tutorialClimbUI = GameObject.FindGameObjectWithTag("TutorialClimbUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialClimbUI.enabled = true;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialClimbUI.enabled = false;
    }
}
