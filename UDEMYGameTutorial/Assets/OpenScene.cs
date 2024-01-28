using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenScene : MonoBehaviour
{
    public GameObject intro1, intro2;
    public GameObject sprite1, sprite2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transition1("Menu"));
    }


    IEnumerator Transition1(string sceneName)
    {
        sprite1.SetActive(true);
        intro1.SetActive(true);
        yield return new WaitForSeconds(2);

        intro1.SetActive(false);
        intro2.SetActive(true);

        yield return new WaitForSeconds(2);
        for (int i = 0; i < 10; i++)
        {
            sprite1.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            sprite1.SetActive(false);
            sprite2.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            sprite2.SetActive(false);
        }
        sprite1.SetActive(false);
        sprite2.SetActive(true);
        
        SceneManager.LoadScene(sceneName);
    }
}
