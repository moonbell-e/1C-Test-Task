using UnityEngine;

public class RandomDirectionGenerator : MonoBehaviour
{
    public Vector3 GetRandomDirection(Border border)
    {
        float randomX = Random.Range(border == Border.Left ? 0f : -1f, border == Border.Right ? 0f : 1f);
        float randomY = Random.Range(border == Border.Bottom ? 0f : -1f, border == Border.Top ? 0f : 1f);

        return new Vector3(randomX, randomY, 0).normalized;
    }
}
