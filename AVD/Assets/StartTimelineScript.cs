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
