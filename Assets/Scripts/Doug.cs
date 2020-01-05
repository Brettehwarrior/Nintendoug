using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Doug : MonoBehaviour
{
    public Transform pointOfInterest;
    public CharacterController controller;

    public float moveSpeed;

    void Update() {
        Move();
    }

    void Move() {
        var offset = pointOfInterest.position - transform.position;
        offset.y = 0f;

        if (offset.magnitude > .1f) {
            transform.rotation = Quaternion.LookRotation(offset);
            offset = offset.normalized * moveSpeed;
            controller.Move(offset * Time.deltaTime);
        }
    }
}
