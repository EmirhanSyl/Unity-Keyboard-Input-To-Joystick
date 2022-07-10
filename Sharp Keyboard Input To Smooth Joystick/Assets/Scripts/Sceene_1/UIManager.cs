using UnityEngine;
using TMPro;
using InputSmoothers;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text xInputText;
    [SerializeField] private TMP_Text yInputText;

    [SerializeField] private InputSmoother ýnputSmoother;
    
    
    void Update()
    {
        xInputText.text = ýnputSmoother.GetSmoothInput().x.ToString();
        yInputText.text = ýnputSmoother.GetSmoothInput().y.ToString();
    }
}
