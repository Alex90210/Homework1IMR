using UnityEngine;
using Vuforia;

public class CactusController : MonoBehaviour
{
    public float attackDistance = 0.25f; // Distance to trigger attack
    public string targetTag = "Cactus"; // Tag for other cactus characters

    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject[] cacti = GameObject.FindGameObjectsWithTag(targetTag);

        bool shouldAttack = false;

        foreach (GameObject other in cacti)
        {
            if (other != gameObject) // Don't check distance to self
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= attackDistance)
                {
                    shouldAttack = true;
                    break;
                }
            }
        }

        if (shouldAttack != isAttacking)
        {
            isAttacking = shouldAttack;
            animator.SetBool("IsAttacking", isAttacking);
        }
    }
}