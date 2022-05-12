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
public float damage;
public float range = 15;
public float attSpeed;


[Header("UI")]
public Unit prefab;

}
