
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent navMeshAgent;
    private Camera camera;
    private Animator animator;

    private void Start()
    {
         navMeshAgent = GetComponent<NavMeshAgent>();
         camera = Camera.main;
         animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimator();
    }

    void MoveToCursor()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        { 
            //TODO look at adding as a reference instead)
            //GetComponent<NavMeshAgent>().destination = hit.point;
            navMeshAgent.destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        // convert global velocity from NavMesh to local
        // this is going to power the Animator, so we'll want to localize it
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        //TODO look at adding as a reference instead
        animator.SetFloat("forwardSpeed", speed);
    }
}
