using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private void OnEnable()
    {
        _enemy = GetComponent<GameObject>();
    }
}
