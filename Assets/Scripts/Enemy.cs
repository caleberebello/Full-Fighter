using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject playerPrefab;

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0) {
            Die();
            winPanel.gameObject.SetActive(true);
            playerPrefab.gameObject.SetActive(false);
        }
        healthBar.SetHealth(currentHealth);
    }

    void Die(){
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
