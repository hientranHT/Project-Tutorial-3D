using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public Transform playerObj;
    protected NavMeshAgent enemyMesh;
    public float range = 15.0f;
    private float distance;
    private Animator animator;
    public bool isConditrionWin;
    public GameObject winGameLog;
    //

    private const string PLAYER = "Player";
    private const string PROJECTILE = "Projectile(Clone)";
    //public GameObject projectile;

    // Start is called before the first frame update

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playerObj.transform.position);
        if (distance < range)
        {
            enemyMesh.SetDestination(playerObj.position);
            animator.SetTrigger("Walk");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == PROJECTILE)
        {
            Destroy(gameObject);
            Projectile projectile = collider.GetComponent<Projectile>();
            if(projectile)
            {
                projectile.OnDestroy();
            }

            if(isConditrionWin)
            {
                winGameLog.SetActive(true);
            }
        }

        if (collider.gameObject.name == PLAYER)
        {
            MenuController menuController = collider.GetComponent<MenuController>();
            if (menuController)
            {
                menuController.LoseGame();
            }
        }
    }

    //private float distance;
    //public GameObject player;
    //public float speed = 3.0f;
    //public float range = 15.0f;

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Lose");
    //}

    //private void FixedUpdate()
    //{
    //    distance = Vector3.Distance(transform.position, player.transform.position);
    //    Vector3 direction = transform.position - player.transform.position;
    //    if (distance < range)
    //    {
    //        direction.Normalize();
    //        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    //    }
    //}
}
