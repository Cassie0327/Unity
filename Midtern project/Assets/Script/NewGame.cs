using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class NewGame : MonoBehaviour {
	public int time;
	public string scenename;
	public  AudioClip Ac;
    private AudioSource source;
    
	// Use this for initialization
	private void Awake()
    {
        source = GetComponent<AudioSource>();
        
    }
	void Start () {
		source.PlayOneShot(Ac, 0.2F);
		Invoke ("LoadLevel", time);
	}

	void LoadLevel()	{


		SceneManager.LoadScene(scenename, LoadSceneMode.Single);

	}
}
