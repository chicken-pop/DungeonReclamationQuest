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

    private List<Image> enemyAttackGauges =new List<Image>();

    public void InitializeUI()
    {
        playerhitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;

        for (int i = 0; i < playerhitPointCount; i++)
        {
            var playerHeart = Instantiate(PlayerHeartImage,PlayerHeartRoot);
            playerHearts.Add(playerHeart.gameObject);
        }
        Debug.Log( MainGameUmpire.Instance.GetMainGameEnemies.Count);
        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            var enemyGauge = Instantiate(EnemyAttackGauge.gameObject, this.transform);
            enemyGauge.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main,MainGameUmpire.Instance.GetMainGameEnemies[i].transform.position);
            Debug.Log(enemyGauge);
            enemyAttackGauges.Add(enemyGauge.GetComponent<Image>());
        }
    }

    private void Update()
    {
        if(MainGameSceneStateManager.Instance.GameSceneStates < MainGameSceneStateManager.GameSceneState.Start)
        {
            return;
        }

        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            var normalizedValue = Mathf.InverseLerp(0f, 3f, MainGameUmpire.Instance.GetMainGameEnemies[i].GetEnemyAttackTime);
            enemyAttackGauges[i].fillAmount = normalizedValue;
        }

        if(playerhitPointCount != (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint)
        {
            Debug.Log((int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint);
            playerHearts[playerhitPointCount -1].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
            playerhitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
        }
    }

}
