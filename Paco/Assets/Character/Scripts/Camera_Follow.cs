/******************************************************************************/
/*
\file   Camera_Follow.cs
\author Carlos Fernandez
\par    email: c.fernandez@digipen.edu
\par    Course: GAM 200
\par    Section C
\date   09/18/2020

\brief
	Camera follows GameObject
*/
/******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    private CharacterController2D player;
    [Range(0.0f, 5.0f)] [SerializeField] private float LerpSpeed = 3.0f;
    public float yOffset;

    private void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj)
        {
            player = obj.GetComponent<CharacterController2D>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            float interpolation = LerpSpeed * Time.deltaTime;
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + yOffset, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);

            this.transform.position = position;
        }

    }
}
