using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    public Vector3 jump;
    public float jumpForce = 100f;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    //public bool isGrounded;
    Rigidbody rb;

    

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, jumpForce, 0f);

        
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Jump") && Physics.OverlapSphere(groundCheckPosition.position, groundCheckRadius, groundLayer).Length > 0)
        {
            //isGrounded = Physics.OverlapSphere(groundCheckPosition.position, groundCheckRadius, groundLayer).Length > 0;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            //isGrounded = false;

            Debug.Log(Physics.OverlapSphere(groundCheckPosition.position, groundCheckRadius, groundLayer).Length);
        }

        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        //Final movement Vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //Apply Movement
        motor.Move(_velocity);

        //Calculate rotation as a 3D vector: (turning around, the player, not the camera)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;


        //apply rotation
        motor.Rotation(_rotation);

        //Calculate camera rotation as a 3D vector:
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;


        //apply camera rotation
        motor.RotateCamera(_cameraRotation);

    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    isGrounded = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRadius);
    }
}

