
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnPlayerDamage;
    public event EventHandler OnPlayerDied;

    public float PlayerHealth = 100f;

    public void Awake()
    {
        Instance = this;
    }

    public void PlayerDamage()
    {
        PlayerHealth -= 1;
        OnPlayerDamage?.Invoke(this, EventArgs.Empty);

        if (PlayerHealth <= 0f)
        {
            OnPlayerDied?.Invoke(this, EventArgs.Empty);
        }
    }
}
