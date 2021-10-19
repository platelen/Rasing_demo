using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityStandardAssets.Vehicles.Car;

public class Police : MonoBehaviour
{
    [SerializeField] float Radius;

    private GameObject _target;

    private CarAIControl _carAIControl;

    void Start()
    {
        _carAIControl = GetComponent<CarAIControl>();
    }

    void Update()
    {
        if(_target)
            return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);
        foreach (var VARIABLE in colliders)
        {
            if (VARIABLE.GetComponent<Player>())
            {
                _target = VARIABLE.gameObject;
                _carAIControl.SetTarget(_target.transform);
            }
        }
    }
}
