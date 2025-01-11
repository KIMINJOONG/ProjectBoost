using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }


    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AapplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AapplyRotation(-rotationThrust);
        }
    }

    void AapplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // 수동제어를 할 수 있도록 회전을 고정한다.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // 물리 시스템이 적용되도록 회전 고정을 해제한다.
    }
}
