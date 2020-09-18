using UnityEngine;

public class Health : Destructable
{
    [SerializeField] private float inSeconds;

    public override void Die()
    {
        base.Die();
        GameManager.Instance.Respawner.Despawn(gameObject, inSeconds);
    }

    private void OnEnable()
    {
        Reset();
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        Debug.Log($"Remaining : {HitPointsRemaining}");
    }
}