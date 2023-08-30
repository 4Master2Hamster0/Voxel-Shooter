using UnityEngine.Events;

public static class WeaponEvent
{
    public static UnityEvent OnWeaponSwitch = new UnityEvent();
    public static UnityEvent OnShoot = new UnityEvent();
}