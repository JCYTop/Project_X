using System;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private float hitPoints;
    public event Action OnDeath;
    public event Action OnDamageReceived;
    private float damageTaken;

    public float HitPointsRemaining
    {
        get { return hitPoints - damageTaken; }
    }

    public bool IsAlive
    {
        get { return HitPointsRemaining > 0; }
    }

    public virtual void Die()
    {
        if (!IsAlive)
            return;
        if (OnDeath != null)
            OnDeath();
    }

    public virtual void TakeDamage(float amount)
    {
        damageTaken += amount;
        if (OnDamageReceived != null)
            OnDamageReceived();
        if (HitPointsRemaining <= 0)
        {
            Die();
        }
    }

    public void Reset()
    {
        damageTaken = 0;
    }
}