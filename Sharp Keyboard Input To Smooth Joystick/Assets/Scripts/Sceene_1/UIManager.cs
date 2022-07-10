using UnityEngine;
using TMPro;
using InputSmoothers;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text xInputText;
    [SerializeField] private TMP_Text yInputText;

    [SerializeField] private InputSmoother �nputSmoother;
    
    
    void Update()
    {
        xInputText.text = �nputSmoother.GetSmoothInput().x.ToString();
        yInputText.text = �nputSmoother.GetSmoothInput().y.ToString();
    }
}
