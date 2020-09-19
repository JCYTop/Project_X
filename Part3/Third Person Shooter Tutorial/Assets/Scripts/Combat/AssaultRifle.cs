using Shared;

public class AssaultRifle : Shooter
{
    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
        }
    }

    public void Update()
    {
        if (GameManager.Instance.InputController.Reload)
        {
            Reload();
        }
    }
}