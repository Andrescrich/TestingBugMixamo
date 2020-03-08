using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;
    private static readonly int Death1 = Animator.StringToHash("Death");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger(Death1);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
