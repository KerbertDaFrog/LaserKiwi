using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    public GameObject player;
    public Transform SpawnPoint;

    void Update()
    {
        if 
        {          
            StartCoroutine(PlayerDeath(5));
        }
    }

    IEnumerator PlayerDeath(float duration)
    {
        Destroy(player);
        yield return new WaitForSeconds(duration);
        Instantiate(player, SpawnPoint.position, SpawnPoint.rotation);
    }
}
