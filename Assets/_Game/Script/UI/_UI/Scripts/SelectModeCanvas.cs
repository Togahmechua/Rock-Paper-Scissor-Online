using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectModeCanvas : UICanvas
{
    [SerializeField] private Button offlineBtn;
    [SerializeField] private Button onlineBtn;

    private Animator anim;
    private int check;

    private void OnEnable()
    {
        check = 0;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();

        offlineBtn.onClick.AddListener(() =>
        {
            anim.Play(CacheString.TAG_MODE);
            check = 1;
            Invoke(nameof(NextToSelectedMode), anim.GetCurrentAnimatorStateInfo(0).length);
        });
        onlineBtn.onClick.AddListener(() =>
        {
            anim.Play(CacheString.TAG_MODE);
            check = 2;
            Invoke(nameof(NextToSelectedMode), anim.GetCurrentAnimatorStateInfo(0).length);
        });
    }

    private void NextToSelectedMode()
    {
        UIManager.Ins.CloseUI<SelectModeCanvas>();

        if (check == 1)
        {
            UIManager.Ins.OpenUI<OfflineCanvas>();
        }
        else if (check == 2)
        {
            UIManager.Ins.OpenUI<HostCanvas>();
        }
    }
}
