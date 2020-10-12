using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] public GameObject CubePrefab;
    [SerializeField] public Material CubeMaterial;

    private GameObject Cube;

    private void Awake()
    {
        
        // Loads saved cube
        if (PlayerPrefs.GetInt("isSpawned", 1) == 1)
        {
            Instantiate(CubePrefab);
            Cube = GameObject.Find("Cube(Clone)");
            CubeMaterial.color = Color.grey;

            Cube.transform.position = new Vector3(
                PlayerPrefs.GetFloat("positionX", 0),
                PlayerPrefs.GetFloat("positionY", 0),
                PlayerPrefs.GetFloat("positionZ", 0)
            );

            var rotation = Quaternion.Euler(
                PlayerPrefs.GetFloat("rotationX", 0),
                PlayerPrefs.GetFloat("rotationY", 0),
                PlayerPrefs.GetFloat("rotationZ", 0)
            );
            Cube.transform.localRotation = rotation;

            Cube.transform.localScale = new Vector3(
                PlayerPrefs.GetFloat("scaleX", 1),
                PlayerPrefs.GetFloat("scaleY", 1),
                PlayerPrefs.GetFloat("scaleZ", 1)
            );

            CubeMaterial.color = new Color(
                PlayerPrefs.GetFloat("colorRed", 0.5f),
                PlayerPrefs.GetFloat("colorGreen", 0.5f),
                PlayerPrefs.GetFloat("colorBlue", 0.5f)
            );
        }
    }

    void Update()
    {

        // Build
        if (Input.GetKeyDown(KeyCode.B) && PlayerPrefs.GetInt("isSpawned", 1) == 0)
        {

            Instantiate(CubePrefab);
            Cube = GameObject.Find("Cube(Clone)");
            CubeMaterial.color = Color.grey;
            PlayerPrefs.SetInt("isSpawned", 1);

            PlayerPrefs.SetFloat("positionX", Cube.transform.position.x);
            PlayerPrefs.SetFloat("positionY", Cube.transform.position.y);
            PlayerPrefs.SetFloat("positionZ", Cube.transform.position.z);

            PlayerPrefs.SetFloat("rotationX", 0);
            PlayerPrefs.SetFloat("rotationY", 0);
            PlayerPrefs.SetFloat("rotationZ", 0);

            PlayerPrefs.SetFloat("scaleX", Cube.transform.localScale.x);
            PlayerPrefs.SetFloat("scaleY", Cube.transform.localScale.y);
            PlayerPrefs.SetFloat("scaleZ", Cube.transform.localScale.z);

            PlayerPrefs.SetFloat("colorRed", CubeMaterial.color.r);
            PlayerPrefs.SetFloat("colorGreen", CubeMaterial.color.g);
            PlayerPrefs.SetFloat("colorBlue", CubeMaterial.color.b);

        }

        else if (PlayerPrefs.GetInt("isSpawned", 1) == 1)
        {
            
            // Position
            if (Input.GetKeyDown(KeyCode.P))
            {
                Cube.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                PlayerPrefs.SetFloat("positionX", Cube.transform.position.x);
                PlayerPrefs.SetFloat("positionY", Cube.transform.position.y);
                PlayerPrefs.SetFloat("positionZ", Cube.transform.position.z);
            }
            // Rotation
            else if (Input.GetKeyDown(KeyCode.R))
            {

                PlayerPrefs.SetFloat("rotationX", Random.Range(-360, 360));
                PlayerPrefs.SetFloat("rotationY", Random.Range(-360, 360));
                PlayerPrefs.SetFloat("rotationZ", Random.Range(-360, 360));

                var rotation = Quaternion.Euler(
                    PlayerPrefs.GetFloat("rotationX", 0),
                    PlayerPrefs.GetFloat("rotationY", 0),
                    PlayerPrefs.GetFloat("rotationZ", 0)
                );

                Cube.transform.localRotation = rotation;
            }
            // Scale
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Cube.transform.localScale = new Vector3(Random.Range(0.1f, 10), Random.Range(0.1f, 10), Random.Range(0.1f, 10));
                PlayerPrefs.SetFloat("scaleX", Cube.transform.localScale.x);
                PlayerPrefs.SetFloat("scaleY", Cube.transform.localScale.y);
                PlayerPrefs.SetFloat("scaleZ", Cube.transform.localScale.z);
            }
            // Color
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CubeMaterial.color = new Color(Random.Range(0.1f, 1), Random.Range(0.1f, 1), Random.Range(0.1f, 1));
                PlayerPrefs.SetFloat("colorRed", CubeMaterial.color.r);
                PlayerPrefs.SetFloat("colorGreen", CubeMaterial.color.g);
                PlayerPrefs.SetFloat("colorBlue", CubeMaterial.color.b);
            }
            // Destroy
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Destroy(Cube);
                PlayerPrefs.SetInt("isSpawned", 0);
            }

        }







    }
}
