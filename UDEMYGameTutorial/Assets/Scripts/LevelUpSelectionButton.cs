using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText, nameLevelText;
    public Image weaponIcon;

    private WeaponBase assignedWeapon;

    public void UpdateButtonDisplay(WeaponBase theWeapon)
    {
        if (theWeapon.gameObject.activeSelf == true)
        {
            upgradeDescText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;

            nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel;
        } else
        {
            upgradeDescText.text = "Unlock " + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;

            nameLevelText.text = theWeapon.name;
        }

        assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if (assignedWeapon != null)
        {
            if (assignedWeapon.gameObject.activeSelf == true)
            {
                assignedWeapon.LevelUp();
            } else
            {
                Player.Instance.AddWeapon(assignedWeapon);
            }

            UIController.Instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
