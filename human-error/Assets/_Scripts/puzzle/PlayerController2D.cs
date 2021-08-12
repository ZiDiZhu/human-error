using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    private PlayerMovement2D controls;

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;

    public AudioSource sfx_move;
    public AudioSource sfx_cannotmove;

    private void Awake()
    {
        controls = new PlayerMovement2D();
        sfx_move = GetComponent<AudioSource>();
    }
    void Start()
    {
        controls.main.movement.performed += ctx => Move(ctx.ReadValue<Vector2>()); //ctx == context
        //passes the event to move()
        
    }

    void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            sfx_move.Play();
        }
        else
        {
            sfx_cannotmove.Play();
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        //direction itself is vector2 so it has to be a vector3 first

        
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    
}
