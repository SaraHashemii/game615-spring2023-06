using UnityEngine;
using UnityEngine.AI;

public class VampireController : MonoBehaviour
{
    private NavMeshAgent _agent;

    // A gameObject in scene displaying the target point of the agent
    public GameObject targetPoint;
    public GameObject minimapIcon;
    public LayerMask layerMask;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // When the left mouse button is hit...
        if(Input.GetMouseButtonDown(0))
        {
            // ...find the point that was clicked and...
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out hit, 100, layerMask);

            //  ... if something has been hit ...
            if(hasHit)
            {
                // ... set the destination for this agent
                _agent.destination = hit.point;
                targetPoint.transform.position = hit.point;
            }
        }

        //make the icon move along the player, but not rotate like a child gameobject of the player
        minimapIcon.transform.position = new Vector3(transform.position.x, minimapIcon.transform.position.y, transform.position.z);
    }
}
