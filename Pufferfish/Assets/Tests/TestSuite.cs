using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Carrot carrot;
    private FishLeft fishLeft;


    [UnityTest]
    public IEnumerator  FallCarrot()
    {
        // 2
        GameObject carrotGameObject=
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Carrot"));
        // 3
        carrot = carrotGameObject.GetComponent<Carrot>();
        float initialYPos = carrot.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Less(carrot.transform.position.y, initialYPos);
        
        Object.Destroy(carrot.gameObject);
    }
   

    /*[UnityTest]
    public IEnumerator NPCSwim()
    {
        // 2
        GameObject NPCGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("NPC0"));
        // 3
        fishLeft = NPCGameObject.GetComponent<FishLeft>();
        float initialYPos = fishLeft.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(fishLeft.transform.position.x, initialYPos);

        Object.Destroy(fishLeft.gameObject);
    }*/


    [Test]
    public void TestSimplu()
    {


        Assert.AreEqual(1, 1);
    }
}
