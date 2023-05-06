using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        offset = mainCamera.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, target.position + offset, Time.deltaTime * 5);
        
    }
}
