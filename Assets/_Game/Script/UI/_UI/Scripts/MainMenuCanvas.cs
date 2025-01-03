using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvas : UICanvas
{
    [SerializeField] private Button startBtn;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        startBtn.onClick.AddListener(StartBtn);
    }

    private void StartBtn()
    {
        anim.Play(CacheString.TAG_START);
    }

    public void NextToSelectModeCanvas()
    {
        UIManager.Ins.CloseUI<MainMenuCanvas>();
        UIManager.Ins.OpenUI<SelectModeCanvas>();
    }
}