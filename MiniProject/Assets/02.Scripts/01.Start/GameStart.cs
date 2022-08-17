using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    Button startBtn;

    private void Awake() => startBtn = GetComponent<Button>();

    private void Start() => startBtn.onClick.AddListener(() => __GameStart());

    public void __GameStart() => LoadingScenceManager.LoadScene("01.Setting");

}
