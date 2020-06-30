using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    public BoxCollider2D platformCollider;

    private PlayerController playerController;
    private Text interactionUI;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        interactionUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.S)))
        {
            playerController.isClimbing = true;
            platformCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        platformCollider.isTrigger = false;
        playerController.isClimbing = false;
    }
}
