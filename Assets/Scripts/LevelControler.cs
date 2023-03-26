using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{

    [SerializeField] private List<GameObject> plates = new List<GameObject>();
    [SerializeField] private List<GameObject> doors = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < doors.Count; i += 6)
        {
            doors[Random.Range(i, i + 6)].AddComponent<Rigidbody>();
        }

        for (int i = 0; i < plates.Count; i += 3)
        {
            plates[Random.Range(i, i + 3)].GetComponent<Collider>().isTrigger = true;
        }
    }


}
