using UnityEngine;

public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Transform closestEnemy;

    [SerializeField] private float colorLoosingSpeed;
    private float cloneTimer;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = 0.8f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cloneTimer -= Time.deltaTime;
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));
            if (sr.color.a <= 0) Destroy(gameObject);
        }
    }

    public void SetupClone(Transform newTransform, float cloneDuration, bool canAttack)
    {
        if (canAttack) animator.SetInteger("AttackNumber", Random.Range(1, 3));

        transform.position = newTransform.position;
        cloneTimer = cloneDuration;

        FaceClosestTarget();
    }

    private void AnimationTrigger()
    {
        cloneTimer = -0.1f;
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>()) hit.GetComponent<Enemy>().Damage();
        }
    }

    private void FaceClosestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);
        float closestDistance = Mathf.Infinity;
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>())
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }

        if (closestEnemy)
        {
            if (transform.position.x > closestEnemy.position.x) transform.Rotate(0, 180, 0);
        }
    }
}
