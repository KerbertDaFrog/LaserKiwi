using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public GameObject pickupEffect;

    public int HealthAdd = 25;

    public int ArmorAdd = 25; 

    public int AmmoAdd = 50;

    public int multiplier = 10;

    public float timer = 30f;

    public bool powerupActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        if(pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }
        
        if(gameObject.tag == "Speed")
        {
            StartCoroutine("SpeedTime");
        }

        if(gameObject.tag == "Health")
        {
            player.GetComponent<PlayerHealthManager>().currentHealth += HealthAdd;
        }

        if(gameObject.tag == "Armor")
        {
            player.GetComponent<PlayerHealthManager>().currentArmor += ArmorAdd;
        }

        if (gameObject.tag == "Invincibility")
        {
            player.GetComponent<PlayerHealthManager>().enabled = false;
        }

        if (gameObject.tag == "Ammo")
        {
            player.GetComponent<GunController>().bulletAmount += AmmoAdd;
        }

        Destroy(gameObject);
    }

    void Speed(Collider player)
    {
        player.GetComponent<PlayerMovement>().moveSpeed *= multiplier;
    }

    IEnumerator SpeedTime (float duration)
    {
        Debug.Log("Power Up Activated");
        powerupActive = true;
        yield return new WaitForSeconds(duration);
        powerupActive = false;
        Debug.Log("Power Up Deactivated");
    }
}
