using System;
using UnityEngine;

public class Sort : MonoBehaviour
{
    private int[] arr = { 5, 8, 9, 10, 15, 1, 3, -2 };

    void Start()
    {
        BubbleSort();
        Debug.Log("Mảng sau khi sắp xếp: " + string.Join(", ", arr));   
    }

    #region BubbleSort
    private void BubbleSort()
    {
        int n = arr.Length;
        
        for (int i = 0; i < n - 1; i++)
        {
            for(int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    #endregion
}
