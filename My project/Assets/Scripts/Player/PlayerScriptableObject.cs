using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [Header("Base Stat")]
    public GameObject bullet;
    public float healthRegen;
    public int health;

    [Header("Shooting Stats")]
    public float shootInterval;
    public float shootForce;

    [Header("Movement Stats")]
    public float moveSpeed;
}
