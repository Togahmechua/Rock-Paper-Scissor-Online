using System;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    #region Default
    private static GameManager instance;
    public static GameManager Ins => instance;
    //[SerializeField] UserData userData;
    //[SerializeField] CSVData csv;
    //private static GameState gameState = GameState.MainMenu;

    // Start is called before the first frame update
    public bool isActive;
    #endregion

    #region Add
    [Header("Network")]
    public bool allChoosed;

    [SerializeField] private int hostStar;
    [SerializeField] private int clientStar;
    [SerializeField] private NetworkVariable<EHandType> hostHand = new NetworkVariable<EHandType>(EHandType.None);
    [SerializeField] private NetworkVariable<EHandType> clientHand = new NetworkVariable<EHandType>(EHandType.None);
    #endregion

    protected void Awake()
    {
        GameManager.instance = this;
        //base.Awake();
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }

        //csv.OnInit();
        //userData?.OnInitData();

        //ChangeState(GameState.MainMenu);
        if (isActive)
        {
            UIManager.Ins.OpenUI<MainMenuCanvas>();
        }
    }

    //public static void ChangeState(GameState state)
    //{
    //    gameState = state;
    //}

    //public static bool IsState(GameState state)
    //{
    //    return gameState == state;
    //}

    public void GetStart()
    {
        allChoosed = false;
        hostStar = 0;
        clientStar = 0;
        hostHand.Value = EHandType.None;
        clientHand.Value = EHandType.None;
    }

    public void ClickedOnHandButton(EHandType eHandType)
    {
        if (IsHost)
        {
            hostHand.Value = eHandType;
            CheckResult();
        }
        else
        {
            SubmitHandToServerRpc(eHandType);
        }
    }

    public EHandType GetHostHand()
    {
        return hostHand.Value;
    }

    public EHandType GetClientHand()
    {
        return clientHand.Value;
    }

    [ServerRpc(RequireOwnership = false)]
    private void SubmitHandToServerRpc(EHandType eHandType)
    {
        clientHand.Value = eHandType;
        CheckResult();
        allChoosed |= true;
    }


    private void CheckResult()
    {
        if (hostHand.Value != EHandType.None && clientHand.Value != EHandType.None)
        {
            Debug.Log($"Host chọn: {hostHand.Value}, Client chọn: {clientHand.Value}");

            if (hostHand.Value == clientHand.Value)
            {
                Debug.Log("Kết quả: Hòa!");
            }
            else if ((hostHand.Value == EHandType.Rock && clientHand.Value == EHandType.Scissor) ||
                     (hostHand.Value == EHandType.Paper && clientHand.Value == EHandType.Rock) ||
                     (hostHand.Value == EHandType.Scissor && clientHand.Value == EHandType.Paper))
            {
                Debug.Log("Host thắng!");
                hostStar++;
            }
            else
            {
                Debug.Log("Client thắng!");
                clientStar++;
            }

            // Reset để chơi ván mới
            hostHand.Value = EHandType.None;
            clientHand.Value = EHandType.None;
        }
    }
}

