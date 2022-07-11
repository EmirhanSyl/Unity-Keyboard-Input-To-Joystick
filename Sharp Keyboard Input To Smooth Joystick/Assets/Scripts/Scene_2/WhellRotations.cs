using UnityEngine;
using InputSmoothers;
using DG.Tweening;

public class WhellRotations : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private bool frontWhell;

    private InputSmoother inputSmoother;
    float yRotStart;

    private void Start()
    {
        inputSmoother = GetComponentInParent<InputSmoother>();

        yRotStart = transform.eulerAngles.y;
    }
    
    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * rotationSpeed, 0, 0));

        if (frontWhell)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        var input = inputSmoother.GetSmoothInput();
        //input *= 10f;
        //float xClamped = Mathf.Clamp(input.x, -1f, 1f);
        //input.x = xClamped;

        transform.DOLocalRotate(new Vector3(transform.eulerAngles.x, yRotStart + (input.x * 45), 0), 0.1f);

        Quaternion rot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        float yRot = Mathf.Clamp(transform.eulerAngles.y, yRotStart - 45f, yRotStart + 45f);
        rot.y = yRot;

        transform.localRotation = rot;

        Debug.Log("Input x: " + input.x * 45 + " Angle y: " + transform.eulerAngles.y);
    }
}
