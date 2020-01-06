using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStuff : MonoBehaviour
{
    public GameObject doug;
    public GameObject ball;
    public float launchSpeed;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                LaunchBall(hit.point);
            }
        }
    }

    void LaunchBall(Vector3 targetDirection) {
        var b = Instantiate(ball, Camera.main.transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(targetDirection * launchSpeed);

        doug.GetComponent<Doug>().pointOfInterest = b.transform;
    }
}
