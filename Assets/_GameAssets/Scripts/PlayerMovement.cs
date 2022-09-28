using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode buttonUp = KeyCode.W;
    [SerializeField] private KeyCode buttonDown = KeyCode.S;
    [SerializeField] private KeyCode buttonLeft = KeyCode.A;
    [SerializeField] private KeyCode buttonRight = KeyCode.D;

    private Vector3 direction = Vector3.right;
    private PlayerBody playerBody;
    private void Start()
    {
        playerBody = PlayerBody.Instance;
    }
    private void OnEnable()
    {
        ReversePlayerPowerUp.OnPlayerReverse += ChangeDirection;
    }
    private void OnDisable()
    {
        ReversePlayerPowerUp.OnPlayerReverse -= ChangeDirection;
    }
    private void Update()
    {
        if (Input.GetKeyDown(buttonUp))
        {
            if (direction != Vector3.down) direction = Vector3.up;
        }
        else if (Input.GetKeyDown(buttonDown))
        {
            if (direction != Vector3.up) direction = Vector3.down;
        }
        else if (Input.GetKeyDown(buttonLeft))
        {
            if (direction != Vector3.right) direction = Vector3.left;
        }
        else if (Input.GetKeyDown(buttonRight))
        {
            if (direction != Vector3.left) direction = Vector3.right;
        }
    }
    private void FixedUpdate()
    {
        if (this.transform.position.x > 30) this.transform.position = new Vector3(-29,this.transform.position.y,this.transform.position.z);
        if (this.transform.position.x < -30) this.transform.position = new Vector3(31,this.transform.position.y,this.transform.position.z);
        if (this.transform.position.y > 16) this.transform.position = new Vector3(this.transform.position.x,-16,this.transform.position.z);
        if (this.transform.position.y < -16) this.transform.position = new Vector3(this.transform.position.x, 15, this.transform.position.z);
        for (int i = playerBody.segments.Count - 1; i > 0; i--)
        {
            playerBody.segments[i].position = playerBody.segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0
        );
    }
    void ChangeDirection()
    {
        if (direction == Vector3.up) direction = Vector3.down;
        else if (direction == Vector3.down) direction = Vector3.up;
        else if (direction == Vector3.left) direction = Vector3.right;
        else if (direction == Vector3.right) direction = Vector3.left;
    }
}
