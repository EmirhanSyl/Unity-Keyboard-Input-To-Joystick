using UnityEngine;
using TMPro;

namespace InputSmoother
{
    public class InputSmoother : MonoBehaviour
    {
        [SerializeField] private TMP_Text xText;
        [SerializeField] private TMP_Text yText;

        [Space(10)]
        [SerializeField] private float smoothnessRate;

        private float xSmooth;
        private float ySmooth;
        private float accelerationRate_X = 1;
        private float accelerationRate_Y = 1;

        private bool StateChanged_X;
        private bool StateChanged_Y;
        
        Vector2 input;
        

        void Update()
        {
            Smoother_X();
            Smoother_Y();
            
            xText.text = xSmooth.ToString();
            yText.text = ySmooth.ToString();            
        }

        void Smoother_Y()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W) && ySmooth <= 1)
                {
                    ySmooth += Time.deltaTime * smoothnessRate;
                }
                else if (Input.GetKey(KeyCode.S) && ySmooth >= -1)
                {
                    ySmooth -= Time.deltaTime * smoothnessRate;
                }
            }
            else
            {
                if (ySmooth < 0)
                {
                    ySmooth += Time.deltaTime * smoothnessRate;
                }
                else if (ySmooth > 0)
                {
                    ySmooth -= Time.deltaTime * smoothnessRate;
                }
            }
        }
        
        void Smoother_X()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.D) && xSmooth <= 1)
                {
                    xSmooth += Time.deltaTime * smoothnessRate;
                }
                else if (Input.GetKey(KeyCode.A) && xSmooth >= -1)
                {
                    xSmooth -= Time.deltaTime * smoothnessRate;
                }
            }
            else
            {
                if (xSmooth < 0)
                {
                    xSmooth += Time.deltaTime * smoothnessRate;
                }
                else if (xSmooth > 0)
                {
                    xSmooth -= Time.deltaTime * smoothnessRate;
                }
            }
        }
        
        public Vector2 GetSmoothInput()
        {
            Vector2 smoothInput = new Vector2(xSmooth, ySmooth);
            return smoothInput;
        }
    }
}

