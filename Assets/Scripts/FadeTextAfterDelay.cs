using System.Collections;
using UnityEngine;
using TMPro;

public class FadeTextAfterDelay : MonoBehaviour
{
    public TMP_Text text;  // Ссылка на компонент TMP_Text
    public float fadeDuration = 2f;  // Длительность плавного исчезновения
    public float delay = 5f;  // Задержка перед началом исчезновения

    private void Start()
    {
        // Запускаем корутину с задержкой
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        // Ждем 5 секунд
        yield return new WaitForSeconds(delay);

        // Получаем текущий цвет текста
        Color originalColor = text.color;
        float elapsedTime = 0f;

        // Плавно уменьшаем альфа-канал цвета текста
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Убедимся, что текст полностью прозрачный
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}