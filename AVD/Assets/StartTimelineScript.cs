using System;
using System.Collections;
using System.Collections.Generic;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimelineScript : MonoBehaviour
{
    private PlayableDirector pd;

    private void Awake()
    {
        pd = GetComponent<PlayableDirector>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (pd.state != PlayState.Playing)
            enabled = false;
        else
            CharacterControl.Instance.weaponOnHand.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnDisable()
    {
        CharacterControl.Instance.weaponOnHand.GetComponent<MeshRenderer>().enabled = true;
    }
}
