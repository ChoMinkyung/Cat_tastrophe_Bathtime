using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappyEnding : MonoBehaviour
{
    public QuestSubtitle questSubtitle;
    public Subtitle subtitle;

    private void Start()
    {
        SoundManager.Instance.PlayBGM("HappyEnding");
        StartCoroutine(ShowSubtitle());
    }

    public IEnumerator ShowSubtitle()
    {
        yield return new WaitForSeconds(1f);
        questSubtitle.ShowQuestSubtitle("ī������ : ��Ű...��..����...��...");
        yield return new WaitForSeconds(8f);
        questSubtitle.ShowQuestSubtitle("ī������ : �ݷ�! �ݷ�! ����... �ʹ� ���� �Ծ���...");
        yield return new WaitForSeconds(20f);
        questSubtitle.ShowQuestSubtitle("ī������ : �׷��� �����ϱ� ��������?");
        yield return new WaitForSeconds(5f);
        questSubtitle.ShowQuestSubtitle("��Ű : �ֿ�");
        yield return new WaitForSeconds(2f);
        questSubtitle.ShowQuestSubtitle("ī������ : �׷� �׷�, ����༭ ����.  ���� ��Ű��ϱ�.");
        yield return new WaitForSeconds(5f);
        questSubtitle.ShowQuestSubtitle("ī������ : �� ������ ���� �����̾�.  �����ε� �� ��Ź��!");
        yield return new WaitForSeconds(5f);
        questSubtitle.ShowQuestSubtitle("��Ű : �ֿ�");
    }
}
