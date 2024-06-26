using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;

    [SerializeField] private SpriteRenderer[] healthIcons;

    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                healthIcons[i].sprite = fullHeart;
            }
            else
            {
                healthIcons[i].sprite = emptyHeart;
            }
        }
    }

    private void Die()
    {
        ScoreManager.Instance.ResetScore();

        FindObjectOfType<PauseMenu>().RestartLevel();
    }

}
