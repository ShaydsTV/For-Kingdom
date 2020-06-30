using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsController : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvincible;
    public float invincibilityFlashDelay = 0.133f;
    public float invincibilityStopDelay = 1.5f;

    public SpriteRenderer spriteRenderer;

    public HealthBarController healthBar;

    public static PlayerStatsController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of PlayerStatsController in the scene.");
            return;
        }
        instance = this;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(StartInvincibility());
            StartCoroutine(StopInvincibility());
        }        
    }

    public void HealPlayer(int heal)
    {
        if ((currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
        } 
        else
        {
            currentHealth += heal;            
        }

        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        // Prevents Player to move while he is dead.
        PlayerController.instance.enabled = false;
        PlayerController.instance.animator.SetTrigger("Death");
        PlayerController.instance.rigidboby2D.bodyType = RigidbodyType2D.Kinematic;
        PlayerController.instance.rigidboby2D.velocity = Vector3.zero;
        PlayerController.instance.playerCollider.enabled = false;
        GameManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        // Prevents Player to move while he is dead.
        PlayerController.instance.enabled = true;
        PlayerController.instance.animator.SetTrigger("Respawn");
        PlayerController.instance.rigidboby2D.bodyType = RigidbodyType2D.Dynamic;
        PlayerController.instance.playerCollider.enabled = true;
        GameManager.instance.OnPlayerDeath();

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator StartInvincibility()
    {
        while (isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator StopInvincibility()
    {
        yield return new WaitForSeconds(invincibilityStopDelay);
        isInvincible = false;
    }
}
