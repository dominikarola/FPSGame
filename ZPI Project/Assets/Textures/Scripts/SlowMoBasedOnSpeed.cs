using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoBasedOnSpeed : MonoBehaviour
{
    public float normalTimeForPlayerMovingWithSpeed = 100;

    private Rigidbody rb = null;

    private bool m_SlowMo;

    public float aTime = 1;
    public float incerentTime = 0.1f;
    public float minTimeSpeed = 0.1f;
    public float maxTimeSpeed = 1.0f;


    void Start()
    {
        Time.timeScale = aTime;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!Pause.IsPaused)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
               if (aTime <= maxTimeSpeed)
                {
                    aTime += incerentTime * Time.deltaTime; 
                    aTime = Mathf.Min(aTime, maxTimeSpeed);
                }
            }
            else
            {
                if (aTime >= minTimeSpeed)
                {
                    aTime -= incerentTime * Time.deltaTime;
                    aTime = Mathf.Max(aTime, minTimeSpeed);
                }
            }

            Time.timeScale = aTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
