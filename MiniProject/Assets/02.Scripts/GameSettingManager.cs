using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettingManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputValueField;

    int nowValue = 0;

    private void Update()
    {
        SetValueUpdate();
    }

    void SetValueUpdate()
    {
        if (inputValueField.isFocused is false) return; // Set Value �� �ƴ϶�� Return
        if (Input.anyKeyDown is false) return; // ��� Ű �Էµ� �߻����� �ʾҴٸ� Return

        if (inputValueField.text is "") inputValueField.text = "01"; // ���� ��������� 1�� ġȯ
        inputValueField.text = inputValueField.text.TrimStart('0'); // �� 0 ����
        int.TryParse(inputValueField.text, out nowValue);   // int �� ��ȯ
    }

}
