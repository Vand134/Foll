using UnityEngine;

public class PlayerLookY : MonoBehaviour
{
    [SerializeField] float mouseSense = 1;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float rotateX = Input.GetAxis("Mouse X") * mouseSense;

        Vector3 rotPlayer = transform.rotation.eulerAngles;

        rotPlayer.y += rotateX;

        transform.rotation = Quaternion.Euler(rotPlayer);
    }
}
