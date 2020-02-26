using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    public UnitStat MaxHealth = new UnitStat();
    public UnitStat MaxMana = new UnitStat();
    public UnitStat Power = new UnitStat();
    public UnitStat CastSpeed = new UnitStat();
    public UnitStat MoveSpeed = new UnitStat();
    public UnitStat Regen = new UnitStat();

    public _unit1 unit;

    public List<Item> items = new List<Item>();

    private int healthMissing = 0;
    private int manaMissing = 0;
    private float castCooldown = 0;

    public int Health
    {
        get { return MaxHealth.Value - healthMissing; }
    }

    public int Mana
    {
        get { return MaxMana.Value - manaMissing; }
    }

    void Start ()
    {
        items.Add(new BootsOfSpeed());

        foreach(Item item in items)
        {
            var equippableItem = item as IEquippable<Player>;
            if (equippableItem != null)
            {
                equippableItem.OnEquip(this);
            }
        }

        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
    }

    void UpdateEverySecond ()
    {
        manaMissing = Mathf.Max(MaxMana.Value, manaMissing + Regen.Value);
    }

    void Update ()
    {
        var dt = Time.deltaTime;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(direction * dt * MoveSpeed.Value);

        // attacking
        if (castCooldown < 0)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Attack");
                castCooldown = 5;
            }
        }
        else
        {
            castCooldown -= dt * CastSpeed.Value;
        }
    }
}
