using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] public GameObject CubePrefab;
    [SerializeField] public Material CubeMaterial;

    private GameObject Cube;
    private bool spawned = false;


    //
    void Update()
    {


        // Build
        if (!spawned && Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(CubePrefab);
            Cube = GameObject.Find("Cube(Clone)");
            spawned = true;
        }
        else if (spawned)
        {
            
            // Position
            if (Input.GetKeyDown(KeyCode.P))
            {
                Cube.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            }
            // Rotation
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Cube.transform.Rotate(new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360)));
            }
            // Scale
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Cube.transform.localScale = new Vector3(Random.Range(0.1f, 10), Random.Range(0.1f, 10), Random.Range(0.1f, 10));
            }
            // Color
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CubeMaterial.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
            }
            // Destroy
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Destroy(Cube);
                spawned = false;
            }

        }







    }
}
