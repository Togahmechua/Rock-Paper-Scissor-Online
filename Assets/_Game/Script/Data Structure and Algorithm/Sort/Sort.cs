using System;
using UnityEngine;

public class Sort : MonoBehaviour
{
    private int[] arr = { 5, 8, 9, 10, 15, 1, 3, -2 };

    void Start()
    {
        Debug.Log("Mảng trước khi sắp xếp: " + string.Join(", ", arr));
        //BubbleSort();
        //InsertionSort();
        SelectionSort();
        Debug.Log("Mảng sau khi sắp xếp: " + string.Join(", ", arr));   
    }

    #region BubbleSort
    // Lặp qua danh sách, so sánh từng cặp phần tử và hoán đổi nếu cần.
    // Lặp lại quá trình cho đến khi danh sách được sắp xếp.
    /*private void BubbleSort()
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }*/
    #endregion

    #region SelectionSort
    // Tìm phần tử nhỏ nhất trong danh sách và đưa nó về đầu.
    // Lặp lại quá trình cho phần còn lại của danh sách.
    /*private void SelectionSort()
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            // Tìm vị trí giá trị nhỏ nhất trong đoạn từ i..n
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            //Hoán đổi vị trí
            (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
        }
    }*/
    #endregion

    #region InsertionSort
    // Lấy từng phần tử và chèn vào đúng vị trí trong danh sách đã sắp xếp.

    private void SelectionSort()
    {
        int n = arr.Length;

        //Bắt đầu từ i = 1, vì phần tử đầu tiên (arr[0]) mặc định được coi là đã sắp xếp.
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j]; // Dịch chuyển phần tử sang phải
                j--;
            }

            arr[j] = key;
        }
    }
    #endregion
}
