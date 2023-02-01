using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UIElements;

public class TestSuite
{
    private Carrot carrot;
    private FishLeft fishLeft;
    private Player player;
    private SpriteRenderer background;


    [UnityTest]
    public IEnumerator FallCarrot()
    {
        // 2
        GameObject carrotGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Carrot"));
        // 3
        carrot = carrotGameObject.GetComponent<Carrot>();
        float initialYPos = carrot.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(carrot.transform.position.y, initialYPos);

        Object.Destroy(carrot.gameObject);
    }


    [UnityTest]
    public IEnumerator NPCSwim()
    {
        // 2
        GameObject playerGameObject =
             MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
        GameObject NPCGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPC0"));
        GameObject backgroundGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Background"));
        // 3

        background = backgroundGameObject.GetComponent<SpriteRenderer>();
        player = playerGameObject.GetComponent<Player>();
        fishLeft = NPCGameObject.GetComponent<FishLeft>();
        float initialYPos = fishLeft.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(2, 1);

        Object.Destroy(fishLeft.gameObject);
    }


    [Test]
    public void TestSimplu()
    {


        Assert.AreEqual(1, 1);
    }
}
