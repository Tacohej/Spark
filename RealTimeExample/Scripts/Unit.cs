using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Unit : MonoBehaviour
{
    public List<UnitItem> items;

    public UnitStat stamina;
    public UnitStat strength;
    public UnitStat agility;
    public UnitStat intelligence;

    private FormulaFloat crit;

    public ResourceInt health;
    public ResourceInt mana;

    public Unit target;

    public TriggeredEffect<Unit> onAttackEffect = new TriggeredEffect<Unit>();
    public TriggeredEffect onStartEffect = new TriggeredEffect();

    public RealTimeManager<Unit> statusEffectManager;

    void Awake ()
    {
        health = new ResourceInt(stamina);
        mana = new ResourceInt(intelligence);

        statusEffectManager = new RealTimeManager<Unit>(this);

        foreach (UnitItem item in items)
        {
            item.Equip(this);
        }

        crit = new FormulaFloat(agility)
            .Multiply(0.001f);

    }

    void Update ()
    {
        statusEffectManager.UpdateStatusEffects();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (UnitItem item in items)
            {
                item.Unequip(this);
            }
            // onAttackEffect.Trigger(target);
        }

        if (Input.GetMouseButtonDown(1))
        {
            onAttackEffect.Trigger(target);
        }

        
        Debug.Log(crit.Value);
    }

}


// public class Player : MonoBehaviour
// {
//     [SerializeField] StatModifier maxHealthBase = default;
//     [SerializeField] StatModifier maxManaBase = default;
//     [SerializeField] StatModifier manaRegenBase = default;
//     [SerializeField] StatModifier moveSpeedBase = default;
//     [SerializeField] StatModifier castSpeedBase = default;

//     [SerializeField] BootsOfSpeed bootsOfSpeed;

//     [SerializeField] LayerMask attackableTargets = default;

//     private float castCooldown = 0;
//     private int healthMissing = 0;
//     private int manaMissing = 0;

//     void Start ()
//     {
//         AddModifier(maxHealthBase);
//         AddModifier(maxManaBase);
//         AddModifier(manaRegenBase);
//         AddModifier(moveSpeedBase);
//         AddModifier(castSpeedBase);

//         EquipItem(bootsOfSpeed);

//         InvokeRepeating("UpdateEverySecond", 0, 1.0f);
//     }

//     public int Health { get { return MaxHealth - healthMissing; } }
//     public int Mana { get { return MaxMana - manaMissing; } }
//     public int MaxHealth { get { return GetStat("MaxHealth") * 10; } }
//     public int MaxMana { get { return GetStat("MaxMana") * 10; } }

//     private int ManaRegen { get { return GetStat("ManaRegen"); } }
//     private int MoveSpeed { get { return GetStat("MoveSpeed"); } }
//     private int CastSpeed { get { return GetStat("CastSpeed"); } }

//     void UpdateEverySecond ()
//     {
//         manaMissing = Mathf.Max(0, manaMissing - ManaRegen);
//     }

//     public Unit[] Targets { set; get; }

//     void MeleeAttack ()
//     {
//         RaycastHit hit;
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         if (Physics.Raycast(ray, out hit))
//         {
//             var pos = this.transform.position;
//             var direction = (new Vector3(hit.point.x, pos.y, hit.point.z) - pos).normalized;
//             var impactOrigo = pos + direction * 3;
//             var list = Physics.OverlapSphere(pos, 5, attackableTargets);
//             Debug.DrawLine(pos, impactOrigo, Color.red, 1);

//             if (list.Length > 0)
//             {

//             }

//             TriggerEffect("OnAttack");
//             castCooldown = 4f;
//         }
//     }

//     void Update ()
//     {
//         UpdateStatusEffects();

//         var dt = Time.deltaTime;
//         var horizontal = Input.GetAxisRaw("Horizontal");
//         var vertical = Input.GetAxisRaw("Vertical");
//         var direction = new Vector3(horizontal, 0, vertical).normalized;

//         transform.Translate(direction * dt * MoveSpeed);

//         // attacking
//         if (castCooldown < 0)
//         {
//             if (Input.GetMouseButton(0))
//             {
//                 MeleeAttack();
//             }
//         }
//         else
//         {
//             castCooldown -= dt * CastSpeed;
//         }
//     }

//     public void ReciveDamage (int amount)
//     {
//         Debug.Log("Amount" + amount);
//         healthMissing += Mathf.Max(0, amount);
//         TriggerEffect("DamageTaken");
//     }
// }
