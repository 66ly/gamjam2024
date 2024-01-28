using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public LevelUpSelectionButton[] levelUpSelectionButtons;
    public GameObject levelUpPanel;

    public Slider experienceSlider;
    public TMP_Text experienceText;
    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        experienceSlider.maxValue = levelExp;
        experienceSlider.value = currentExp;
        experienceText.text = "LEVEL: " + currentLvl;
    }
}