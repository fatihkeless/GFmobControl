using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScript : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;
    Vector3 offset;
    public float smoothSpeed = 0.125f;
    Gamemanager _gameManager;
    public Vector3 newOofffset;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        offset = mainCamera.transform.position - target.position;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {

    }
}
