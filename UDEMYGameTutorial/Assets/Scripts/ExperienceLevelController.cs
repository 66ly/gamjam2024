using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    public int currentExperience;
    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 12;

    public List<WeaponBase> weaponsToUpgrade;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while (expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.2f));
        }
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
        if (currentExperience >= expLevels[currentLevel])
        {
            LevelUp();
        }
        UIController.Instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);
    }

    public void SpawnExp(Vector3 position, int expValue)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValue;
    }

    void LevelUp()
    {
        currentExperience -= expLevels[currentLevel];
        currentLevel++;
        if (currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }

        UIController.Instance.levelUpPanel.SetActive(true);
        Time.timeScale = 0f;

        weaponsToUpgrade.Clear();
        List<WeaponBase> availableWeapons = new List<WeaponBase>();
        /*      UIController.Instance.levelUpSelectionButtons[0].UpdateButtonDisplay(assignedWeapons[0]);
                UIController.Instance.levelUpSelectionButtons[1].UpdateButtonDisplay(unassignedWeapons[0]);
                UIController.Instance.levelUpSelectionButtons[2].UpdateButtonDisplay(unassignedWeapons[1]);*/
        availableWeapons.AddRange(Player.Instance.assignedWeapons);

        if (availableWeapons.Count > 0)
        {
            int selected = Random.Range(0, availableWeapons.Count);
            weaponsToUpgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        if (Player.Instance.assignedWeapons.Count + Player.Instance.fullyLeveledWeapons.Count < Player.Instance.maxWeapons)
        {
            availableWeapons.AddRange(Player.Instance.unassignedWeapons);
        }

        for (int i = weaponsToUpgrade.Count; i < 3; i++)
        {
            if (availableWeapons.Count > 0)
            {
                int selected = Random.Range(0, availableWeapons.Count);
                weaponsToUpgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
        }

        for (int i = 0; i < weaponsToUpgrade.Count; i++)
        {
            UIController.Instance.levelUpSelectionButtons[i].UpdateButtonDisplay(weaponsToUpgrade[i]);
        }

        for (int i = 0; i < UIController.Instance.levelUpSelectionButtons.Length; i++)
        {
            if (i < weaponsToUpgrade.Count)
            {
                UIController.Instance.levelUpSelectionButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.Instance.levelUpSelectionButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
