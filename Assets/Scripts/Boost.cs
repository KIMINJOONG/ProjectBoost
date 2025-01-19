using UnityEngine;
using UnityEngine.EventSystems;

public class Boost : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    [SerializeField] float mainThrust = 1000f;
    public GameObject Rocket;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rocket = GameObject.Find("Rocket");

        if (Rocket == null)
        {
            Debug.LogError("Player GameObject not found!");
        }

        if (Rocket != null)
        {
            // Rocket에서 Rigidbody를 접근
            rb = Rocket.GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();


            if (rb == null)
            {
                Debug.LogError("Rigidbody not found on targetObject!");
            }


            Transform mainBoosterTransform = Rocket.GetComponent<Transform>().Find("Rocket Jet Particles");
            mainBooster = mainBoosterTransform.GetComponent<ParticleSystem>();

            if (mainBooster == null)
            {
                Debug.LogError("rightBooster null");
            }





            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on Rocket!");
            }

            // AudioSource에서 AudioClip을 가져옵니다.
            if (audioSource != null)
            {
                // mainEngine = audioSource.clip;  // AudioSource에서 현재 할당된 AudioClip을 가져옵니다.
            }

            if (mainEngine == null)
            {
                Debug.LogError("AudioClip not assigned in AudioSource on Rocket!");
            }

            if (rb == null)
            {
                Debug.LogError("Rigidbody not found on targetObject!");
            }
        }
        else
        {
            Debug.LogError("targetObject is not assigned!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();


        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    void StartThrusting()
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

    void StopThrusting()
    {
        audioSource.Stop();
        mainBooster.Stop();
    }
}
