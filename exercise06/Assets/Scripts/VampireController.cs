using UnityEngine;
using UnityEngine.AI;

public class VampireController : MonoBehaviour
{
    public Brain brains1;
    public Brain brains2;
    public Brain brains3;
    public Brain brains4;


    private NavMeshAgent _agent;
    public GameObject targetPoint;
    public GameObject minimapIcon;
    public GameObject brainPrefab;
    public LayerMask layerMask;
   
    public bool _eatBrain;
    ScoreManager SM;
    public GameObject particleEffect;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        SM = GameObject.Find("Canvas").GetComponent<ScoreManager>();



      }

    void Update()
    {
        // When the left mouse button is hit...
        if (Input.GetMouseButtonDown(0))
        {
            // ...find the point that was clicked and...
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out hit, 100, layerMask);

            //  ... if something has been hit ...
            if (hasHit)
            {
                // ... set the destination for this agent
                _agent.destination = hit.point;
                targetPoint.transform.position = hit.point;
            }
        }

        //make the icon move along the player, but not rotate like a child gameobject of the player
        minimapIcon.transform.position = new Vector3(transform.position.x, minimapIcon.transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            
            SM.AddPointToPlayer();
            particleEffect.SetActive(true);
            Instantiate(particleEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            particleEffect.SetActive(false);

           // brains1.StartCoroutine(SpawnOneBrain());
            //call the spawner
            
           
        }
    }
}
