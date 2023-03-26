using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private Vector3 direction;

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Force);
    }
}
