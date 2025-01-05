using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectModeCanvas : UICanvas
{
    [SerializeField] private Button offlineBtn;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        offlineBtn.onClick.AddListener(OfflineBtn);
    }

    private void OfflineBtn()
    {
        anim.Play(CacheString.TAG_MODEOFFLINE);
    }

    public void NextToOfflineCanvas()
    {
        UIManager.Ins.CloseUI<SelectModeCanvas>();
        UIManager.Ins.OpenUI<OfflineCanvas>();
    }
}
