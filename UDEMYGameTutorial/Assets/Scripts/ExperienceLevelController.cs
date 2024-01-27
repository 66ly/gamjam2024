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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;
    }
}
