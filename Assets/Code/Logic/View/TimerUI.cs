using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public IntVariable TimeValue;
    public TMP_Text TimeLabel;

    private void Start() 
    {
        ChangeTimeText(TimeValue.CurrentValue);
    }

    private void OnEnable() 
    {
        TimeValue.OnValueChange += ChangeTimeText;
    }

    private void OnDisable() 
    {
        TimeValue.OnValueChange -= ChangeTimeText;
    }

    private void ChangeTimeText(int time)
    {
        TimeLabel.text = time.ToString();
    }
}
