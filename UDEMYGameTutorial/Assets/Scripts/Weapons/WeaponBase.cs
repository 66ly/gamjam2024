using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    public List<WeaponStats> stats;
    public int weaponLevel;

    [HideInInspector]
    public bool statsUpdated;

    public Sprite icon;
    
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdated = true;

            if (weaponLevel >= stats.Count - 1)
            {
                Player.Instance.fullyLeveledWeapons.Add(this);
                Player.Instance.assignedWeapons.Remove(this);
            }
        }
    }

}


[System.Serializable]
public class WeaponStats
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText;
}
