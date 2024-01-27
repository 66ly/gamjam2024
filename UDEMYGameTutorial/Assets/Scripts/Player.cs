using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float speed;

    private Rigidbody2D rb;

    private Vector2 moveAmount;
    private Animator anim;

    public int health;

    public GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtAnim;

    private SceneTransition sceneTransitions;
    public GameObject hurtSound;

    public GameObject trail;
    private float timeBtwTrail;
    public float startTimeBtwTrail;
    public Transform groundPos;



    public List<WeaponBase> unassignedWeapons, assignedWeapons;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransitions = FindObjectOfType<SceneTransition>();

        AddWeapon(Random.Range(0, unassignedWeapons.Count));
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {

            if (timeBtwTrail <= 0)
            {
                Instantiate(trail, groundPos.position, Quaternion.identity);
                timeBtwTrail = startTimeBtwTrail;
            }
            else
            {
                timeBtwTrail -= Time.deltaTime;
            }
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        //TODO: Delete after experience
        if (Input.GetKeyDown(KeyCode.R))
        {
            UIController.Instance.levelUpPanel.SetActive(true);
            Time.timeScale = 0f;

            UIController.Instance.levelUpSelectionButtons[0].UpdateButtonDisplay(assignedWeapons[0]);
            UIController.Instance.levelUpSelectionButtons[1].UpdateButtonDisplay(unassignedWeapons[0]);
            UIController.Instance.levelUpSelectionButtons[2].UpdateButtonDisplay(unassignedWeapons[1]);

        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int amount)
    {
       Instantiate(hurtSound, transform.position, Quaternion.identity);
        health -= amount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(this.gameObject);
            sceneTransitions.LoadScene("Lose");
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip) {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth) {

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < currentHealth)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
            } else {
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
            }

        }

    }

    public void Heal(int healAmount) {
        if (health + healAmount > 5)
        {
            health = 5;
        } else {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

    public void AddWeapon(int weaponNumber)
    {
        if (weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }

    public void AddWeapon(WeaponBase weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);
        assignedWeapons.Add(weaponToAdd);
        unassignedWeapons.Remove(weaponToAdd);
    }

}
