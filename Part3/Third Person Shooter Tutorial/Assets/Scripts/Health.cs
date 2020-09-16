using UnityEngine;

public class Health : Destructable
{
    public override void Die()
    {
        base.Die();
        Debug.Log("Die");
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        Debug.Log($"Remaining : {HitPointsRemaining}");
    }
}