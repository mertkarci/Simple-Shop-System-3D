using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool rotateLeft = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationDirection = rotateLeft ? 1f : -1f;
        Rotate(gameObject.transform, rotationSpeed * rotationDirection);
    }

    void Rotate(Transform rotatingObject, float speed)
    {
        rotatingObject.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
