using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDestroy;
    [SerializeField] private float _timeToDestroy;

    public void DestroySomeObject()
    {
        Destroy(_objectToDestroy, _timeToDestroy);
    }
}
