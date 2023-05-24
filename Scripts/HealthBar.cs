using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player_Controller player;
    public float currentHealth;
    public float maxHealth;
    public Scrollbar healthBar;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player_Controller>();
    }
    void Update()
    {
        currentHealth = player.Health;
        healthBar.size = currentHealth / maxHealth;
    }
}
