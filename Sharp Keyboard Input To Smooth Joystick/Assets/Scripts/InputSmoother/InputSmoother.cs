using UnityEngine;
using TMPro;

namespace InputSmoothers
{
    public class InputSmoother : MonoBehaviour
    {
        [Header("Acceleration")]
        [SerializeField] private bool accelerationActive = true;
        [SerializeField] [Range(1, 10)] private float accelerationRange = 1;
        [SerializeField] [Range(0, 1)] private float accelerationMultiplier = 0.5f;

        
        [Header("Smoothness")]
        [Space(5)]
        [SerializeField] private float smoothnessRate;
        
        
        //Private Variables
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

            
        }

        void Smoother_Y()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W) && ySmooth <= 1)
                {
                    ySmooth += Time.deltaTime * smoothnessRate * accelerationRate_Y;
                }
                else if (Input.GetKey(KeyCode.S) && ySmooth >= -1)
                {
                    ySmooth -= Time.deltaTime * smoothnessRate * accelerationRate_Y;
                }

                
                if (!accelerationActive) return;

                if (!StateChanged_Y)
                {
                    accelerationRate_Y = 1;
                    StateChanged_Y = true;
                }
                else if (StateChanged_Y && accelerationRate_Y < accelerationRange)
                {
                    accelerationRate_Y += Time.deltaTime / accelerationMultiplier;
                }
            }
            else
            {
                StateChanged_Y = false;
                
                if (ySmooth < 0)
                {
                    ySmooth += Time.deltaTime * smoothnessRate;
                }
                else if (ySmooth > 0)
                {
                    ySmooth -= Time.deltaTime * smoothnessRate;
                }
                
                if (ySmooth < 0.05f && ySmooth > -0.05f)
                {
                    ySmooth = 0;
                }
            }
        }
        
        void Smoother_X()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.D) && xSmooth <= 1)
                {
                    xSmooth += Time.deltaTime * smoothnessRate * accelerationRate_X;
                }
                else if (Input.GetKey(KeyCode.A) && xSmooth >= -1)
                {
                    xSmooth -= Time.deltaTime * smoothnessRate * accelerationRate_X;
                }

                if (!accelerationActive) return;
                
                if (!StateChanged_X)
                {
                    accelerationRate_X = 1;
                    StateChanged_X = true;
                }
                else if(StateChanged_X && accelerationRate_X < accelerationRange)
                {
                    accelerationRate_X += Time.deltaTime / accelerationMultiplier;
                }
            }
            else
            {
                StateChanged_X = false;
                
                if (xSmooth < 0)
                {
                    xSmooth += Time.deltaTime * smoothnessRate;
                }
                else if (xSmooth > 0)
                {
                    xSmooth -= Time.deltaTime * smoothnessRate;
                }

                if (xSmooth < 0.05f && xSmooth > -0.05f)
                {
                    xSmooth = 0;
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

