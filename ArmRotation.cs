using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public float offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize(); //normalizing the vector, the sum of vector will be equal to 1

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; //the angle of the vector

        transform.rotation = Quaternion.Euler(0f,0f, rotZ + offset);
    }
}
