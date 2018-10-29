﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FSM_Alarm : MonoBehaviour {
    private bool player_detected = false;
    private bool in_alarm = false;
    private Vector3 patrol_pos;

    public GameObject alarm;
    public BansheeGz.BGSpline.Curve.BGCurve path;

    NavMeshAgent navigation;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == alarm)
            in_alarm = true;
    }

    // Update is called once per frame
    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            player_detected = true;
        }
    }
   
    // TODO 1: Create a coroutine that executes 20 times per second
    // and goes forever. Make sure to trigger it from Start()

    // Use this for initialization
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        StartCoroutine("Patrol");
    }
    IEnumerator Patrol() {
        player_detected = false;
        Debug.Log("Entering Patrol");
        path.gameObject.SetActive(true);
        while (!player_detected)
        {            
            yield return new WaitForSeconds(1/20);
        }
        StartCoroutine("GoToAlarm");

    }

    // TODO 2: If player is spotted, jump to another coroutine that should
    // execute 20 times per second waiting for the player to reach the alarm

    IEnumerator GoToAlarm() {
        path.gameObject.SetActive(false);
        navigation.SetDestination(alarm.transform.position);
        while (!in_alarm)
        {           
            yield return new WaitForSeconds(1 / 20);
        }
        StartCoroutine("BackToPos");

    }

    IEnumerator BackToPos() {
        in_alarm = false;
       
        while (true)
        {
            Vector3 dif= (transform.position - patrol_pos);
            navigation.SetDestination(patrol_pos);
            if (dif.magnitude < 1) {
                break;
            }
            yield return new WaitForSeconds(1 / 20);
        }
        StartCoroutine("Patrol");
    }
    // TODO 3: Create the last coroutine to have the tank waiting to reach
    // the point where he left the path, and trigger again the patrol



}