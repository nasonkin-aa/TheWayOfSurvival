using System.Collections;
using UnityEngine;
using TMPro;

public class FadeTextAfterDelay : MonoBehaviour
{
    public TMP_Text text;  // ������ �� ��������� TMP_Text
    public float fadeDuration = 2f;  // ������������ �������� ������������
    public float delay = 5f;  // �������� ����� ������� ������������

    private void Start()
    {
        // ��������� �������� � ���������
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        // ���� 5 ������
        yield return new WaitForSeconds(delay);

        // �������� ������� ���� ������
        Color originalColor = text.color;
        float elapsedTime = 0f;

        // ������ ��������� �����-����� ����� ������
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // ��������, ��� ����� ��������� ����������
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}