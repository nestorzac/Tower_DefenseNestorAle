using UnityEngine;
using UnityEngine.Events;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField]
    private int _coins = 0;

    [SerializeField]
    private UnityEvent<int> _onCoinsUpdated;

    [SerializeField]
    private UnityEvent _onPurchaseSuccess;
    [SerializeField]
    private UnityEvent _onPurchaseFailure;

    public void AddCoins(int amount)
    {
        _coins += amount;
        _onCoinsUpdated?.Invoke(_coins);
    }

    public void SetCoins(int amount)
    {
        _coins = amount;
        _onCoinsUpdated?.Invoke(_coins);
    }

    public void SubstractCoins(int amount)
    {
        _coins -= amount;
        _onCoinsUpdated?.Invoke(_coins);
    }

    public bool BuyObject(int cost)
    {
        if (_coins >= cost)
        {
            _onPurchaseSuccess?.Invoke();
            SubstractCoins(cost);
            return true;
        }
        _onPurchaseFailure?.Invoke();
        return false;
    }
}
