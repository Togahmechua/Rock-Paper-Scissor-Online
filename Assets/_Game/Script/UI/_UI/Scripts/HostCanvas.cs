using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HostCanvas : UICanvas
{
    [SerializeField] private Button startHostBtn;
    [SerializeField] private Button startClientBtn;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        startHostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            anim.Play(CacheString.TAG_WAITOTHERPLAYER); 
        });

        startClientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });

        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void OnClientConnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} đã kết nối!");

        if (NetworkManager.Singleton.ConnectedClientsList.Count >= 2) // 1 host + 1 client
        {
            Debug.Log("Đủ số lượng người chơi, bắt đầu game!");
            StopWaitingAndStartGame();
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        Debug.Log($"Client {clientId} đã ngắt kết nối.");
    }

    private void StopWaitingAndStartGame()
    {
        CloseThisCanvas();
    }

    public void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }

    private void CloseThisCanvas()
    {
        gameObject.SetActive(false);
        UIManager.Ins.OpenUI<OnlineCanvas>();
    }
}
