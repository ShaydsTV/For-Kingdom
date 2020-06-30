using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public Transform[] checkpoints;

    public int damageOnCollision = 20;

    public SpriteRenderer graphics;
    private Transform target;
    private int nextPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = checkpoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // If enemy is near (0.3f) next point
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            nextPoint = (nextPoint + 1) % checkpoints.Length;
            target = checkpoints[nextPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerStatsController playerStats = collision.transform.GetComponent<PlayerStatsController>();
            playerStats.TakeDamage(damageOnCollision);
        }
    }
}
