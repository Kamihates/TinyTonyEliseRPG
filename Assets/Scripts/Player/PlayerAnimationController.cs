using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    

    public void Walk(bool isWalking)
    {
        _animator.SetBool("isWalking", isWalking);
    }

    public void Run(bool isRunning)
    {
        _animator.SetBool("isRunning", isRunning);
    }
}
