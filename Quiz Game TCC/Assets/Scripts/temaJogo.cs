﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class temaJogo : MonoBehaviour {

	public Button 		btnPlay;
	public Text 		txtNomeTema;
	public GameObject 	infoTema;
	public Text 		txtInfoTema;

	public GameObject 	estrela1;
	public GameObject 	estrela2;
	public GameObject 	estrela3;

	public string[]		nomeTema;
	public int 			numeroQuestoes;
	private int 		idTema;

	// Use this for initialization
	void Start () {
	
		idTema = 0;
		txtNomeTema.text = nomeTema [idTema];
		txtInfoTema.text = "Você acertou X de X questões!";
		infoTema.SetActive (false);
		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);
		btnPlay.interactable = false;

	
	}
	
	public void selecioneTema (int i){
		
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
		txtNomeTema.text = nomeTema [idTema];
		int notaFinal = PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ());
		int acertos = PlayerPrefs.GetInt ("acertos" + idTema.ToString ());

		estrela1.SetActive (false);
		estrela2.SetActive (false);
		estrela3.SetActive (false);

		if (notaFinal == 10) {

			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (true);

		} else if (notaFinal >= 6) {

			estrela1.SetActive (true);
			estrela2.SetActive (true);
			estrela3.SetActive (false);

		} else if (notaFinal >= 3) {

			estrela1.SetActive (true);
			estrela2.SetActive (false);
			estrela3.SetActive (false);
		}

		txtInfoTema.text = "Você acertou "+acertos.ToString()+" de "+numeroQuestoes.ToString()+" questões!";
		infoTema.SetActive (true);
		btnPlay.interactable = true;
				
	}

	public void jogar (){
		Application.LoadLevel("T"+idTema.ToString());
	}
}
