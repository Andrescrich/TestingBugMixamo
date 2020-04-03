using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private MeshRenderer sr;

    private void Awake()
    {
        sr = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (Vector3.Distance(PlayerScript.Instance.transform.position, transform.position) < 1)
            sr.enabled = false;
    }
}
