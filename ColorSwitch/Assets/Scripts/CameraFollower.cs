using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y>transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
       
    }
}
