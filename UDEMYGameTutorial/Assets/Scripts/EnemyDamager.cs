using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public int damageAmount;
    public float liftTime, growSpeed = 5f;

    private Vector3 targetSize;
    // Start is called before the first frame update
    void Start()
    {
        
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growSpeed * Time.deltaTime);

        liftTime -= Time.deltaTime;

        if (liftTime < 0)
        {
            targetSize = Vector3.zero;
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(damageAmount); 
        }

        if (other.tag == "boss")
        {
            other.GetComponent<Boss>().TakeDamage(damageAmount);
        }
    }
}