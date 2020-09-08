using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;

    public int startingArmor;
    public int currentArmor;
    public int armorDamage = 5;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public GameObject player;
    public Transform SpawnPoint;

    PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        currentHealth = startingHealth;

        currentArmor = startingArmor;

        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");

        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (flashCounter > 0)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        playerUI.healthAmount.text = currentHealth.ToString();
        playerUI.armorAmount.text = currentArmor.ToString();
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.red);        
    }

    void SetStats()
    {
        playerUI.healthAmount.text = currentHealth.ToString();
        playerUI.armorAmount.text = currentArmor.ToString();
    }
}