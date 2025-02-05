using UnityEngine;

public class Recursion : MonoBehaviour
{
    [SerializeField] private int n = 5;

    private void Start()
    {
        if (n <= 2)
        {
            Debug.Log("N phai lon hon 2");
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
    private int F(int x)
    {
        if (x == 0)
            return 0;

        if (x == 1) 
            return 1;

        return F(x - 1) + F(x - 2); 
    }
    #endregion
}
