using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum Direction
    {
        LEFT = -1,
        RIGHT = 1
    }

    public const float TIMEOUT = 7.0f;

    public Direction direction;

    public float speed = 1f;
    readonly Vector3 _dir = new Vector3(389f, -40f, 0f).normalized;
    Vector3 Velocity => _dir * (int)direction * speed;

    Vector3 initialPosition;
    public static float openDuration;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        openDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkGameOver();
    }

    void Move()
    {
        if (GameData.HasEnemy())
        {
            transform.position += Velocity * Time.deltaTime;
            openDuration += Time.deltaTime;
        }
        else
        {
            transform.position = initialPosition;
            openDuration = 0;
        }
    }

    void checkGameOver()
    {
        if (openDuration > TIMEOUT)
        {
            GameController.ShowResult(GameData.Result.GAMEOVER);
        }
    }

}
