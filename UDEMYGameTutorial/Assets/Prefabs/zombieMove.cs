using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMove : MonoBehaviour
{
    public float wobbleAmount = 0.2f;
    public float wobbleSpeed = 2f;
    public float tiltAmount = 10f; // Maximum tilt angle in degrees

    private float wobblePhase;

    void Start()
    {
    }

    void Update()
    {
        // Wobbling and tilting the zombie
        wobblePhase += Time.deltaTime * wobbleSpeed;
        float tiltOffset = Mathf.Sin(wobblePhase) * tiltAmount;

        // Applying the tilt
        transform.rotation = Quaternion.Euler(0, 0, tiltOffset);

        // Optional: Destroy the zombie if it moves off-screen
        // if (transform.position.x > someThreshold)
        // {
        //     Destroy(gameObject);
        // }
    }
}