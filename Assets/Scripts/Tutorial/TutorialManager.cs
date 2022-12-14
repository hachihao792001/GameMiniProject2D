using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoSingleton<TutorialManager>
{
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
        if (!DataManager.IsTutorialShown)
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

        PlayerMoving playerMoving = GameController.Instance.Player.PlayerMoving;

        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == "Game");
        GameController.Instance.PauseButton.gameObject.SetActive(false);
        yield return PlayDialog(Dialog.Move, !GameInformation.IsPhone);
        yield return new WaitUntil(() => playerMoving.IsMoving);
        yield return new WaitForSeconds(2f);
        playerMoving.LockMoving();

        yield return PlayDialog(Dialog.Approach);
        playerMoving.UnlockMoving();
        GameObject dummyEnemy = Instantiate(_dummyEnemyPrefab, GameController.Instance.Player.transform.position + Vector3.up * 4, Quaternion.identity);
        yield return new WaitUntil(() => dummyEnemy == null);
        playerMoving.LockMoving();

        yield return PlayDialog(Dialog.TrainingOver);
        playerMoving.UnlockMoving();
        GameObject meleeEnemy = Instantiate(_meleeEnemyPrefab, GameController.Instance.Player.transform.position + Vector3.up * 3 + Vector3.left * 3, Quaternion.identity);
        yield return new WaitUntil(() => meleeEnemy == null);
        playerMoving.LockMoving();

        yield return PlayDialog(Dialog.Ready);
        playerMoving.UnlockMoving();

        isPlayingTutorial = false;
        DataManager.IsTutorialShown = true;

        SceneManager.LoadScene("Game");
    }

    IEnumerator PlayDialog(Dialog dialog, bool useAlternative = false)
    {
        yield return _dialogController.Show(_dialogInfos.Find(x => x.dialog == dialog), useAlternative);
    }
}
