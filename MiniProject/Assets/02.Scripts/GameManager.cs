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
    private int mouseCameraSpd = 50;    // �ɼǿ� �־���ߵ�

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

        mainCamTr = Camera.main.transform;    // ���� ī�޶� ��ġ

        screenWidth = Screen.width - mouseInterporation; // ��ũ�� ����
        screenHeight = Screen.height - mouseInterporation;   // ��ũ�� ����

        mouseMaxMoveX = (float)(FieldArea.localScale.x  * mouseMaxInterporation);   // ���콺 �ִ� �̵� �Ÿ� x
        mouseMaxMoveZ = (float)(FieldArea.localScale.z  * mouseMaxInterporation);  // / ���콺 �ִ� �̵� �Ÿ� z

        mouseCameraMoveX = new Vector3(mouseCameraSpd, 0f, 0f);    // ���콺 �̵� ����  X
        mouseCameraMoveZ = new Vector3(0f, 0f, mouseCameraSpd);     // ���콺 �̵� ���� Z
        mouseCameraBack = Vector3.one;  // �ִ� �Ÿ� ���޽� ���ư� �Լ�
        Cursor.lockState = CursorLockMode.Confined; // ���콺 ���

        Debug.Log($"mouseMaxMoveZ ::: {mouseMaxMoveZ}");
    }

    private void Update()
    {
        MouseScreenOverMove();

    }

    private void MouseScreenOverMove()
    {
        // ��
        if (Input.mousePosition.x <= mouseInterporation)
        {
            // �ʵ� ���� ��� 150f
            if (mainCamTr.position.x < -mouseMaxMoveX  )
            {
                Debug.Log("�ʵ� ���� (����)��� ");
            }
            mainCamTr.position -= mouseCameraMoveX * Time.deltaTime;
        }

        // ��
        else if (Input.mousePosition.x >= screenWidth)
        {
            if (mainCamTr.position.x > mouseMaxMoveX)
            {
                Debug.Log("�ʵ� ���� (����)��� ");
            }

            mainCamTr.position += mouseCameraMoveX * Time.deltaTime;
        }

        // ��
        else if (Input.mousePosition.y <= mouseInterporation)
        {
            if (mainCamTr.position.z < -mouseMaxMoveZ)
            {
                Debug.Log("�ʵ� ���� (�ϴ�)��� ");
            }

            mainCamTr.position -= mouseCameraMoveZ * Time.deltaTime;
        }

        // ��
        else if (Input.mousePosition.y >= screenHeight)
        {
            if (mainCamTr.position.z > mouseMaxMoveZ)
            {
                Debug.Log("�ʵ� ���� (���)��� ");
            }
            mainCamTr.position += mouseCameraMoveZ * Time.deltaTime;
        } 

    }
}
