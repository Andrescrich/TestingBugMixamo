using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;

public class StartEnemisScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    private PlayableDirector pd;
    public PlayableAsset playableAsset;

    private void Awake()
    {
        pd = GetComponentInParent<PlayableDirector>();
    }

    private void Update()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<SimpleEnemyController>() == null)
                enemies.Remove(enemy);
        }

        if (enemies.Count == 0)
        {
            Debug.Log("Muertos");
            pd.playableAsset = playableAsset;
            pd.Play();
            Destroy(this);
        }
    }
}
