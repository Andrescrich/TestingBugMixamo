using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.Playables;

public class DisableMovementTimeline : MonoBehaviour
{
    private PlayableDirector pd;

    private void Awake()
    {
        pd = GetComponent<PlayableDirector>();
    }
    
    private void Update()
    {
        if (pd.state != PlayState.Playing)
            enabled = false;
        else
            CharacterControl.Instance.canClick = false;
    }

    private void OnDisable()
    {
        CharacterControl.Instance.canClick = true;
    }
}
