using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraMovement : MonoBehaviour
{
    private Transform _camera;
    public float speed = 20;
    public Vector3 initialPosition;
    private Vector3 _deltaPos;
    private Vector3 _rot;

    void Awake()
    {
        _camera = transform;
        //_camera.position = initialPosition;
        _rot = _camera.rotation.eulerAngles;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        UpdateCamera();
    }
    private void UpdateCamera()
    {
        float rotY = Input.GetAxisRaw("Mouse Y");
        float rotX = Input.GetAxisRaw("Mouse X");
        _rot += new Vector3(-rotY, rotX, 0);
        _camera.rotation = Quaternion.Euler(_rot);
        var rotNormalized = Quaternion.Euler(_rot).normalized;
        Vector3 moveForward = new Vector3(rotNormalized.x, 0f, rotNormalized.y) * Input.GetAxis("Vertical");
        //Vector3 moveRight = Input.GetAxis("Horizontal") * _rot.normalized;
        Debug.Log(moveForward);
        Vector3 move = moveForward * speed;
        _camera.position += move;
    }
}
