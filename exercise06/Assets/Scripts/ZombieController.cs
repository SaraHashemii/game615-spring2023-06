using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using System.Collections;
public class ZombieController : MonoBehaviour
{
    private NavMeshAgent _agent;
    GameObject _brainInScene;
    public GameObject brainPrefab; 
    private GameObject _destination;
    public float smellSense = 6;
    public ParticleSystem onCollectParticle;
    private GameObject[] _destinations;
    [SerializeField] private bool _isSeeking;
    public GameObject minimapIcon;
    GameObject ownMinimap; 
    GameObject zombie;
    GameObject grave; 
    ScoreManager SM;
    public bool _asleep; 

    void SetNextDestination()
    {
        int index = Random.Range(0, _destinations.Length);
        _destination = _destinations[index];
        _agent.destination = _destination.transform.position;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _brainInScene = GameObject.FindGameObjectWithTag("Collectable");
        _destinations = GameObject.FindGameObjectsWithTag("Destination");
        SM = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        ownMinimap = Instantiate(minimapIcon, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(90, 0, 0)); 
        zombie = transform.GetChild(1).gameObject;
        grave = transform.GetChild(0).gameObject;
        SetNextDestination();
    }

    private void Update()
    {
        //Generates Errors --> enemy doesnt collect the brain however when the player try to collect it, the error says  The object of type 'GameObject' has been destroyed but you are still trying to access it.
        //var distanceToBrain = Vector3.Distance(transform.position, _brainInScene.transform.position);

        //var distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        // If the brain is within range ...
        //if (distanceToBrain < smellSense)
        //{
        //    // ... move toward the brain, updating the destination each frame
        //    _agent.destination = _brainInScene.transform.position;
        //    _isSeeking = true;
        //}
        //else
        //{
        //    _isSeeking = false;

        //    var distanceToDestination = Vector3.Distance(transform.position, _destination.transform.position);
        //    if (distanceToDestination < .5f)
        //    {
        //        SetNextDestination();
        //    }
        //}

        ownMinimap.transform.position = new Vector3(transform.position.x, minimapIcon.transform.position.y, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        // Depending on the status, change the handles color
        if(_isSeeking)
        {
            Handles.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        }
        else
        {
            Handles.color = new Color(0f, 1f, 0f, 0.1f);
            Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        }
        // Draw a disc displaying the smell sense range for the zombie
        Handles.DrawSolidDisc(transform.position,Vector3.up, smellSense);
        
        Gizmos.DrawSphere(transform.position, smellSense);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Instantiate(brainPrefab, transform.position, Quaternion.identity);
            SM.AddPointToEnemy();
            //Instantiate(onCollectParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject, 0.25f); 
            zombie.SetActive(false);
            _asleep = true;
            grave.SetActive(true);
            _agent.speed = 0;

            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(30);
        _asleep = false; 
        grave.SetActive(false);
        zombie.SetActive(true);
        _agent.speed = 2;
    }
}
