using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public LevelUpSelectionButton[] levelUpSelectionButtons;
}
