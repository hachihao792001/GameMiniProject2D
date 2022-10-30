using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoSingleton<TutorialManager>
{
    public static bool IsTutorialShown
    {
        get
        {
            return PlayerPrefs.GetInt("IsTutorialShown", 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("IsTutorialShown", value ? 1 : 0);
        }
    }

    [SerializeField] List<DialogInfo> _dialogInfos;

    public bool isPlayingTutorial;
    [SerializeField] TutorialHighlightController _tutorialHighlight;
    [SerializeField] DialogController _dialogController;

    [SerializeField] Button _battleButton;
    [SerializeField] Button _firstStageButton;

    [SerializeField] GameObject _dummyEnemyPrefab;
    [SerializeField] GameObject _meleeEnemyPrefab;

    void Start()
    {
        if (!IsTutorialShown)
        {
            StartCoroutine(tutorialCoroutine());
        }
    }

    IEnumerator tutorialCoroutine()
    {
        isPlayingTutorial = true;
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Home");

        yield return PlayDialog(Dialog.JustInTime);
        yield return PlayDialog(Dialog.Teach);
        yield return PlayDialog(Dialog.DropFirstArea);

        yield return _tutorialHighlight.Show(_battleButton.transform);
        _battleButton.onClick.Invoke();
        yield return _tutorialHighlight.Show(_firstStageButton.transform);
        _firstStageButton.onClick.Invoke();

        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Game");
        GameController.Instance.PauseButton.gameObject.SetActive(false);
        yield return PlayDialog(Dialog.Move);
        yield return new WaitUntil(() => GameController.Instance.Player.PlayerMoving.IsMoving);
        yield return new WaitForSeconds(2f);
        GameController.Instance.Player.PlayerMoving.LockJoyStick();

        yield return PlayDialog(Dialog.Approach);
        GameController.Instance.Player.PlayerMoving.UnlockJoyStick();
        GameObject dummyEnemy = Instantiate(_dummyEnemyPrefab, GameController.Instance.Player.transform.position + Vector3.up * 4, Quaternion.identity);
        yield return new WaitUntil(() => dummyEnemy == null);
        GameController.Instance.Player.PlayerMoving.LockJoyStick();

        yield return PlayDialog(Dialog.TrainingOver);
        GameController.Instance.Player.PlayerMoving.UnlockJoyStick();
        GameObject meleeEnemy = Instantiate(_meleeEnemyPrefab, GameController.Instance.Player.transform.position + Vector3.up * 3 + Vector3.left * 3, Quaternion.identity);
        yield return new WaitUntil(() => meleeEnemy == null);
        GameController.Instance.Player.PlayerMoving.LockJoyStick();

        yield return PlayDialog(Dialog.Ready);
        GameController.Instance.Player.PlayerMoving.UnlockJoyStick();

        isPlayingTutorial = false;
        IsTutorialShown = true;

        SceneManager.LoadScene("Game");
    }

    IEnumerator PlayDialog(Dialog dialog)
    {
        yield return _dialogController.Show(_dialogInfos.Find(x => x.dialog == dialog));
    }
}
