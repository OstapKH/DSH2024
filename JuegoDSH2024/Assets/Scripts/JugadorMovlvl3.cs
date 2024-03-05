using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JugadorMovlv3 : MonoBehaviour
{
  //Public
    public Vector3 PlayerDirection;
    public float PlayerSpeed;
    public Generasuelo3 groundSpawner;
    public float puntos;
    public TextMeshProUGUI puntaje;
    public GameObject RestartMenu;

  //Private


    private void Start(){
        PlayerDirection = Vector3.left;

        RestartMenu.SetActive(false);
    }

    private void Update(){
        
        playerController();
        transform.position += getPlayerDirection() * PlayerSpeed * Time.deltaTime;
    
        puntaje.text = "Objetivo 100/" + puntos + "puntos";

    }
    private void FixedUpdate(){
            if(puntos == 50){
            PlayerSpeed = PlayerSpeed * 1.04f;
            }
            if (puntos == 100){
                SceneManager.LoadScene("Level3");
            }
    }


    public Vector3 getPlayerDirection()
        {
            return PlayerDirection;
        }

     private void playerController()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            PlayerMove();
        }
    }

    private void PlayerMove()
    {
        if (PlayerDirection.x == -1)
        {
            PlayerDirection = Vector3.forward;
        }
        else
        {
            PlayerDirection = Vector3.left;
        }
    }

    private void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "Suelo"){
            groundSpawner.RandonGround22();
            puntos += 1;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Muerte"){
            Time.timeScale = 0f;
            RestartMenu.SetActive(true);
        }
    }

    public void RestartBtn(){
        Time.timeScale = 1f;
        RestartMenu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
