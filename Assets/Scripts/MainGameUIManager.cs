using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    public Image PlayerHeartImage;

    private List<GameObject> playerHearts = new List<GameObject>();

    public RectTransform PlayerHeartRoot;

    private int playerhitPointCount;

    public Image EnemyAttackGauge;

    private List<Image> enemyAttackGauges = new List<Image>();

    public void InitializeUI()
    {
        playerhitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;

        for (int i = 0; i < playerhitPointCount; i++)
        {
            var playerHeart = Instantiate(PlayerHeartImage, PlayerHeartRoot);
            playerHearts.Add(playerHeart.gameObject);
        }
        Debug.Log(MainGameUmpire.Instance.GetMainGameEnemies.Count);
        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            var enemyGauge = Instantiate(EnemyAttackGauge.gameObject, this.transform);
            enemyGauge.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, MainGameUmpire.Instance.GetMainGameEnemies[i].transform.position);
            Debug.Log(enemyGauge);
            enemyAttackGauges.Add(enemyGauge.GetComponent<Image>());
        }
    }

    private void LateUpdate()
    {
        if (MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame)
        {
            return;
        }

        //“G‚ª‚¤‚Ü‚Á‚½‚ç
        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            if (!MainGameUmpire.Instance.GetMainGameEnemies[i].gameObject.activeSelf)
            {
                if (enemyAttackGauges[i].gameObject.activeSelf)
                {
                    enemyAttackGauges[i].gameObject.SetActive(false);
                }
                break;
            }

            if (enemyAttackGauges[i].gameObject.activeSelf)
            {
                var normalizedValue = Mathf.InverseLerp(0f, 3f, MainGameUmpire.Instance.GetMainGameEnemies[i].GetEnemyAttackTime);
                enemyAttackGauges[i].fillAmount = normalizedValue;
            }
        }

        if (playerhitPointCount != (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint)
        {
            var countDiff = playerhitPointCount - (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
            var count = 0;

            for (int i = 0; i < countDiff; i++)
            {
                count++;
                if(playerHearts[playerhitPointCount - count] != null)
                {
                    playerHearts[playerhitPointCount - count].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
                }
            }

            playerhitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
        }
    }

}
