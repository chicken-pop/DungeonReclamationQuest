using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    /// <summary>
    /// ゲームオーバー用のUI
    /// </summary>
    [SerializeField]
    private GameObject gameOverModal;
    private GameObject gameOverModalInstance = null;

    /// <summary>
    /// ゲームオーバー用のUI
    /// </summary>
    [SerializeField]
    private GameObject gameClearModal;
    private GameObject gameClearModalInstance = null;

    [SerializeField] private TextMeshProUGUI levelText;



    public void InitializeUI()
    {
        playerHearts.Clear();
        enemyAttackGauges.Clear();

        if(PlayerHeartRoot.childCount > 0)
        {
            for (int i = 0; i < PlayerHeartRoot.childCount; i++)
            {
                Destroy(PlayerHeartRoot.GetChild(i).gameObject);
            }
        }

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
            enemyAttackGauges.Add(enemyGauge.GetComponent<Image>());
        }

        levelText.text = $"Level:{MainGameSceneConfigManager.Instance.Level}";
    }

    private void LateUpdate()
    {
        if (MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame)
        {
            return;
        }

        //敵がうまったら
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
                if (playerHearts[playerhitPointCount - count] != null)
                {
                    playerHearts[playerhitPointCount - count].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
                }
            }

            playerhitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
        }
    }

    /// <summary>
    /// ゲームオーバー用のモーダルを表示する
    /// </summary>
    public void ShowGameOverModal(Transform modalCanvas)
    {
        if (gameOverModal != null && gameOverModalInstance == null)
        {
            gameOverModalInstance = Instantiate(gameOverModal, modalCanvas);
            gameOverModal.SetActive(true);
        }

        if (gameOverModalInstance != null)
        {
            gameOverModalInstance.SetActive(true);
        }
    }

    public void ShowGameClearModal(Transform modalCanvas)
    {
        if (gameClearModal != null && gameClearModalInstance == null)
        {
            gameClearModalInstance = Instantiate(gameClearModal, modalCanvas);
            gameClearModal.SetActive(true);
        }

        if (gameClearModalInstance != null)
        {
            gameClearModalInstance.SetActive(true);
        }
    }

}
