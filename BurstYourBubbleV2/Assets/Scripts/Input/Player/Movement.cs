using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Range(1, 10)]
    public float playerSpeed;

    [Range(0, 50)]
    public int playerAnimationFramerate;

    private int animationIndex;
    private int frameIndex;

    private bool horiz;

    private void Start()
    {
        animationIndex = 0;
        frameIndex = 0;
        horiz = false;
    }

    private void FixedUpdate()
    {
        if(PlayerPrefs.GetString("gameState") == "Awake")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                UpdatePosition(Vector2.up);
                horiz = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                UpdatePosition(Vector2.left);
                horiz = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                UpdatePosition(Vector2.down);
                horiz = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                UpdatePosition(Vector2.right);
                horiz = true;
            }
            else
            {
                UpdatePosition(Vector2.zero);
            }
        }
    }
    private void UpdatePosition(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * playerSpeed;

        if (direction == Vector2.right)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.left)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        AnimatePlayer(direction);
    }

    private void AnimatePlayer(Vector2 direction)
    {
        string directory = "";

        if (direction == Vector2.up)
        {
            directory = "Player/player_u";
        }
        else if (direction == Vector2.left)
        {
            directory = "Player/player_r";
        }
        else if (direction == Vector2.down)
        {
            directory = "Player/player_d";
        }
        else if (direction == Vector2.right)
        {
            directory = "Player/player_r";
        }
        else if (direction == Vector2.zero && !horiz)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/vert_idle");
            return;
        }
        else if(direction == Vector2.zero && horiz)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/idle_right");
            return;
        }

        animationIndex++;

        if (animationIndex >= 50 / playerAnimationFramerate)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(directory);

            GetComponent<SpriteRenderer>().sprite = sprites[frameIndex];
            frameIndex++;

            if(frameIndex == 8)
            {
                frameIndex = 0;
            }

            animationIndex = 0;
        }
    }
}