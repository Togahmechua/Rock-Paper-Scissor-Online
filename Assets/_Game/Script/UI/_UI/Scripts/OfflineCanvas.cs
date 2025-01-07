using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineCanvas : UICanvas
{
    [SerializeField] private Image timerBar;
    [SerializeField] private Text[] scoreTxt;
    [SerializeField] private Button[] playerHandBtn;
    [SerializeField] private Sprite[] handSpr;
    [SerializeField] private Image playerHandImg;
    [SerializeField] private Image botHandImg;

    private Animator anim;
    private EHandType botHandType;
    private EHandType playerHandType;
    private float availableTime = 25f;
    private float remainingTime;
    private bool isTimerRunning;
    private int score;

    private void OnEnable()
    {
        remainingTime = availableTime;
        isTimerRunning = false;
        score = 0;
        SetScore();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        for (int i = 0; i < playerHandBtn.Length; i++)
        {
            int index = i;
            playerHandBtn[i].onClick.AddListener(() => HandBtn(index));
        }
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

    private void HandBtn(int index)
    {
        anim.Play(CacheString.TAG_PLAYERHAND);
        if (index >= 0 && index < handSpr.Length)
        {
            playerHandImg.sprite = handSpr[index];
            playerHandType = (EHandType)index;
        }
        else
        {
            Debug.LogWarning("Index không hợp lệ!");
        }
    }

    private void SetRandomBotHand()
    {
        int rand = Random.Range(0, handSpr.Length);
        botHandImg.sprite = handSpr[rand];
        botHandType = (EHandType)rand;
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
            Debug.Log("Kết quả: Bot thắng!");
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
    Rock = 0,
    Paper = 1,
    Scissor = 2
}
