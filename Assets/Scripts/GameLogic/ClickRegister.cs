using UnityEngine;

public class ClickRegister : MonoBehaviour
{
    [SerializeField] private LayerMask clickMask;
    [SerializeField]private Camera camera;
    

    public void Init()
    {

    }

    private void Update()
    {
        ClickObject();
    }

    private void ClickObject()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, clickMask))
            {
                var button3D = hit.collider.GetComponent<Button3D>();
                button3D?.Select();
            }
        }
    }
}
