using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    [SerializeField] private float limit = 40;
    [SerializeField] private float speed = 1;




    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
