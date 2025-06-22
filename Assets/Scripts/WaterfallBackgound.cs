using UnityEngine;

public class WaterfallBackground : MonoBehaviour
{
    public Transform[] groups; // �ݵ�� �� �� �ʿ�
    public float scrollSpeed = 2;

    private float groupHeight;
    private Transform currentGroup;
    private Transform nextGroup;

    void Start()
    {
        if (groups.Length < 2)
        {
            Debug.LogError("groups �迭�� 2�� �̻��� Transform�� �־�� �մϴ�.");
            enabled = false;
            return;
        }

        currentGroup = groups[0];
        nextGroup = groups[1];

        groupHeight = GetGroupHeight(currentGroup);

        // nextGroup�� currentGroup �Ʒ��� ��Ȯ�� ��ġ
        nextGroup.position = currentGroup.position - new Vector3(0, groupHeight, 0);
    }

    void Update()
    {
        // �� �� ���� �̵�
        currentGroup.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        nextGroup.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // currentGroup�� ȭ�� ���� ������ �������� ���ġ
        if (IsOutOfView(currentGroup))
        {
            // currentGroup�� nextGroup �Ʒ��� ���ġ
            currentGroup.position = nextGroup.position - new Vector3(0, groupHeight, 0);

            // ���� ����
            var temp = currentGroup;
            currentGroup = nextGroup;
            nextGroup = temp;
        }
    }

    bool IsOutOfView(Transform group)
    {
        // �׷� �ȿ� �ִ� ��� SpriteRenderer�� �ִ� y �� ��������
        float maxY = float.MinValue;
        var renderers = group.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in renderers)
        {
            if (sr.sprite == null) continue;
            maxY = Mathf.Max(maxY, sr.bounds.max.y);
        }

        float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // maxY�� ȭ�� ���� ������ ������� �Ǵ�
        return maxY < screenTop - 0.1f; // �ణ ������ ��� ��Ȯ�ϰ� �Ѿ
    }

    float GetGroupHeight(Transform group)
    {
        float minY = float.MaxValue;
        float maxY = float.MinValue;
        var renderers = group.GetComponentsInChildren<SpriteRenderer>();

        foreach (var sr in renderers)
        {
            if (sr.sprite == null) continue;
            var bounds = sr.bounds;
            minY = Mathf.Min(minY, bounds.min.y);
            maxY = Mathf.Max(maxY, bounds.max.y);
        }

        return maxY - minY;
    }
}
