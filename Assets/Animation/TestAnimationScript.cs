using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Play Action 1");


        //animator.SetFloat("WalkSpeed", 0.56f);
        //animator.SetInteger("WalkSpeed", 12);
        //animator.SetBool("WalkSpeed", false);
    }
}
