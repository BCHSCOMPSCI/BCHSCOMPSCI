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

        if (Input.GetKeyDown(KeyCode.R))
        {
            FindSmallScale();
        }
    }

    public void Spawn()
    {
        float capsuleScale = Random.Range(0.1f, 3.0f);
        CapsuleList.Add(Instantiate(capsule.gameObject, new Vector3(Random.Range(-4.0f, 4.0f), 2, Random.Range(-4.0f, 4.0f)), Quaternion.identity));
        capsule.transform.localScale = new Vector3(capsuleScale, capsuleScale, capsuleScale);
    }

    public void FindSmallScale()
    {
        var smallCapsuleList = CapsuleList.FindAll(
            delegate (GameObject g)
            {
                return g.GetComponent<Transform>().localScale.y < 1 && g.GetComponent<Transform>().localScale.x < 1 && g.GetComponent<Transform>().localScale.z < 1;
            });

        foreach(GameObject capsule in smallCapsuleList)
        {
            capsule.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
        }
    }
}