using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSphere : NetworkBehaviour {
    private void Update() {
        if (hasAuthority) {
            if (Input.GetMouseButtonDown(0)) {
                transform.Translate(Vector3.up * Time.deltaTime * 3f);
            }
        }
    }
}