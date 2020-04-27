using System;
using CreatorKitCode;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossFightTrigger : MonoBehaviour
{
    private PlayableDirector pd;
    public PlayableAsset endingAsset;
    private bool activated;
    public GameObject boss;
    void Awake()
    {
        pd = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if(boss.GetComponent<SimpleEnemyController>() == null)
        {
            pd.playableAsset = endingAsset;
            pd.Play();
            enabled = false;
        }
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
