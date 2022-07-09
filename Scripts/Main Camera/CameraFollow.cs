using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothSpeed;

    [SerializeField]
    private Vector2 maxPosition;

    [SerializeField]
    private Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        //Return the clamped position of the camera to the target position
        //value = [min, max] or value
        targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        //Smoothly move the camera towards that target position
        //Vector3.Left(a, b, t) = a + (b - a) * t 
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
