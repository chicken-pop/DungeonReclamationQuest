using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainGameEnemyTimer))]
[RequireComponent(typeof(MainGameEnemyParameterManager))]
public class MainGameEnemy : MonoBehaviour
{
    private MainGameEnemyTimer mainGameEnemyTimer => GetComponent<MainGameEnemyTimer>();
    private MainGameEnemyParameterManager mainGameEnemyParameterManager => GetComponent<MainGameEnemyParameterManager>();

    public Polyomino ParentPolyomino = null;

    public float GetEnemyAttackTime
    {
        get { return mainGameEnemyTimer.enemyTimer; }
    }
    private void Awake()
    {
        MainGameUmpire.Instance.SetMainGameEnemy = this;
        ParentPolyomino = transform.parent.GetComponent<Polyomino>();
    }

    public void EnemyAttack()
    {
        //�v���C���[�̃X�N���v�g�ɃA�N�Z�X���A�_���[�W��^����
        MainGameUmpire.Instance.GetMainGamePlayer.Damage(mainGameEnemyParameterManager.GetEnemyAttackPoint);
    }

    private void Update()
    {
        //MainGame����Ȃ��ꍇ�̓��^�[��
        if(MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame)
        {
            return;
        }

        if (ParentPolyomino.IsBuried)
        {
            this.gameObject.SetActive(false);
        }

        if (mainGameEnemyTimer.enemyTimer < 0)
        {
            EnemyAttack();

            mainGameEnemyTimer.enemyTimer = 3f;
        }
    }
}
