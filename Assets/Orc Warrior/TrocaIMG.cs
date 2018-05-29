using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaIMG : MonoBehaviour {

	[SerializeField]private Sprite[] imagens;
	[SerializeField]private SpriteRenderer sr;
	[SerializeField]private int x = 1;

	[SerializeField]private int direcao = 0;
	private Animator anim;
	private bool facingRight = true;

	// Use this for initialization
	void Start () {
		sr.sprite = imagens [1];
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(x == 1){
				x = 0;
			}else{
				x = 1;
			}
			sr.sprite = imagens [x];
		}

		if ((transform.position.x > 0 && !facingRight) || (transform.position.x < 0 && facingRight)) {
			Flip ();
		}

		Mover ();
	}

	public void Direita(){
		direcao = 2;
		anim.SetBool ("Andando", true);
		anim.SetBool ("Idle", false);

	}

	public void Esquerda(){
		direcao = -2;
		anim.SetBool ("Andando", true);
		anim.SetBool ("Idle", false);
	}

	public void Parado(){
		direcao = 0;
		anim.SetBool ("Andando", false);
		anim.SetBool ("Idle", true);
	}

	void Mover(){
		transform.Translate (direcao * Time.deltaTime, 0, 0);
	}

	void Flip(){
		facingRight = !facingRight;
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
