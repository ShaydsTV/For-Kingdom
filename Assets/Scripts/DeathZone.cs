using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStatsController.instance.TakeDamage(30);
            if (PlayerStatsController.instance.currentHealth > 0)
            {
                StartCoroutine(ReplacePlayer(collision));
            } 
            else
            {
                GameManager.instance.OnPlayerDeath();
            }
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
    }

}
