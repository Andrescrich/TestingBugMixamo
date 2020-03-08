using UnityEngine;

public class GemScript : MonoBehaviour
{
    private Animator anim;
    private static readonly int Picked = Animator.StringToHash("Picked");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger(Picked);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
