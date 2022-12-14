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
        if (inputValueField.isFocused is false) return; // Set Value 가 아니라면 Return
        if (Input.anyKeyDown is false) return; // 어떠한 키 입력도 발생하지 않았다면 Return
        if (inputValueField.text is "")  inputValueField.text = "01";  // 값이 비어있으면 1로 치환
       
        inputValueField.text = inputValueField.text.TrimStart('0'); // 앞 0 제거
        int.TryParse(inputValueField.text, out nowValue);   // int 형 변환
    }
    #endregion
}
