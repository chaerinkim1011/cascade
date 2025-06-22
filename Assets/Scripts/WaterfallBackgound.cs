using UnityEngine;

public class WaterfallBackground : MonoBehaviour
{
    public Transform[] groups; // 반드시 두 개 필요
    public float scrollSpeed = 2;

    private float groupHeight;
    private Transform currentGroup;
    private Transform nextGroup;

    void Start()
    {
        if (groups.Length < 2)
        {
            Debug.LogError("groups 배열에 2개 이상의 Transform을 넣어야 합니다.");
            enabled = false;
            return;
        }

        currentGroup = groups[0];
        nextGroup = groups[1];

        groupHeight = GetGroupHeight(currentGroup);

        // nextGroup을 currentGroup 아래에 정확히 배치
        nextGroup.position = currentGroup.position - new Vector3(0, groupHeight, 0);
    }

    void Update()
    {
        // 둘 다 위로 이동
        currentGroup.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        nextGroup.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        // currentGroup이 화면 위로 완전히 나갔으면 재배치
        if (IsOutOfView(currentGroup))
        {
            // currentGroup을 nextGroup 아래로 재배치
            currentGroup.position = nextGroup.position - new Vector3(0, groupHeight, 0);

            // 둘을 스왑
            var temp = currentGroup;
            currentGroup = nextGroup;
            nextGroup = temp;
        }
    }

    bool IsOutOfView(Transform group)
    {
        // 그룹 안에 있는 모든 SpriteRenderer의 최대 y 값 가져오기
        float maxY = float.MinValue;
        var renderers = group.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in renderers)
        {
            if (sr.sprite == null) continue;
            maxY = Mathf.Max(maxY, sr.bounds.max.y);
        }

        float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // maxY가 화면 위로 완전히 벗어났는지 판단
        return maxY < screenTop - 0.1f; // 약간 여유를 줘야 정확하게 넘어감
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
