using UnityEngine;
using DG.Tweening;

public class Root : MonoBehaviour
{
    public Transform cube;
    public Transform sphere;
    const string TWEEN_ID = "tween_id";


    private void OnDestroy()
    {
        DOTween.Kill(TWEEN_ID);
    }

    private void Start()
    {
        Vector3 targetPos = sphere.position;
        cube.DOMove(targetPos, 1f)
            .SetId(TWEEN_ID)
            .OnComplete(Test);
    }

    private void Test()
    {
        print("Completed");
    }
}
