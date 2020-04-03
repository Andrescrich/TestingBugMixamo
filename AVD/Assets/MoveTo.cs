using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;

public class MoveTo : MonoBehaviour
{
    private RaycastHit hitInfo;
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject flag;
    public LayerMask lm;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, Mathf.Infinity, lm))
            {
                agent.destination = hitInfo.point;
                flag.GetComponentInChildren<MeshRenderer>().enabled = true;
                flag.transform.position = hitInfo.point + new Vector3(0f, 0.5f);
                flag.GetComponentInParent<Animator>().SetTrigger("set");
            }
        }
    }
}
