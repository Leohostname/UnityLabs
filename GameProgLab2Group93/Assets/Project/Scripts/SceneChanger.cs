using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	private static readonly string tpScene = "Mountains";

	public static void ChangeScene()
	{
		SceneManager.LoadScene(tpScene);
	}
}
