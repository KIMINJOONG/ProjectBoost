using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

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
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

            if (!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainBooster.Stop();
        }


    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AapplyRotation(rotationThrust);
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            AapplyRotation(-rotationThrust);
            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
        }
        else
        {
            leftBooster.Stop();
            rightBooster.Stop();
        }
    }

    void AapplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // 수동제어를 할 수 있도록 회전을 고정한다.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // 물리 시스템이 적용되도록 회전 고정을 해제한다.
    }
}
