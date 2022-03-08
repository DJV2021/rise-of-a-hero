using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))][RequireComponent(typeof(SpriteRenderer))]
public class Door2D : MonoBehaviour
{
    private Collider2D _collider;

    [SerializeField]
    private Sprite openSprite;
    [SerializeField]
    private Sprite closedSprite;

    private SpriteRenderer _renderer;

    private bool closed;
    [SerializeField]
    private bool closedOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();

        closed = closedOnStart;
        
        if(closed)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        _collider.enabled = false;
        _renderer.sprite = openSprite;
    }
    public void CloseDoor()
    {
        _collider.enabled = true;
        _renderer.sprite = closedSprite;
    }
}
