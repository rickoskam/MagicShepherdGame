﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Herder : MonoBehaviour {
    bool a = true;
	bool shake = false;
	float speed = 15;
	float rotatespeed = 10;
    float rotatecamera = 8;
    float positiecameray = 4;
    float positiecameraz = 1;
    public Text Wintext;
    public Text ScoreWintext;
    public Text Score;
    public Slider Ziekschaapslider;
    public Image Ziekschaapimage;
    public Text Aantalschapeninveld;
    public Text Aantalschapeninbarn;
    public Button Pausebutton;
    public Button Resumebutton;
    public Button FFButton1;
    public Button FFButton2;
    public Image TrofeeWin;
    public Image ScoreWin;
    public Canvas MenuCanvas;
    public static float score;
    int keuz;
    public Image Schaapimage;
    public Image Barnimage;
    public Image Sterimage;
    public Image Graanimage;
    public Image Hondimage;
    public Text Aantalgraan;
    public Text Aantalhond;
    public Text Menu;
    public Canvas ChangeVolume;
    public Canvas Controlscanvas;
    public Canvas Quitcanvas;
    public Button Nextlevel;

	public static int gehaald;
	private int aangeroepen;
	public static float Tijd;
	public static int aantalschapengenezen;
	public static int aantalschapendood;
	private int iii;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1.5f;
        iii = 1;
		aantalschapendood = 0;
		aantalschapengenezen = 0;
        score = 1000;
        SetScore();
        Wintext.text = "";
        ScoreWintext.text = "";
        Ziekschaapslider.gameObject.SetActive(false);
        Ziekschaapimage.gameObject.SetActive(false);
        Pausebutton.gameObject.SetActive(true);
        Resumebutton.gameObject.SetActive(false);
        FFButton1.gameObject.SetActive(true);
        FFButton2.gameObject.SetActive(true);
        TrofeeWin.gameObject.SetActive(false);
        ScoreWin.gameObject.SetActive(false);
        SetScore();
        MenuCanvas.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        ChangeVolume.gameObject.SetActive(false);
        Controlscanvas.gameObject.SetActive(false);
        Quitcanvas.gameObject.SetActive(false);
        Nextlevel.gameObject.SetActive(false);
		gehaald = 2;
		aangeroepen = 0;
		Tijd = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
        // Vraag voor Bas: Hoezo niet escape om te resumen?
        SetScore();
        var C = GameObject.FindGameObjectWithTag("MainCamera");
		if(Input.GetKey(KeyCode.B)&&shake == false){
			StartCoroutine(Shake(C));
		}
        if (Input.GetAxis("Mouse X")>0)
		{
            transform.Rotate(new Vector3(0, rotatespeed * Input.GetAxis("Mouse X"), 0));
		}
        if (Input.GetAxis("Mouse X")<0)
		{
			transform.Rotate(new Vector3(0, rotatespeed * Input.GetAxis("Mouse X"),0));
		}
        if (Input.GetAxis("Mouse Y")>0)
        {
            //C.transform.Rotate(new Vector3(rotatecamera * Input.GetAxis("Mouse Y")*Time.deltaTime,0,0));
            //C.transform.Translate(new Vector3(0, positiecameray * Input.GetAxis("Mouse Y") * Time.deltaTime, positiecameraz * Input.GetAxis("Mouse Y") * Time.deltaTime));
        }
        if (Input.GetAxis("Mouse Y")<0)
        {
            //C.transform.Rotate(new Vector3(rotatecamera * Input.GetAxis("Mouse Y")* Time.deltaTime, 0, 0));
            //C.transform.Translate(new Vector3(0, positiecameray * Input.GetAxis("Mouse Y") * Time.deltaTime, positiecameraz * Input.GetAxis("Mouse Y") * Time.deltaTime));
        }

		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
		}
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;

        if (leng == 0)
        {
            keuz = 0;
        }

        if (leng > 0)
        {
            if (keuz == 0)
            {
                keuz = 1;
                Ziekschaapslider.gameObject.SetActive(true);
                Ziekschaapimage.gameObject.SetActive(true);
            }
            for (int m = 0; m < leng; m++)
            {
                GameObject ziekschaap = ziek[m];
                float xposs = ziekschaap.transform.position.x;
                float zposs = ziekschaap.transform.position.z;
                float xposh = transform.position.x;
                float zposh = transform.position.z;
                float xvers = Mathf.Abs(xposs - xposh);
                float zvers = Mathf.Abs(zposs - zposh);
                if (xvers <10f && zvers<10f && Input.GetKey(KeyCode.Alpha3))
                {
                    ziekschaap.tag = "Schaap";
                    ziekschaap.GetComponent<Renderer>().material.color = Color.grey;
                    keuz = 0;
                    Ziekschaapslider.value = 20;
                    Ziekschaapslider.gameObject.SetActive(false);
                    Ziekschaapimage.gameObject.SetActive(false);
                    score = score + 500;
                    SetScore();
                }
            }
        }

        if (keuz == 1)
        {
            StartCoroutine(Timerziekschaap());
        }

        if (keuz == 2)
        {
            StartCoroutine(TimerziekschaapA());
        }

        if (keuz == 3)
        {
            StartCoroutine(TimerziekschaapB());
        }

        if (keuz == 4)
        {
            StartCoroutine(TimerziekschaapC());
        }

        if (keuz == 5)
        {
            StartCoroutine(TimerziekschaapD());
        }

        if (keuz == 6)
        {
            StartCoroutine(TimerziekschaapE());
        }

        if (keuz == 7)
        {
            StartCoroutine(TimerziekschaapF());
        }

        if (keuz == 8)
        {
            StartCoroutine(TimerziekschaapG());
        }

        if (keuz == 9)
        {
            StartCoroutine(TimerziekschaapH());
        }

        if (keuz == 10)
        {
            StartCoroutine(Timerziekschaaplaatste());
        }

		GameObject[] schapenlijst = GameObject.FindGameObjectsWithTag("Schaap");
		int isl = schapenlijst.Length;
		Aantalschapeninveld.text = "" + isl;
		
		GameObject[] gevsch = GameObject.FindGameObjectsWithTag("GevangenSchaap");
		int gsl = gevsch.Length;
		Aantalschapeninbarn.text = "" + gsl;
		
		if (isl == 0 && leng == 0 && gsl > 0)
		{
			if (a == true)
			{
				score = score + 555;
				SetScore();
				a = false;
			}
			Tijd = Time.timeSinceLevelLoad;
			Wintext.text = "YOU WIN!";
			ScoreWintext.text = "" + score;
			TrofeeWin.gameObject.SetActive(true);
			ScoreWin.gameObject.SetActive(true);
			Nextlevel.gameObject.SetActive(true);
			Ziekschaapslider.gameObject.SetActive(false);
			Ziekschaapimage.gameObject.SetActive(false);
			Aantalschapeninbarn.gameObject.SetActive(false);
			Aantalschapeninveld.gameObject.SetActive(false);
			Pausebutton.gameObject.SetActive(false);
			Resumebutton.gameObject.SetActive(false);
			FFButton1.gameObject.SetActive(false);
			FFButton2.gameObject.SetActive(false);
			Schaapimage.gameObject.SetActive(false);
			Barnimage.gameObject.SetActive(false);
			Sterimage.gameObject.SetActive(false);
			Graanimage.gameObject.SetActive(false);
			Hondimage.gameObject.SetActive(false);
			Aantalgraan.gameObject.SetActive(false);
			Aantalhond.gameObject.SetActive(false);
			Score.gameObject.SetActive(false);
			gehaald = 1;
			if (aangeroepen == 0)
			{
				aangeroepen = 1;
				Aanroep();
			}
		}
		
		if (isl == 0 && leng == 0 && gsl == 0)
		{
			Wintext.text = "GAME OVER";
			Tijd = Time.timeSinceLevelLoad;
			Ziekschaapslider.gameObject.SetActive(false);
			Ziekschaapimage.gameObject.SetActive(false);
			Aantalschapeninbarn.gameObject.SetActive(false);
			Aantalschapeninveld.gameObject.SetActive(false);
			Pausebutton.gameObject.SetActive(false);
			Resumebutton.gameObject.SetActive(false);
			FFButton1.gameObject.SetActive(false);
			FFButton2.gameObject.SetActive(false);
			Schaapimage.gameObject.SetActive(false);
			Barnimage.gameObject.SetActive(false);
			Sterimage.gameObject.SetActive(false);
			Graanimage.gameObject.SetActive(false);
			Hondimage.gameObject.SetActive(false);
			Aantalgraan.gameObject.SetActive(false);
			Aantalhond.gameObject.SetActive(false);
			Score.gameObject.SetActive(false);
			gehaald = 0;
			if (aangeroepen == 0)
			{
				aangeroepen = 1;
				Aanroep();
			}
		}
	}
	
	public static void Aanroep()
	{
		GameObject go = GameObject.FindGameObjectWithTag("Empty");
		PostData other = (PostData)go.GetComponent(typeof(PostData));
		other.send();
	}
    IEnumerator Timerziekschaap()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 18;
            keuz = 2;
        }
    }
	IEnumerator Shake(GameObject C){
		shake = true;
		C.transform.Translate (0.01f,0.01f,0.01f);
		yield return new WaitForSeconds(1);
		C.transform.Translate(0.01f,0.01f,0.01f);
		shake = false;
	}
    IEnumerator TimerziekschaapA()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 16;
            keuz = 3;
        }
    }

    IEnumerator TimerziekschaapB()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 14;
            keuz = 4;
        }
    }

    IEnumerator TimerziekschaapC()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 12;
            keuz = 5;
        }
    }

    IEnumerator TimerziekschaapD()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 10;
            keuz = 6;
        }
    }

    IEnumerator TimerziekschaapE()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 8;
            keuz = 7;
        }
    }

    IEnumerator TimerziekschaapF()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 6;
            keuz = 8;
        }
    }

    IEnumerator TimerziekschaapG()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 4;
            keuz = 9;
        }
    }

    IEnumerator TimerziekschaapH()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 2;
            keuz = 10;
        }
    }

    IEnumerator Timerziekschaaplaatste()
    {
        GameObject[] ziek = GameObject.FindGameObjectsWithTag("ZiekSchaap");
        int leng = ziek.Length;
        if (leng > 0)
        {
            yield return new WaitForSeconds(2);
            Ziekschaapslider.value = 0;
            ziek[0].SetActive(false);
            keuz = 0;
            Ziekschaapslider.value = 20;
            Ziekschaapslider.gameObject.SetActive(false);
            Ziekschaapimage.gameObject.SetActive(false);
        }
    }

    public void Pause()
    {
        Pausebutton.gameObject.SetActive(false);
        Resumebutton.gameObject.SetActive(true);
        FFButton1.gameObject.SetActive(false);
        FFButton2.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
        MenuCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Resumebutton.gameObject.SetActive(false);
        Pausebutton.gameObject.SetActive(true);
        FFButton1.gameObject.SetActive(true);
        FFButton2.gameObject.SetActive(true);
        Menu.gameObject.SetActive(false);
        MenuCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.5f;
    }

    public void FF()
    {
        Pausebutton.gameObject.SetActive(false);
        Resumebutton.gameObject.SetActive(true);
        FFButton1.gameObject.SetActive(false);
        FFButton2.gameObject.SetActive(false);
        Time.timeScale = 2f;
    }

    public void ChangeVolumeAction()
    {
        MenuCanvas.gameObject.SetActive(false);
        ChangeVolume.gameObject.SetActive(true);
    }

    public void BackAction()
    {
        ChangeVolume.gameObject.SetActive(false);
        Controlscanvas.gameObject.SetActive(false);
        Quitcanvas.gameObject.SetActive(false);
        MenuCanvas.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);
    }
    
    public void ControlsAction()
    {
        MenuCanvas.gameObject.SetActive(false);
        Controlscanvas.gameObject.SetActive(true);
    }

    public void QuitAction()
    {
        Quitcanvas.gameObject.SetActive(true);
        MenuCanvas.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
    }

    public void SeriouslyQuit()
    {
        //Application.LoadLevel("Main_Menu");
        Application.Quit();
    }

    public void NaarWinkel()
    {
        Application.LoadLevel("Winkel2");
    }

    void SetScore()
    {
        Score.text = "" + score;
    }
}
