using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimator();
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            //   GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        // convert global velocity from NavMesh to local
        // this is going to power the Animator, so we'll want to localize it
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
