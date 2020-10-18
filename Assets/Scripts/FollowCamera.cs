using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //type transform to know the position of the target
    [SerializeField] private Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
