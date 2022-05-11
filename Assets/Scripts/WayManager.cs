using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayManager : MonoBehaviour
{
   public static WayManager instance { get; private set;}
   
   public Transform wayPointParent;
   public Transform[] wayPoints;
   
   private void Awake() {
       instance = this;
    
        GetWayPoints();
   }

   private void GetWayPoints()
   {
       wayPoints = new Transform[wayPointParent.childCount];
       for(int i = 0; i < wayPoints.Length; i++)
       {
           wayPoints[i] = wayPointParent.GetChild(i);
       }
   }
}
