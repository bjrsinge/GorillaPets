using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GorillaPets
{
    public class Buttons : MonoBehaviour
    {
        public float db = 0f;
        public string btn;
        public GameObject pet;

        void Start()
        {
            btn = this.transform.name;
            pet = Plugin.screen.transform.Find("pet").gameObject;
            pet.GetComponent<BoxCollider>().enabled = false;
        }

        void OnTriggerEnter(Collider col)
        {
            if (db >= Time.time) return;
            if (col.GetComponent<GorillaTriggerColliderHandIndicator>() == null) return;

            db = Time.time + 2f;

            var ind = col.GetComponent<GorillaTriggerColliderHandIndicator>();
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, ind.isLeftHand, 0.05f);
            GorillaTagger.Instance.StartVibration(ind.isLeftHand, GorillaTagger.Instance.tapHapticStrength / 2f, GorillaTagger.Instance.tapHapticDuration);

            switch (btn)
            {
                case "jump":
                    this.StartCoroutine(Jump());
                    break;

                case "sit":
                    this.StartCoroutine(Sit());
                    break;

                case "run":
                    this.StartCoroutine(Run());
                    break;

                case "feed":
                    this.StartCoroutine(Feed());
                    break;

                default:
                    Debug.Log("GORILLA PETS ----- There seems to have been an error, please contact the mod creator!");
                    break;
            }
        }

        IEnumerator Jump()
        {
            pet.GetComponent<MeshRenderer>().material = Plugin.pet4;
            yield return new WaitForSeconds(2);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
        }        
        
        IEnumerator Sit()
        {
            pet.GetComponent<MeshRenderer>().material = Plugin.pet3;
            yield return new WaitForSeconds(15);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
        }        
        
        IEnumerator Run()
        {
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
            yield return new WaitForSeconds(0.3f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet1;
            yield return new WaitForSeconds(0.3f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet2;
            yield return new WaitForSeconds(0.3f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
            yield return new WaitForSeconds(0.3f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet1;
            yield return new WaitForSeconds(0.3f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet2;
            yield return new WaitForSeconds(0.2f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
        }        
        
        IEnumerator Feed()
        {
            pet.GetComponent<MeshRenderer>().material = Plugin.pet5;
            yield return new WaitForSeconds(0.7f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet6;
            yield return new WaitForSeconds(0.7f);
            pet.GetComponent<MeshRenderer>().material = Plugin.pet_m;
        }   
    }
}