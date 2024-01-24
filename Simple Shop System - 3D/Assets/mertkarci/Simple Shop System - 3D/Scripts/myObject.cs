using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(fileName = "shopObject", menuName = "shopObjects")]
public class myObject : ScriptableObject
{
    public bool is3D;
    public string title;
    public int id;
    public bool isAvailable;
    public int price;
    public GameObject objectSelf3D;
    public bool isTaken;
    public Transform spawnPoint;


    private void OnEnable()
    {
        spawnPoint = GameObject.Find("spawnPoint").GetComponent<Transform>();
    }
    public myObject()
    {

        is3D = true;
    }
    public GameObject SpawnIt()
    {
        GameObject spawn;
        spawn = Instantiate(objectSelf3D, spawnPoint.position, Quaternion.identity);
        return spawn;
    }
}
