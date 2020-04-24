using System.Runtime.CompilerServices;
using CreatorKitCode;
using CreatorKitCodeInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class ChestScript : MonoBehaviour
{
    private PlayableDirector pd;
    private bool opened;
    public Transform openingPosition;
    private GameObject player;
    private void Awake()
    {
        pd = transform.GetChild(0).GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (pd.state != PlayState.Playing && opened)
        {
            player.transform.parent = null;
            player.GetComponent<CharacterControl>().weaponOnHand.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && !opened)
        {
            opened = true;
            player = other.gameObject;
            player.GetComponent<NavMeshAgent>().destination = openingPosition.position;
            player.GetComponent<CharacterControl>().weaponOnHand.GetComponent<MeshRenderer>().enabled = false;    
            player.transform.parent = gameObject.transform;
            var rotationVector = other.transform.localRotation.eulerAngles;
            rotationVector.y = 90f;
            player.transform.localRotation = Quaternion.Euler(rotationVector);
            pd.Play();
        }
    }
}
