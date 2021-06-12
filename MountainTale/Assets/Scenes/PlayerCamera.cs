using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    private float shakeLength;
    private float shakePower;
    private float fadeTime;

    private bool camerMove;

    private void Start()
    {
        shakeLength = 0;
        shakePower = 0;
        fadeTime = 0;
        camerMove = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ShakingCamera(0.5f, 0.2f);
        }

        transform.position = new Vector3(player.transform.position.x,
                                         player.transform.position.y,
                                         player.transform.position.z - 10);

        if (shakeLength > 0)
        {
            shakeLength -= Time.deltaTime;

            float shakePowerX = Random.Range(-1.0f, 1.0f) * shakePower;
            float shakePowerY = Random.Range(-1.0f, 1.0f) * shakePower;

            transform.position += new Vector3(shakePowerX, shakePowerY, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0, fadeTime * Time.deltaTime);
        }
    }

    private void ShakingCamera(float length, float power)
    {
        shakeLength = length;
        shakePower = power;
        fadeTime = power;
    }
}
