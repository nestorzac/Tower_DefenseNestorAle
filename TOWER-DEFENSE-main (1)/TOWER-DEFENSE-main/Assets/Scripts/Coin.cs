using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;


public class Coin : MonoBehaviour
{
    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _disappearAnimationName = "CoinDisappear";

    [SerializeField]
    private Animator _animator;
    [SerializeField]

    private float _timeToDisappear = 3f;

    [SerializeField]
    private UnityEvent _onCoinCollected;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        _collider.enabled = true;
        StartCoroutine(AppearCoroutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Collect()
    {
        StartCoroutine(DisappearCoroutine());
        _onCoinCollected?.Invoke();
    }
    private IEnumerator AppearCoroutine()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_timeToDisappear);
        StartCoroutine(DisappearCoroutine());
    }

    private IEnumerator DisappearCoroutine()
    {
        _collider.enabled = false;
        _animator.Play(_disappearAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
}
