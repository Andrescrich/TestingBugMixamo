using UnityEngine;

public class ThrowTurret : MonoBehaviour
{
    public GameObject turretBallPoint;
    public GameObject turretBall;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            Instantiate(turretBall, turretBallPoint.transform.position, turretBallPoint.transform.rotation);
    }
}
