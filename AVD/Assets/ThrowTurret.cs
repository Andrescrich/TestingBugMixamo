using UnityEngine;

public class ThrowTurret : MonoBehaviour
{
    public GameObject turretBallPoint;
    public GameObject turretBall;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(turretBall, turretBallPoint.transform.position, turretBall.transform.rotation);
    }
}
