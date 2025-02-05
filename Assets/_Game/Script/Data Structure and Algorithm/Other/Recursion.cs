using System.Collections.Generic;
using UnityEngine;

public class Recursion : MonoBehaviour
{
    [SerializeField] private int n = 5;

    //private Dictionary<int, int> memo = new Dictionary<int, int>();
    private int[] memoArr;

    private void Start()
    {
        if (n <= 2)
        {
            Debug.Log("N phai lon hon 2");
        }

        memoArr = new int[n + 1];

        //Khởi tạo giá trị chưa tính
        for (int i = 0; i <= n; i++)
        {
            memoArr[i] = -1;
        }


        try
        {
            Debug.Log(F(n));
        }
        catch (System.ArgumentException e)
        {
            {
                Debug.LogError(e.Message);
            }
        }
    }


    #region Fibonacci - Brute force
    /*    private int F(int x)
        {
            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            return F(x - 1) + F(x - 2);
        }*/
    #endregion

    #region Fibonacci - Brute force

    //Cách 1 sử dụng Dictionary
    /* private int F(int x)
     {
         if (x == 0)
             return 0;

         if (x == 1)
             return 1;

         // Kiểm tra nếu đã tính trước đó
         if (memo.ContainsKey(x))
             return memo[x];

         memo[x] = F(x - 1) + F(x - 2);
             return memo[x];
     }*/

    //Cách 2 sử dụng Array
    private int F(int x)
    {
        if (x == 0)
            return 0;

        if (x == 1)
            return 1;

        // Kiểm tra nếu đã tính trước đó
        if (memoArr[x] != -1)
            return memoArr[x];

        memoArr[x] = F(x - 1) + F(x - 2);
        return memoArr[x];
    }
    #endregion
}
