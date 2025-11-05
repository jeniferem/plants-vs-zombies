using UnityEngine;
using System.Collections;

public class BasePlant : MonoBehaviour
{
    [SerializeField]
    protected Health health;
    public Health Health => health;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Collider collider;
    protected Step currentstep;
    public Step CurrentStep
    {
        set { currentstep = value; }
    }
    protected bool isActive;
    public bool IsActive
    {
        set
        {
            isActive = value;
            collider.enabled = value;
        }
    }
    protected  IEnumerator DieRoutine (string dieAnimationName)
    {
        IsActive = false;
        animator.Play(dieAnimationName, 0, 0f);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
}
    

