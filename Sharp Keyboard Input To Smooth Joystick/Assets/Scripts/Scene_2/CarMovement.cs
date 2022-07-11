using UnityEngine;
using DG.Tweening;
using InputSmoothers;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private bool goingBack;
    
    private InputSmoother inputSmoother;
    private Rigidbody rb;
    
    void Start()
    {
        inputSmoother = GetComponent<InputSmoother>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (inputSmoother.GetSmoothInput().y < 0)
        {
            goingBack = true;
        }
        else
        {
            goingBack = false;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 smoothInput = inputSmoother.GetSmoothInput() * speed;
        //smoothInput = smoothInput.normalized;
        
        //rb.velocity = new Vector3(smoothInput.x, rb.velocity.y, smoothInput.y);
        rb.AddForce(Vector3.forward * smoothInput);

        if (goingBack)
        {
            rb.MoveRotation(Quaternion.LookRotation(new Vector3(smoothInput.x, 0, smoothInput.y) * -1f));
        }
        else
        {
            rb.MoveRotation(Quaternion.LookRotation(new Vector3(smoothInput.x, 0 , smoothInput.y)));
        }
    }    
}
