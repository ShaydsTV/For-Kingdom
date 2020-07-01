using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    
    public Quest quest;
    public Player player;

    // Quest information
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;

    // Checking collision variables and interactionUI display purpose.
    private bool isInRange;
    private PlayerController playerController;
    private Text interactionUI;
    private Text acceptUI;

    // Awake is called before Start()
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        interactionUI = GameObject.FindGameObjectWithTag("InteractionUI").GetComponent<Text>();
        acceptUI = GameObject.FindGameObjectWithTag("AcceptQuestUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (quest.isCompleted == false)
            {
                if (quest.isActive == false)
                {                   
                    OpenQuestWindow();
                }
                else if (quest.isActive == true)
                {
                    if (Inventory.instance.coinsCount < 10)
                    {
                        Debug.Log("Vous avez " + Inventory.instance.coinsCount);
                    }
                    else if (Inventory.instance.coinsCount >= 10)
                    {
                        // Replace Debug.Log with proper UI
                        Debug.Log("Merci pour vos pièces.");
                        
                        // Remove items from quest objective.
                        Inventory.instance.RemoveCoin(10);

                        // Heal the player when a quest is completed.
                        player.currentHealth = player.maxHealth;

                        // Give rewards to player.
                        player.currentExperience += quest.experienceReward;
                        Inventory.instance.AddCoin(quest.goldReward);

                        // Complete the quest
                        quest.isCompleted = true;
                        OnQuestCompleted();
                    }
                }
            } 
            else if (quest.isCompleted == true)
            {
                // Replace Debug.Log with proper UI
                Debug.Log("Merci d'avoir terminé cette quête.");
            }
        }

        if (quest.isActive == false && Input.GetKeyDown(KeyCode.A) && questWindow.activeSelf == true)
        {
            OnAcceptQuest();
        }
    }

    public void OpenQuestWindow()
    {
        // Display the quest UI.
        // And add all the information to the UI.
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();

        // Replace interactionUI (E) with acceptQuestUI (A)
        interactionUI.enabled = false;
        acceptUI.enabled = true;

    }

    public void OnAcceptQuest()
    {
        // Close the Quest UI.
        questWindow.SetActive(false);

        // This quest is now active for this player.
        quest.isActive = true;

        // Add this new quest to our Player's quests.
        player.quests.Add(quest);
    }

    public void OnDeclineQuest()
    {
        // Close the Quest UI.
        questWindow.SetActive(false);
        acceptUI.enabled = true;
    }

    public void OnQuestCompleted()
    {
        // Remove the quest from current active Quests
        // And add it to the Completed Quests list.
        player.quests.Remove(quest);
        player.completedQuests.Add(quest);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            interactionUI.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionUI.enabled = false;
            questWindow.SetActive(false);
            acceptUI.enabled = false;
        }   
    }
}
