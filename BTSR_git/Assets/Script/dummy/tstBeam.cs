using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tstBeam : MonoBehaviour
{
    public GameObject Raybody;
    public GameObject ScaleDistance;
    public GameObject RayResult;

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 200))
        {
            ScaleDistance.transform.localScale = new Vector3(1, 1, hit.distance);

            RayResult.transform.position = hit.point;
        }

        //RayResult.transform.rotation = Quaternion.LookRotation(hit.normal);
    }
}
