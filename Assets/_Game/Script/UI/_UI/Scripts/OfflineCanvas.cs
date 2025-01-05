using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfflineCanvas : UICanvas
{
    [SerializeField] private Button[] playerHandBtn;
    [SerializeField] private Sprite[] handSpr;
    [SerializeField] private Image playerHandImg;
    [SerializeField] private Image botHandImg;

    private Animator anim;
    private EHandType botHandType;
    private EHandType playerHandType;

    private void OnEnable()
    {
        SetRandomBotHand();
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


    public void CheckResult()
    {
        if (playerHandType == botHandType)
        {
            Debug.Log("Kết quả: Hòa!");
        }
        else if ((playerHandType == EHandType.Rock && botHandType == EHandType.Scissor) ||
                 (playerHandType == EHandType.Paper && botHandType == EHandType.Rock) ||
                 (playerHandType == EHandType.Scissor && botHandType == EHandType.Paper))
        {
            Debug.Log("Kết quả: Bạn thắng!");
        }
        else
        {
            Debug.Log("Kết quả: Bot thắng!");
        }
    }
}

public enum EHandType
{
    Rock = 0,
    Paper = 1,
    Scissor = 2
}
