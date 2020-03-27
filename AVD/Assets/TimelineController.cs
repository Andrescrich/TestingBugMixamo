using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour {

    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelines;


    public void Play()
    {
        foreach (var playableDirector in playableDirectors) 
        {
            playableDirector.Play ();
        }
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        selectedAsset = timelines.Count <= index ? timelines [timelines.Count - 1] : timelines [index];

        playableDirectors [0].Play (selectedAsset);
    }
}