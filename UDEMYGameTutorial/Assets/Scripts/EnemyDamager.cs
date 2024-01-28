using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;
    public float lifeTime, growSpeed = 5f;

    private Vector3 targetSize;

    public bool isImpact;
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

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
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
        Debug.Log("collllll=========");
        if (other.tag == "Enemy")
        {
            Debug.Log("enemy=========" + damageAmount);
            other.GetComponent<Enemy>().TakeDamage((int)damageAmount);
            if (isImpact)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "boss")
        {
            other.GetComponent<Boss>().TakeDamage((int)damageAmount);
        }
    }
}
