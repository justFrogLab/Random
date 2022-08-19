using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Transform fieldArea;
    private Transform mainCamTr;
    private int value = 1;

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public Transform FieldArea
    {
        get { return fieldArea;  }
        set { fieldArea = value; }
    }

    private int screenWidth = 0;
    private int screenHeight = 0;


    private float mouseMaxMoveX = 0f;
    private float mouseMaxMoveZ = 0f;
    private float mouseMaxInterporation = 0.5f;


    private readonly int mouseInterporation = 5;
    private int mouseCameraSpd = 50;    // 옵션에 넣어줘야됨

    private Vector3 mouseCameraMoveX;
    private Vector3 mouseCameraMoveZ;
    private Vector3 mouseCameraBack;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        mainCamTr = Camera.main.transform;    // 메인 카메라 위치

        screenWidth = Screen.width - mouseInterporation; // 스크린 가로
        screenHeight = Screen.height - mouseInterporation;   // 스크린 세로

        mouseMaxMoveX = (float)(FieldArea.localScale.x  * mouseMaxInterporation);   // 마우스 최대 이동 거리 x
        mouseMaxMoveZ = (float)(FieldArea.localScale.z  * mouseMaxInterporation);  // / 마우스 최대 이동 거리 z

        mouseCameraMoveX = new Vector3(mouseCameraSpd, 0f, 0f);    // 마우스 이동 백터  X
        mouseCameraMoveZ = new Vector3(0f, 0f, mouseCameraSpd);     // 마우스 이동 백터 Z
        mouseCameraBack = Vector3.one;  // 최대 거리 도달시 돌아갈 함수
        Cursor.lockState = CursorLockMode.Confined; // 마우스 잠금

        Debug.Log($"mouseMaxMoveZ ::: {mouseMaxMoveZ}");
    }

    private void Update()
    {
        MouseScreenOverMove();

    }

    private void MouseScreenOverMove()
    {
        // 좌
        if (Input.mousePosition.x <= mouseInterporation)
        {
            // 필드 범위 벗어남 150f
            if (mainCamTr.position.x < -mouseMaxMoveX  )
            {
                Debug.Log("필드 범위 (좌측)벗어남 ");
            }
            mainCamTr.position -= mouseCameraMoveX * Time.deltaTime;
        }

        // 우
        else if (Input.mousePosition.x >= screenWidth)
        {
            if (mainCamTr.position.x > mouseMaxMoveX)
            {
                Debug.Log("필드 범위 (우측)벗어남 ");
            }

            mainCamTr.position += mouseCameraMoveX * Time.deltaTime;
        }

        // 하
        else if (Input.mousePosition.y <= mouseInterporation)
        {
            if (mainCamTr.position.z < -mouseMaxMoveZ)
            {
                Debug.Log("필드 범위 (하단)벗어남 ");
            }

            mainCamTr.position -= mouseCameraMoveZ * Time.deltaTime;
        }

        // 상
        else if (Input.mousePosition.y >= screenHeight)
        {
            if (mainCamTr.position.z > mouseMaxMoveZ)
            {
                Debug.Log("필드 범위 (상단)벗어남 ");
            }
            mainCamTr.position += mouseCameraMoveZ * Time.deltaTime;
        } 

    }
}
