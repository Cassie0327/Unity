using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEditor.Animations;
using System.Collections;

public class Frog : MonoBehaviour {

	public Material ma1;
    public Material ma2;
    public Renderer obj;

	public Rigidbody2D rb;
	public AudioClip Jup;
	private int count1 = 3;
	public Text SpecialText;
	public GameObject StarEffect;
	public Vector2 RecentPosition;
	private AudioSource source;
	private Animator animator;

	private bool isChange=false;
	private int sxxx;
	private float time1 = 2f;
	private float time2;

	private void Start()
	{
		
		SpecialText.text="Special moves:"+count1.ToString();

	}
	private void Awake()
    {
        source = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
    }
	void Update () {

		if (isChange ==true)
		{
			Invoke("change", 3);

		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			rb.MovePosition(rb.position + Vector2.right);

		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			rb.MovePosition(rb.position + Vector2.left);
		else if (Input.GetKeyDown(KeyCode.UpArrow))
			rb.MovePosition(rb.position + Vector2.up);
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			rb.MovePosition(rb.position + Vector2.down);
		else if (Input.GetKeyDown(KeyCode.J))
			{
				
			if (count1 > 0)
			{
				source.PlayOneShot(Jup, 0.2F);
				count1 = count1 -1;
                SpecialText.text = "Special moves:" + count1.ToString();
				RecentPosition = rb.position + Vector2.up * 10;
                rb.MovePosition(RecentPosition);
				Instantiate(StarEffect, RecentPosition, transform.rotation);
				obj.material = ma1;
				sxxx = 1;
				isChange = true;
                

			}
            
			}

		GetComponent<Animator>().SetInteger("X", sxxx);


        
	}
    void change()
	{
		
		sxxx = -1;
        obj.material = ma2;
		isChange = false;
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
			Debug.Log("WE LOST!");
			Score.CurrentScore = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
