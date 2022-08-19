using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettingManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputValueField;
    [SerializeField] Button startBtn;
    int nowValue = 1;

    private void Start()
    {
        nowValue = 1;
        startBtn.onClick.AddListener(() => ValueSend());
    }

    private void ValueSend()
    {
        GameManager.instance.Value = nowValue;
        Debug.Log($"nowValue ::: {nowValue}");
        Debug.Log($"GameManager.instance.Value ::: {GameManager.instance.Value}");
        LoadingScenceManager.LoadScene("02.Lobby");
    }

    #region Update()
    private void Update()
    {
        SetValueUpdate();
    }

    void SetValueUpdate()
    {
        if (inputValueField.isFocused is false) return; // Set Value �� �ƴ϶�� Return
        if (Input.anyKeyDown is false) return; // ��� Ű �Էµ� �߻����� �ʾҴٸ� Return
        if (inputValueField.text is "")  inputValueField.text = "01";  // ���� ��������� 1�� ġȯ
       
        inputValueField.text = inputValueField.text.TrimStart('0'); // �� 0 ����
        int.TryParse(inputValueField.text, out nowValue);   // int �� ��ȯ
    }
    #endregion
}
