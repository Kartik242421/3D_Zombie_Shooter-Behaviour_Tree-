using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");

        // Start a coroutine to destroy the object after 1 second.
        StartCoroutine(DestroyAfterDelay(1f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Destroy the enemy object after the delay.
        Destroy(gameObject);
    }
}
