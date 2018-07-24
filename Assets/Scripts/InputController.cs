using UnityEngine;
using UnityEngine.Networking;

public class InputController : NetworkBehaviour {
    public float Speed = 3f;
    public float Sensitivity = 2f;

    public GameObject PlayerSphere;

    private Camera playerCamera;

    // Use this for initialization
    void Start() {
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) return;
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * Time.deltaTime * Speed);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * Time.deltaTime * Speed);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.I)) CmdSpawnSphere();

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        Vector3 rotateValue = new Vector3(0, horizontal * Sensitivity, 0);
        Vector3 cameraValue = new Vector3(-vertical * Sensitivity, 0, 0);

        transform.eulerAngles += rotateValue;
        playerCamera.transform.eulerAngles += cameraValue;
    }

    [Command]
    public void CmdSpawnSphere() {
        GameObject sphere = Instantiate(PlayerSphere, transform.position, Quaternion.identity);
        NetworkServer.SpawnWithClientAuthority(sphere, connectionToClient);
    }
}