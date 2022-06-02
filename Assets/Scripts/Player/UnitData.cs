using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData.asset", menuName = "Unit / UnitData")]
public class UnitData : ScriptableObject
{
[Header("Unit Cost")]
public float upCost;
public float sellCost;


[Header("Unit Spec")]
public float attDamage;
public float attRange = 15;
public float attSpeed;


[Header("Appearance")]
public UnitController prefab;

}
