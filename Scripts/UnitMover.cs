using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{   
    public float speed;
    public CharacterController controller;
    public Vector3 movePoint;
    public Camera mainCamera;

    private void Awake() {
        speed = 800f;
        mainCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        MouseClickMove();
        Move();
    }

    private void FocusOn()
    {
        
    }
    private void MouseClickMove()
    {
        if(Input.GetMouseButtonUp(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                movePoint = raycastHit.point;
            }
        }

        if(Vector3.Distance(transform.position, movePoint) >0.1f)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 updateMovePoint = (movePoint - transform.position).normalized * speed * Time.deltaTime;
        controller.SimpleMove(updateMovePoint);
    }
}
