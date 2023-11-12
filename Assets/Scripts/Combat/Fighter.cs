using UnityEngine;

public class Fighter : MonoBehaviour, IAction
{
    public AdwinSO adwinStats;
    [SerializeField] float weaponRange = 2f;
    [SerializeField] float timeBetweenAttack = 1f;
    [SerializeField] float weaponDamage = 5f;

    float timeSinceLastAttack = Mathf.Infinity;

    Health target;
    Mover mover;

    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (adwinStats != null)
        {
            weaponRange = adwinStats.skillPoints[0];
            timeBetweenAttack = adwinStats.skillPoints[1];
            weaponDamage = adwinStats.skillPoints[2];
        }

        timeSinceLastAttack += Time.deltaTime;

        if (target == null) return;

        if (target.IsDead()) return;

        if (!GetIsInRange())
        {
            mover.MoveTo(target.transform.position, 1f);
        }

        else
        {
            mover.Cancel();
            AttackBehaviour();
        }
    }

    private void AttackBehaviour()
    {
        // transform.LookAt(target.transform);

        if (timeSinceLastAttack > timeBetweenAttack)
        {
            // // This will trigger Hit() event.
            // TriggerAttack();
            target.TakeDamage(weaponDamage);
            TextPopup.CreateDamage(target.transform.position, (int)weaponDamage);
            timeSinceLastAttack = 0;
        }
    }

    // private void TriggerAttack()
    // {
    //     GetComponent<Animator>().ResetTrigger("stopAttack");
    //     GetComponent<Animator>().SetTrigger("attack");
    // }

    // // Animation Event
    // void Hit()
    // {
    //     if (target == null) return;
    //     target.TakeDamage(weaponDamage);
    // }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
    }

    public float GetWeaponRange()
    {
        return weaponRange;
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
        // TriggerStopAttack();
        target = null;
        GetComponent<Mover>().Cancel();
    }

    // private void TriggerStopAttack()
    // {
    //     GetComponent<Animator>().ResetTrigger("attack");
    //     GetComponent<Animator>().SetTrigger("stopAttack");
    // }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, weaponRange);

    }

}