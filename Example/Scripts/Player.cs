using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    public int baseHealth = 100;
    public int baseStrength = 5;
    public int baseAgility = 7;

    public SparkUnit unit;
    public Rigidbody rigidBody;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();

        unit.SetBaseStat<Strength>(baseStrength);
        unit.SetBaseStat<Agility>(baseAgility);
        unit.SetBaseStat<Health>(baseHealth);
    }

    void Update ()
    {


        if (Input.GetMouseButton(1))
        {
            // todo: ignore player on raycast
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var offsettedPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
                var mag = (offsettedPosition - this.transform.position).magnitude;
                var clampedMag = Vector3.ClampMagnitude((offsettedPosition - this.transform.position), 1).magnitude;
                var direction = (offsettedPosition - this.transform.position).normalized;
                Debug.Log(clampedMag);
                var vel = Time.deltaTime * direction * 2000 * clampedMag;
                Debug.Log(vel.magnitude);
                rigidBody.velocity = Vector3.ClampMagnitude(vel, 20);
            }

            this.transform.position = new Vector3(this.transform.position.x, Mathf.Abs(Mathf.Sin(Time.time * 10)), this.transform.position.z);
        } else {
            rigidBody.velocity = Vector3.zero;
            this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        }
    }
}
