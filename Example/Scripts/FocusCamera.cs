using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject focusObject;

    private Vector3 offsetVector;

    void Start()
    {
        offsetVector = this.transform.position - focusObject.transform.position;
    }

    void FixedUpdate()
    {
        var faceDir = focusObject.GetComponent<Player>().faceDirection;
        var mag = focusObject.GetComponent<Player>().mag;
        var movedir = focusObject.GetComponent<Player>().moveDirection;
        this.transform.position = Vector3.Lerp(this.transform.position + faceDir * 0.3f * Mathf.Clamp(mag * 0.2f, 0, 3) + movedir * 0.5f, offsetVector + focusObject.transform.position, 0.2f);
    }
}
