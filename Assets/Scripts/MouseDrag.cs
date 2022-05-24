﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField]
    private RectTransform       dragRectangle;          // 마우스로 드래그 한 범위 보여주는 이미지의 Transform

    private Rect                dragRect;               // 마우스 드래그 범위
    private Vector2             start = Vector2.zero;   // 드래그 시작 지점
    private Vector2             end = Vector2.zero;     // 드래그 종료 지점

    private Camera              mainCamera;
    private RTSUnitController   rTSUnitController;
    
    private void Awake() {
        mainCamera          = Camera.main;
        rTSUnitController   = GetComponent<RTSUnitController>();

        // start, end 가 (0, 0)인 상태로 이미지 크기를 (0, 0)으로 설정해 화면에 보이지 않게 함
        DrawDragRectangle();
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0))    
        {
            start = Input.mousePosition;
            dragRect = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition;

            // 마우스를 드래그 하는 동안 범위를 이미지로 표현
            DrawDragRectangle();
        }

        if (Input.GetMouseButtonUp(0))
        {
            // 마우스 드래그를 종료했을 때, 드래그 범위 내에 있는 유닛 선택
            CalculateDragRect();
            SelectUnits();

            // 마우스 드래그를 종료했을 때, 드래그 범위가 보이지 않게
            // start, end 위치를 (0, 0)으로 설정하고 드래그 범위 그리기
            start = end = Vector2.zero;
            DrawDragRectangle();
        }

    }
    private void DrawDragRectangle()
    {
          // 드래그 범위를 나타내는 이미지 UI의 위치
        dragRectangle.position = (start + end) * 0.5f;      

          // 드래그 범위를 나타내는 이미지 UI의 크기
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
    }

    private void CalculateDragRect()
    {
        if (Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }

        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }
        
        if (Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }

        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {   
        // 모든 유닛을 검사하여
        foreach (UnitController unit in rTSUnitController.unitList)
        {
            // 유닛의 월드 좌표를 화면 좌표로 변환, 드래그 범위 내에 있는지 검사
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)))
            {
                rTSUnitController.DragSelectUnit(unit);
            }
        }
    }
}
