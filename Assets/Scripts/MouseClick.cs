using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    private LayerMask           layerUnit;

    [SerializeField]
    private LayerMask           layerGround;

    [SerializeField]
    private GameObject          targetMarker;

    private Camera              mainCamera;
    private RTSUnitController   rTSUnitController;

    private void Awake() {
        rTSUnitController   = GetComponent<RTSUnitController>();
        mainCamera          = Camera.main;          
    }

    private void Update() {

        // 마우스 왼쪽 클릭으로 유닛 선택, 해제
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray     = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit))
            {   
                // 마우스 클릭 했을 때, 유닛이 있으면
                if (hit.transform.GetComponent<UnitController>() == null)
                return;

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    rTSUnitController.CtrlClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }

                else
                {
                    rTSUnitController.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }
            }

            else
            {   // 마우스 클릭 했을 때, 유닛이 없으면
                if (!Input.GetKey(KeyCode.LeftControl)) // 컨트롤을 누르지 않았으면
                {
                    rTSUnitController.DeSelectAll();    // 전부 선택 해제
                }
            }
        }

        // 마우스 오른쪽 클릭으로 유닛 이동
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray     = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {   
                rTSUnitController.MoveSelectedUnit(hit.point);
            }
        }
    }
}
