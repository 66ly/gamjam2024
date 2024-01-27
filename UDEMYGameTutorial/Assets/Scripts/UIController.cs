using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    public Slider experienceSlider;
    public TMP_Text experienceText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        experienceSlider.maxValue = levelExp;
        experienceSlider.value = currentExp;
        experienceText.text = "LEVEL: " + currentLvl;
    }
}
