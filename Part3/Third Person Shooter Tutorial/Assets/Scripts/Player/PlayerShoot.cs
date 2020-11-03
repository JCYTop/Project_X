using System;
using Extend;
using Shared;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float weaponSwitchTime;
    private Shooter[] weapons;
    private Shooter activeWeapon;
    private int currentWeaponIndex;
    public Shooter ActiveWeapon => activeWeapon;
    private bool canFire;
    private Transform weaponHolster;
    public event Action<Shooter> OnWeaponSwitch;

    private void Start()
    {
        canFire = true;
        weaponHolster = transform.FindInChild("Weapons");
        weapons = weaponHolster.GetComponentsInChildren<Shooter>();
        if (weapons.Length > 0)
            Equip(0);
    }

    private void DeactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(false);
            weapons[i].transform.SetParent(weaponHolster);
        }
    }

    private void SwitchWeapon(int direction)
    {
        canFire = false;
        currentWeaponIndex += direction;
        if (currentWeaponIndex > weapons.Length - 1)
            currentWeaponIndex = 0;
        if (currentWeaponIndex < 0)
            currentWeaponIndex = weapons.Length - 1;
        GameManager.Instance.Timer.Add(() => { Equip(currentWeaponIndex); }, weaponSwitchTime);
    }

    private void Equip(int index)
    {
        DeactivateWeapons();
        canFire = true;
        activeWeapon = weapons[index];
        activeWeapon.Equip();
        weapons[index].gameObject.SetActive(true);
        if (OnWeaponSwitch != null)
            OnWeaponSwitch(activeWeapon);
    }

    private void Update()
    {
        if (GameManager.Instance.InputController.MouseWheelDown)
            SwitchWeapon(1);
        if (GameManager.Instance.InputController.MouseWheelUp)
            SwitchWeapon(-1);
        if (GameManager.Instance.LocalPlayer.PlayerState.MoveState == PlayerState.EMoveState.SPRINTING)
            return;
        if (!canFire)
            return;
        if (GameManager.Instance.InputController.Fire1)
        {
            activeWeapon.Fire();
        }
    }
}