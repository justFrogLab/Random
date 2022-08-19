using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [SerializeField]
    Transform fieldArea;


    private void Awake()
    {
        GameManager.instance.FieldArea = fieldArea;

        Destroy(this.gameObject);
    }
}
