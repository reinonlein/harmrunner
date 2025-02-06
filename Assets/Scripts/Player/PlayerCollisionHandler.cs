using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    LevelGenerator levelGenerator;

    const string hitString = "Hit";

    float coolDownTimer = 0f;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        coolDownTimer += Time.deltaTime;
    }


    void OnCollisionEnter(Collision other)
    {
        if (coolDownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        coolDownTimer = 0f;
    }
}
