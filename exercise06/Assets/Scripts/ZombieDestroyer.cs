using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDestroyer : MonoBehaviour
{
    private ZombieController[] _zombies;

    public void DestroyZombies()
    {
        _zombies = GameObject.FindObjectsOfType<ZombieController>();
        foreach(var zombie in _zombies)
        {
            Destroy(zombie.gameObject);
        }
    }
}
