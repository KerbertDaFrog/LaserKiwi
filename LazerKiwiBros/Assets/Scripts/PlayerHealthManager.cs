using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;

    public int startingArmor;
    public int currentArmor;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

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
            gameObject.SetActive(false);
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