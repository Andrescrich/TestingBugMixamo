using System;
using System.Collections;
using UnityEngine;
using Math = UnityEngine.ProBuilder.Math;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform[] bulletPoints;
    [SerializeField] private Animator[] bulletPointAnim;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float frequency;
    private static readonly int Shoot1 = Animator.StringToHash("Shoot");
    private static readonly int Destroy1 = Animator.StringToHash("Destroy");
    private Animator anim;
    private bool shooting;
    public GameObject topTurret;
    private GameObject target;


    public static TurretScript Instance { get; private set; }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }

    private void Start()
    {
        Invoke(nameof(Destroy), 5);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
            Destroy();
    }

    public void Shooting()
    {
        if (shooting) return;
        StartCoroutine(ShootCor());
        shooting = true;
    }

    private int i;

    private IEnumerator ShootCor()
    {
        if (i >= bulletPoints.Length)
            i = 0;
        topTurret.transform.LookAt(target.transform.position);
        Shoot(bulletPoints[i].transform);
        bulletPointAnim[i].SetTrigger(Shoot1);
        yield return new WaitForSeconds(frequency);
        i++;
        StartCoroutine(ShootCor());
    }

    private void Shoot(Transform point)
    {
        Instantiate(bullet, point.position, point.rotation);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Destroy()
    {
        anim.SetTrigger(Destroy1);
        StopAllCoroutines();
    }

    public void Dissapear()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            target = other.gameObject;
            Shooting();
        }

    }
}
