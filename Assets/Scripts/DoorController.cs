using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    GameObject DoorStart;
    [SerializeField]
    GameObject DoorEnd;
    
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
            ToggleDoor();
    }

    private void ToggleDoor()
    {
        DoorStart.SetActive(!DoorStart.activeSelf);
        DoorEnd.SetActive(!DoorStart.activeSelf);
    }
}
