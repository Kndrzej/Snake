using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode buttonUp = KeyCode.W;
    [SerializeField] private KeyCode buttonDown = KeyCode.S;
    [SerializeField] private KeyCode buttonLeft = KeyCode.A;
    [SerializeField] private KeyCode buttonRight = KeyCode.D;
    
    private Vector3 direction = Vector3.right;
    
    private void Update()
    {
        if (Input.GetKeyDown(buttonUp))
        {
            direction = Vector3.up;
        }
        else if(Input.GetKeyDown(buttonDown))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown(buttonLeft))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(buttonRight))
        {
            direction = Vector3.right;
        }
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0
        );
    }
}
