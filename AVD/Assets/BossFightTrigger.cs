using UnityEngine;
using UnityEngine.Playables;

public class BossFightTrigger : MonoBehaviour
{
    private PlayableDirector pd;
    private bool activated;
    void Awake()
    {
        pd = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && other.GetComponent<ThrowTurret>().enabled && !activated)
        {
            pd.Play();
            activated = true;
        }
    }
}
