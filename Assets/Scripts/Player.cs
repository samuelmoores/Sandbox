using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed_player;

    CharacterController controller;
    Animator animator;
    Vector3 movementDirection;
    float playerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerSpeed = runSpeed_player;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");
        movementDirection.Normalize();

        animator.SetFloat("velocity_x", movementDirection.x);
        animator.SetFloat("velocity_y", movementDirection.z);

        float cameraYaw = Camera.main.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0.0f, cameraYaw, 0.0f), Time.deltaTime * 10.0f);
        movementDirection = transform.rotation * movementDirection;

        controller.Move(movementDirection * Time.deltaTime * playerSpeed);
    }
}
