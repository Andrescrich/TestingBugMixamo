using System;
using UnityEngine;
using UnityEngine.Playables;

public class ChestScript : MonoBehaviour
{
    private PlayableDirector pd;
    private bool opened;
    private void Awake()
    {
        pd = transform.GetChild(0).GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && !opened)
        {
            opened = true;
            pd.Play();
        }
    }
}
