using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class GameButton : MonoBehaviour
{
    [SerializeField]
    private UnityEvent activationMethodCalls;

    [SerializeField]
    private Sprite unpressedSprite;
    [SerializeField]
    private Sprite pressedSprite;

    private SpriteRenderer _renderer;
    
    [SerializeField]
    private Collider2D trigger;


    // Start is called before the first frame update
    void Start()
    {
        
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = unpressedSprite;
    }

    public void PressButton()
    {
        _renderer.sprite = pressedSprite;
        if(trigger != null) trigger.enabled = false;
        activationMethodCalls.Invoke();
    }

    private void OnTriggerEnter2D()
    {
        PressButton();
    }
}
