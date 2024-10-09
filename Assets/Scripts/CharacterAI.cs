using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    public Animator animator;
    public float detectionRadius = 0.25f;
    public LayerMask characterLayer;

    void Update()
    {
        // Detect other characters within the specified radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, characterLayer);
        if (hitColliders.Length > 0)
        {
            // Trigger attack animation
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // Go back to idle if no characters are nearby
            animator.SetBool("isAttacking", false);
        }
    }
}
