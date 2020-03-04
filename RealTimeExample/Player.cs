using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    [SerializeField] StatModifierValue maxHealthBase;
    [SerializeField] StatModifierValue maxManaBase;
    [SerializeField] StatModifierValue manaRegenBase;
    [SerializeField] StatModifierValue moveSpeedBase;
    [SerializeField] StatModifierValue castSpeedBase;

    [SerializeField] LayerMask attackableTargets;

    private Unit unit;
    private int healthMissing = 0;
    private int manaMissing = 0;
    private float castCooldown = 0;

    void Start ()
    {
        unit = GetComponent<Unit>();

        unit.AddModifier("MaxHealth", maxHealthBase);
        unit.AddModifier("MaxMana", maxManaBase);
        unit.AddModifier("ManaRegen", manaRegenBase);
        unit.AddModifier("MoveSpeed", moveSpeedBase);
        unit.AddModifier("CastSpeed", castSpeedBase);

        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
    }

    public int Health { get { return MaxHealth - healthMissing; } }
    public int Mana { get { return MaxMana - manaMissing; } }
    public int MaxHealth { get { return unit.GetStat("MaxHealth") * 10; } }
    public int MaxMana { get { return unit.GetStat("MaxMana") * 10; } }

    private int ManaRegen { get { return unit.GetStat("ManaRegen"); } }
    private int MoveSpeed { get { return unit.GetStat("MoveSpeed"); } }
    private int CastSpeed { get { return unit.GetStat("CastSpeed"); } }

    void UpdateEverySecond ()
    {
        manaMissing = Mathf.Max(0, manaMissing - ManaRegen);
    }

    public Unit[] Targets { set; get; }

    

    void MeleeAttack ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var pos = this.transform.position;
            var direction = (new Vector3(hit.point.x, pos.y, hit.point.z) - pos).normalized;
            var impactOrigo = pos + direction * 3;
            var list = Physics.OverlapSphere(pos, 5, attackableTargets);
            Debug.DrawLine(pos, impactOrigo, Color.red, 1);

            if (list.Length > 0)
            {
                Debug.Log("List" + list);
                
            }

            unit.TriggerEffect("OnAttack");
            castCooldown = 4f;
        }

        // castCooldown = 5;
        // manaMissing += 30;
        // unit.TriggerEffect("OnAttack");
        

        // unit.TriggerEffect(new OnAttackTigger())
    
        // unit.TriggerEffect<OnAttack>({caster: this})
    }

    // void OnDrawGizmosSelected () 
    // {
    //     Debug.dr
    //     //Gizmos.DrawLine(this.transform.position, this.transform.position + direction * 5);
    // }

    void Update ()
    {
        var dt = Time.deltaTime;
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(direction * dt * MoveSpeed);

        // attacking
        if (castCooldown < 0)
        {
            if (Input.GetMouseButton(0))
            {
                MeleeAttack();
            }
        }
        else
        {
            castCooldown -= dt * CastSpeed;
        }
    }

    public void ReciveDamage (int amount)
    {
        Debug.Log("Amount" + amount);
        healthMissing += Mathf.Max(0, amount);
        unit.TriggerEffect("DamageTaken");
    }
}
