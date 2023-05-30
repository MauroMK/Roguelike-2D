using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform cameraReference;
    [SerializeField] private Vector3 positionStrenght;
    [SerializeField] private Vector3 rotationStrenght;

    private static event Action Shake;

    public static void Invoke()
    {
        Shake?.Invoke();
    }

    private void OnEnable() 
    {
        Shake += CameraShake;
    }
    
    private void OnDisable() 
    {
        Shake -= CameraShake;
    }

    private void CameraShake()
    {
        cameraReference.DOComplete();
        cameraReference.DOShakePosition(0.2f, positionStrenght);
        cameraReference.DOShakePosition(0.2f, rotationStrenght);
    }
}
