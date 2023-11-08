using UnityEngine;

class RangedAI : MonoBehaviour, IAction
{
    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttack = 1f;
    [SerializeField] float weaponDamage = 5f;

    float timeSinceLastAttack = Mathf.Infinity;
    
    Health target;

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if (target == null) return;

        if (target.IsDead()) return;

        if (GetIsInRange())
        {
            AttackBehaviour();
        }
    }

    private void AttackBehaviour()
    {
        if (timeSinceLastAttack > timeBetweenAttack)
        {
            // Trigger spawn projectile event

            timeSinceLastAttack = 0;
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
    }

    public bool CanAttack(GameObject combatTarget)
    {
        if (combatTarget == null) return false;
        Health targetToTest = combatTarget.GetComponent<Health>();
        return targetToTest != null && !targetToTest.IsDead();
    }

    public void Attack(GameObject combatTarget)
    {
        GetComponent<ActionScheduler>().StartAction(this);
        target = combatTarget.GetComponent<Health>();
    }

    public void Cancel()
    {
        TriggerStopAttack();
        target = null;
    }

    private void TriggerStopAttack()
    {
        GetComponent<Animator>().ResetTrigger("attack");
        GetComponent<Animator>().SetTrigger("stopAttack");
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponRange);
        
    }
}