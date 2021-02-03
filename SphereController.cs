using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SphereController : MonoBehaviour
{
    public List<GameObject> SphereList = new List<GameObject>();
    public Transform sphere;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Despawn();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            FindBlueSpheres();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            FindRedSpheres();
        }
    }

    public void Spawn()
    {
        SphereList.Add(Instantiate(sphere.gameObject, new Vector3(Random.Range(-4.0f, 4.0f), 2, Random.Range(-4.0f, 4.0f)), Quaternion.identity));
    }

    public void Despawn()
    {
        foreach(GameObject sphere in SphereList)
        {
            Destroy(sphere);
        }

        SphereList.Clear();
    }

    public void ChangeColor()
    {
        foreach (GameObject sphere in SphereList)
        {
            sphere.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

    public void FindBlueSpheres()
    {
        var found = SphereList.Find(x => x.GetComponent<Renderer>().material.color.b >= 0.50);
        Destroy(found);
        SphereList.Remove(found);
    }

    public void FindRedSpheres()
    {
        var redSpheresList = SphereList.FindAll(
            delegate (GameObject g)
            {
                return g.GetComponent<Renderer>().material.color.r >= 0.65;
            });

        foreach(GameObject sphere in redSpheresList)
        {
            SphereList.Remove(sphere);
            Destroy(sphere);
        }

        redSpheresList.Clear();
    }
}
