using System.Collections;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private Transform[] bulletPoints;
    [SerializeField] private Animator[] bulletPointAnim;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float frequency;
    private static readonly int Shoot1 = Animator.StringToHash("Shoot");
    private bool shooting;


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
}
