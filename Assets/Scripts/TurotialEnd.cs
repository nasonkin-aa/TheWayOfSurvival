using UnityEngine;
using UnityEngine.SceneManagement;

public class TurotialEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        SceneManager.LoadScene("Menu");
    }
}
