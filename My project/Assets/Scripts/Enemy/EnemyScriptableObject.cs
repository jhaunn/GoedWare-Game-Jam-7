using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Base Stats")]
    public Color color;
    public int life;
    public int scoreMin;
    public int scoreMax;

    [Header("Shooting Stats")]
    public GameObject[] bullets;
    public float shootInterval;
    public float shootForce;

    [Header("Movement Stats")]
    public float spinSpeed;
    public float moveSpeed;
    public float moveInterval;

    public int GetScore()
    {
        return Random.Range(scoreMin, scoreMax + 1);
    }
}
