using UnityEngine;


public class Controller : MonoBehaviour
{
    [SerializeField] LayerMask attackableTargets = default;

    private float castCooldown = 0;
    private int healthMissing = 0;
    private int manaMissing = 0;

    public int MoveSpeed { get {return (int)unit.moveSpeed.Value; } }
    public int ManaRegen { get {return (int)unit.manaRegen.Value; } }

    private Unit unit;

    void Start ()
    {
        unit = GetComponent<Unit>();
        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
    }

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

            }
            castCooldown = 4f;
        }
    }

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
            
        }
    }

    public void ReciveDamage (int amount)
    {
        Debug.Log("Amount" + amount);
        healthMissing += Mathf.Max(0, amount);
    }
}
