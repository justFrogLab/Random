using System.Text;
using UnityEngine;
using TMPro;

public class TimerPanel : MonoBehaviour
{
    #region Timer-Component
    [SerializeField]
    TextMeshProUGUI timeText;

    StringBuilder timeBuilder = new StringBuilder();

    float fTime = 60.0f;
    int iMin = 0;
    int iSec = 0;
    #endregion

    #region Round - Component
    [SerializeField]
    TextMeshProUGUI roundText;

    StringBuilder roundBuilder = new StringBuilder();

    int Round = 2;
    #endregion

    private void Update()
    {
        TimerUpdate();
        if ((int)fTime <= 0) AddRound();
    }

    #region TimerUpdate()
    private void TimerUpdate()
    {
        fTime -= Time.deltaTime;
        iMin = ((int)(fTime / 60)) % 60;
        iSec = (int)(fTime % 60);

        timeBuilder.Append(string.Format("{0:D2}", iMin));
        timeBuilder.Append(" : ");
        timeBuilder.Append(string.Format("{0:D2}", iSec));

        timeText.text = timeBuilder.ToString();
        timeBuilder.Clear();
    }
    #endregion

    #region AddRound()
    private void AddRound()
    {
        roundBuilder.Append("Round : ");
        roundBuilder.Append(Round.ToString());
        roundText.text = roundBuilder.ToString();

        roundBuilder.Clear();
        Round++;
        fTime = 30.0f;
    }
    #endregion
}
