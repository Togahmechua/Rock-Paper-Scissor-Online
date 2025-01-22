using System;
using UnityEngine;
using UnityEngine.UI;

public class OnlineCanvas : UICanvas
{
    [SerializeField] private Button rockBtn;
    [SerializeField] private Button paperBtn;
    [SerializeField] private Button scissorBtn;

    private void Start()
    {
        GameManager.Ins.OnClickedHandButton += GameManager_OnClickedHandButton;
    }

    private void GameManager_OnClickedHandButton(object sender, GameManager.OnClickedHandButtonEventArgs e)
    {
            }
}
