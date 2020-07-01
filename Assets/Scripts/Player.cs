using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region {Player Characteristics}
    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 50; 
    public int currentMana;  

    public int currentExperience; 
    public int experienceToNextLevel;
    
    public int attack;
    public int defense;

    public List<Quest> quests;
    public List<Quest> completedQuests;
    #endregion

    public static Player instance;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of Player in the scene.");
            return;
        }
        instance = this;
    }

}
