using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float Health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        Health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        Health -= amount;

        healthBar.fillAmount = Health / startHealth;

        if (Health <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
//Ctrl + rr = Her yerdeki isimleri deðiþtirmek için kullan.