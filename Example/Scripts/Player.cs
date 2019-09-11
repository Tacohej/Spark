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
    public LayerMask layerMask;

    public Vector3 moveDirection = Vector3.zero;
    public Vector3 faceDirection = Vector3.zero;
    public float mag = 0;

    public Rigidbody bulletPrefab;

    public GameObject leftHand;
    public GameObject rightHand;

    private Rigidbody rigidBody;
    private float speed = 7;
    private Vector3 originalLeftPosition;
    private Vector3 originalRightPosition;
    private bool handSwitcher = true;
    

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        unit.SetBaseStat<Strength>(baseStrength);
        unit.SetBaseStat<Agility>(baseAgility);
        unit.SetBaseStat<Health>(baseHealth);

        originalLeftPosition = leftHand.transform.localPosition;
        originalRightPosition = rightHand.transform.localPosition;
    }

    void Update ()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");
        moveDirection = Vector3.ClampMagnitude(new Vector3(horizontalAxis, 0, verticalAxis), 1);
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
        {
            var offsettedPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            mag = (offsettedPosition - this.transform.position).magnitude;
            faceDirection = (offsettedPosition - this.transform.position).normalized;

            if (faceDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(faceDirection, this.transform.up);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 offset;

            if (leftHand.transform.localPosition == originalLeftPosition)
            {
                offset = this.transform.right * 0.5f;
                leftHand.transform.localPosition = originalLeftPosition - new Vector3(0, 0, 0.3f);
                rightHand.transform.localPosition = originalRightPosition;
            } else
            {
                offset = -this.transform.right * 0.5f;
                leftHand.transform.localPosition = originalLeftPosition;
                rightHand.transform.localPosition = originalRightPosition - new Vector3(0, 0, 0.3f);
            }

            // recoil
            rigidBody.AddForce(faceDirection * - 300);

            // bullet
            var instance = Instantiate(bulletPrefab, this.transform.position + this.transform.forward * 2 + offset, this.transform.rotation);
            instance.AddForce(faceDirection * 1200);
        }
    }

    void FixedUpdate() 
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
