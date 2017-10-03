using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Control game rules: generate blocks, detect all blocks dropped from platform, etc.
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>Player</summary>
    [SerializeField]
    GameObject m_player;

    /// <summary>block obstacles</summary>
    [SerializeField] GameObject m_blockPrefab;

    /// <summary>How many blocks to be generated.</summary>
    [SerializeField] int m_blockCount = 100;

    /// <summary>Blocks will be generated as child object of this.</summary>
    [SerializeField] GameObject m_blockRoot;

    /// <summary>Counter how many blocks on the platform.</summary>
    [SerializeField] Text m_txtBlockCounter;

    /// <summary>Message dialog with restart button.</summary>
    [SerializeField]
    RectTransform m_dialog;

    /// <summary>Message field on message dialog with restart button.</summary>
    [SerializeField]
    Text m_messageText;

    /// <summary>TextField to show timer.</summary>
    [SerializeField]
    Text m_txtTimer;

    /// <summary>When it is false, game should be stopped.</summary>
    bool m_isPlaying;

    /// <summary>Timer</summary>
    float m_timer;

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        TickTimer();
        CheckIsPlaying();
    }

    /// <summary>
    /// Restart game by loading current scene again.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Tick timer. Called in Update().
    /// </summary>
    void TickTimer()
    {
        if (m_txtTimer && m_isPlaying)
        {
            m_timer += Time.deltaTime;
            m_txtTimer.text = "Time: " + m_timer.ToString("F");
        }
    }

    /// <summary>
    /// Called on start game.
    /// </summary>
    void Initialize()
    {
        m_dialog.gameObject.SetActive(false);
        GenerateBlocks();
        m_isPlaying = true;
    }

    /// <summary>
    /// Check if play is going or not. Stop timer and show dialog when all blocks are swept or player falls off platform.
    /// </summary>
    void CheckIsPlaying()
    {
        // Count how many blocks on the platform. If zero, game is cleared.
        if (m_blockRoot)
        {
            int blockCount = m_blockRoot.transform.childCount;

            if (m_txtBlockCounter)
                m_txtBlockCounter.text = "Blocks: " + blockCount;

            if (blockCount < 1 && m_isPlaying)
            {
                m_isPlaying = false;
                ShowDialog("Clear!");
            }
        }

        // Check if the player is on the platform. If not, game is over.
        if (m_isPlaying)
        {
            if (m_player.transform.position.y < 0)
            {
                m_isPlaying = false;
                ShowDialog("Miss!");
            }
        }
    }

    /// <summary>
    /// Show dialog with message.
    /// </summary>
    /// <param name="message"></param>
    void ShowDialog(string message)
    {
        m_messageText.text = message;
        m_dialog.gameObject.SetActive(true);
    }

    /// <summary>
    /// Generate blocks. This procedure won't stop gameplay.
    /// </summary>
    void GenerateBlocks()
    {
        if (m_blockPrefab)
            StartCoroutine(GenerateBlocksImpl(m_blockCount, m_blockPrefab));
        else
            Debug.LogError("Block Prefab configuration is missing for GameController.");
    }

    /// <summary>
    /// Implementation for generating blocks.
    /// </summary>
    /// <param name="blockCount"></param>
    /// <param name="block"></param>
    /// <returns></returns>
    IEnumerator GenerateBlocksImpl(int blockCount, GameObject block)
    {
        for (int i = 0; i < blockCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-6, 6), Random.Range(4, 10), Random.Range(-6, 6));

            if (m_blockRoot)
                Instantiate(block, pos, Quaternion.identity, m_blockRoot.transform);
            else
                Instantiate(block, pos, Quaternion.identity);

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
