using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineCanvas : UICanvas
{
    [Header("Image && Text")]
    [SerializeField] private Image timerBar;
    [SerializeField] private Text[] scoreTxt;
    [SerializeField] private Image playerHandImg;
    [SerializeField] private Image botHandImg;

    [Header("Button")]
    [SerializeField] private Button rockBtn;
    [SerializeField] private Button paperBtn;
    [SerializeField] private Button scissorBtn;

    [Header("Sprites")]
    [SerializeField] private Sprite rockSpr;
    [SerializeField] private Sprite paperSpr;
    [SerializeField] private Sprite scissorSpr;

    private Dictionary<EHandType, Sprite> handDetails = new Dictionary<EHandType, Sprite>();
    private List<EHandType> filteredValues;

    private Animator anim;
    private EHandType botHandType;
    private EHandType playerHandType;
    private float availableTime = 25f;
    private float remainingTime;
    private bool isTimerRunning;
    private int score;

    private void OnEnable()
    {
       OnGameStart();
    }

    void Start()
    {
        handDetails.Add(EHandType.Rock, rockSpr);
        handDetails.Add(EHandType.Paper, paperSpr);
        handDetails.Add(EHandType.Scissor, scissorSpr);
        InitializeHandTypeList();

        anim = GetComponent<Animator>();
        rockBtn.onClick.AddListener(() =>
        {
            HandBtn(EHandType.Rock);
        });

        paperBtn.onClick.AddListener(() =>
        {
            HandBtn(EHandType.Paper);
        });

        scissorBtn.onClick.AddListener(() =>
        {
            HandBtn(EHandType.Scissor);
        });
    }

    private void Update()
    {
        if (remainingTime <= 0)
        {
            UIManager.Ins.CloseUI<OfflineCanvas>();
            UIManager.Ins.OpenUI<WinCanvas>().SetScore(score);
            return;
        }
        RunTimerBar();
    }

    private void OnGameStart()
    {
        //Reset
        playerHandType = EHandType.None;
        botHandType = EHandType.None;
        remainingTime = availableTime;
        isTimerRunning = false;
        score = 0;
        SetScore();
    }

    private void RunTimerBar()
    {
        if (!isTimerRunning)
            return;
        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Clamp(remainingTime, 0f, availableTime);
        timerBar.fillAmount = remainingTime / availableTime;
    }

    public void AbleToRunTimerBar()
    {
        isTimerRunning = true;
    }

    private void HandBtn(EHandType eHandType)
    {
        anim.Play(CacheString.TAG_PLAYERHAND);
     
       if (handDetails.TryGetValue(eHandType, out Sprite spr))
       {
            playerHandImg.sprite = spr;
            playerHandType = eHandType;
       }
    }

    private void SetRandomBotHand()
    {
        EHandType bHandType = GetHandTypeList();

        if (handDetails.TryGetValue(bHandType, out Sprite spr))
        {
            botHandImg.sprite = spr;
            botHandType = bHandType;
        }
    }

    private void InitializeHandTypeList()
    {
        // Lấy tất cả giá trị của enum
        EHandType[] values = (EHandType[])System.Enum.GetValues(typeof(EHandType));

        // Tạo danh sách và loại bỏ None
        filteredValues = new List<EHandType>(values);
        filteredValues.Remove(EHandType.None);
    }

    private EHandType GetHandTypeList()
    {
        if (filteredValues == null || filteredValues.Count == 0)
        {
            Debug.LogWarning("Danh sách filteredValues chưa được khởi tạo!");
            return EHandType.None;
        }

        int randomIndex = Random.Range(0, filteredValues.Count);
        return filteredValues[randomIndex];
    }

    private void SetScore()
    {
        for (int i = 0; i < scoreTxt.Length; i++)
        {
            scoreTxt[i].text = "Score : " + score.ToString();
        }
    }

    public void CheckResult()
    {
        if (playerHandType == botHandType)
        {
            Debug.Log("Kết quả: Hòa!");
            remainingTime += 1f;
        }
        else if ((playerHandType == EHandType.Rock && botHandType == EHandType.Scissor) ||
                 (playerHandType == EHandType.Paper && botHandType == EHandType.Rock) ||
                 (playerHandType == EHandType.Scissor && botHandType == EHandType.Paper))
        {
            Debug.Log("Kết quả: Bạn thắng!");
            remainingTime += 2f;
            score += 1;
            SetScore();
        }
        else
        {
            Debug.Log("Kết quả: Bạn thua!");
            remainingTime -= 1f;
            if (score >= 1)
            {
                score -= 1;
            }
            SetScore();
        }

        anim.Play(CacheString.TAG_OFFLINECANVASBOTHAND);
    }
}

public enum EHandType
{
    None = 0,
    Rock = 1,
    Paper = 2,
    Scissor = 3
}
