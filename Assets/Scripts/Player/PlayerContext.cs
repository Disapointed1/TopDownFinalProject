using UnityEngine;

public class PlayerContext
{

    public Transform PlayerTransform{get; set;}
    public PlayerHealth PlayerHealth{get; set;}

    public PlayerContext(Transform playerTransform,  PlayerHealth playerHealth)
    {
        PlayerTransform = playerTransform;
        PlayerHealth = playerHealth;
    }
}
