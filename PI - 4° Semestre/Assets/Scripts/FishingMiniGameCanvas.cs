using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGameCanvas : MonoBehaviour
{
    [SerializeField] Transform teto;
    [SerializeField] Transform chao;

    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f; // o quanto o peixe vai dar de progresso por estar na area do gancho
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f; // o qunato tu perde de progresso por o peixe fugir do gancho

    [SerializeField] Transform progressContainer;

    bool pause = false;

    public animationController falarSeGanhaOuPerde;

    private void Start()
    {
        falarSeGanhaOuPerde = GameObject.FindGameObjectWithTag("Player").GetComponent<animationController>();
    }

    private void Update()
    {
        if (pause)
        {
            return;
        }
        Fish();
        Hook();
        ProgressCheck();
    }

    private void ProgressCheck()
    {
        Vector3 ls = progressContainer.localScale;
        ls.y = hookProgress;
        progressContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;
        }

        if(hookProgress >= 1f)
        {
            Win();
        }

        if(hookProgress <= 0f)
        {
            Lose();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    private void Lose()
    {
        pause = true;
        falarSeGanhaOuPerde.ResultadoPesca(false);
    }

    private void Win()
    {
        pause = true;
        falarSeGanhaOuPerde.ResultadoPesca(true);
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(chao.position, teto.position, hookPosition);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            //aqui ele mostra de quanto em quanto tempo o peixe muda de direção
            fishTimer = UnityEngine.Random.value * timerMultiplicator;


            //aqui para que direção ira mover
            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(chao.position, teto.position, fishPosition);
    }

}
