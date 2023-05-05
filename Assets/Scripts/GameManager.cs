
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

        Debug.Log($"Health:{ PlayerHealth }");
        if (PlayerHealth <= 0f)
        {
            Debug.Log("MUERTE");
            OnPlayerDied?.Invoke(this, EventArgs.Empty);
        }
    }
}
