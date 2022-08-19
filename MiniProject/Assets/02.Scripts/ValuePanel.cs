using System.Text;
using UnityEngine;
using TMPro;

public class ValuePanel : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ValueText;

    StringBuilder valueText = new StringBuilder();

    private void Start()
    {
        valueText.Append(GameManager.instance.Value.ToString());
        valueText.Append("%");
        ValueText.text = string.Format("{0:#,###}", valueText.ToString());
        valueText.Clear();
    }
}
