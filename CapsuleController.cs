using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CapsuleController : MonoBehaviour
{

    public List<GameObject> CapsuleList = new List<GameObject>();
    public Transform capsule;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        CapsuleList.Add(Instantiate(capsule.gameObject, new Vector3(Random.Range(-4.0f, 4.0f), 2, Random.Range(-4.0f, 4.0f)), Quaternion.identity));
    }
}
