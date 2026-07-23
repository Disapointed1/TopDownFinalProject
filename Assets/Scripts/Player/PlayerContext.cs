using UnityEngine;

public class PlayerContext
{

    public Transform PlayerTransform{get; private set;}
    public PlayerHealth PlayerHealth{get; private set;}

    public PlayerContext(Transform playerTransform,  PlayerHealth playerHealth)
    {
        PlayerTransform = playerTransform;
        PlayerHealth = playerHealth;
    }
}
