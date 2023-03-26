using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float force = 15;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector3 hitDir = contact.normal;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Force);
            }
        }
    }



}
