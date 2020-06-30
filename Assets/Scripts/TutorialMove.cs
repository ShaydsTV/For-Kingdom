using UnityEngine;
using UnityEngine.UI;

public class TutorialMove : MonoBehaviour
{

    private bool isInRange;

    private PlayerController playerController;
    private Text tutorialMoveUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        tutorialMoveUI = GameObject.FindGameObjectWithTag("TutorialMoveUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialMoveUI.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            tutorialMoveUI.enabled = false;
    }
}
