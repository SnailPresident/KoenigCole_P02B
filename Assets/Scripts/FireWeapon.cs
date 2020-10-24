using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    //fire weapon with raycast
    void Shoot()
    {
        //calculate direction
        Vector3 rayDirection = cameraController.transform.forward;
        //cast debug ray
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.red, 1f); ;
        //do raycast
        if(Physics.Raycast(rayOrigin.position,rayDirection, shootDistance))
        {
            Debug.Log("Hit!");
        }
        else
        {
            Debug.Log("Miss.");
        }
    }
}
