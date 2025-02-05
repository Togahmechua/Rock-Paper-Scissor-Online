using UnityEngine;
using UnityEngine.UI;

public class OnlineCanvas : UICanvas
{
    [Header("Button")]
    [SerializeField] private Button rockBtn;
    [SerializeField] private Button paperBtn;
    [SerializeField] private Button scissorBtn;

    [Header("Image")]
    [SerializeField] private Image localHand;
    [SerializeField] private Image remoteHand;

    [Header("Sprite")]
    [SerializeField] private Sprite rockSpr;
    [SerializeField] private Sprite paperSpr;
    [SerializeField] private Sprite scissorSpr;

    private Animator anim;

    private void OnEnable()
    {
        // Khoi dong lai
        GameManager.Ins.GetStart();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

        rockBtn.onClick.AddListener(() => GameManager.Ins.ClickedOnHandButton(EHandType.Rock));
        paperBtn.onClick.AddListener(() => GameManager.Ins.ClickedOnHandButton(EHandType.Paper));
        scissorBtn.onClick.AddListener(() => GameManager.Ins.ClickedOnHandButton(EHandType.Scissor));
    }

    private void Update()
    {
        if (anim != null && GameManager.Ins.allChoosed)
        {
            anim.Play(CacheString.TAG_ROCKPAPERSCISSOR);
        }
    }

    private Sprite SetHandSpr(EHandType eHandType)
    {
        switch (eHandType)
        {
            case EHandType.None:
                return null;

            case EHandType.Rock:
                return rockSpr;

            case EHandType.Paper:
                return paperSpr;

            case EHandType.Scissor:
                return scissorSpr;

            default:
                return null;
        }
    }

    #region Animation Event
    public void SetHand()
    {
        // Cập nhật tay của local player (host)
        localHand.sprite = SetHandSpr(GameManager.Ins.GetHostHand());

        // Cập nhật tay của remote player (client)
        remoteHand.sprite = SetHandSpr(GameManager.Ins.GetClientHand());
    }

    public void OnAnimationComplete()
    {
        GameManager.Ins.GetStart();
    }
    #endregion
}
