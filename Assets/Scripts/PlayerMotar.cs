
using UnityEngine;
using UnityEngine.AI;


 [RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotar : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

     void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            Facetarget();
            
        }
    }

    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget (Interacable newTarget)
    {
        target = newTarget.transform;
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
       
    }

    public void StopFollowingTarget ()
    {
        target = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    void Facetarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
