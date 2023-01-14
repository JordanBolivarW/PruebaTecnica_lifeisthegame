using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] SelectedAnimation Selection_;
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetInteger("selection", (int)Selection_.Selection);
    }

    public void newSelection(int animation)
    {
        Selection_.Selection = (SelectedAnimation.Animation_) animation;
    }
}
