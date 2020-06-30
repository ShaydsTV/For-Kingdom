using UnityEngine;
using UnityEngine.UI;

public class TutorialJump : MonoBehaviour
{

    private bool isInRange;

    private PlayerController playerController;
    private Text tutorialJumpUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tutorialJumpUI = GameObject.FindGameObjectWithTag("TutorialJumpUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialJumpUI.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialJumpUI.enabled = false;
    }
}
