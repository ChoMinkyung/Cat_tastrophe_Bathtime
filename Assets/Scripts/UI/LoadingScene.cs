using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Header("프로그레스바 이미지")]
    public Image progressBar;
    
    [Header("로딩할 씬")]
    public string sceneName;

    private float loadingTime = 4.0f;
    private float time;

    void Start()
    {
        //progressBar = GetComponent<Image>();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        // 비동기 로드 : Scene을 불러올 때 멈추지 않고 다른 작업 가능
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); // 비동기적으로 로드 시작
        if (operation != null)
        {
            operation.allowSceneActivation = false; // 씬 로드 후 자동으로 장면 전환이 되지 않도록
        }

        while (!operation.isDone) // 로딩 완료 유무 
        {
            yield return null;

            time += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(time / loadingTime);

            if (time > loadingTime)
                operation.allowSceneActivation = true;
        }

        yield return null;
    }
}

// operation.progress : 진행정도를 float형 0,1을 반환 (0 : 진행 중 , 1 : 진행완료)
// Mathf.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);