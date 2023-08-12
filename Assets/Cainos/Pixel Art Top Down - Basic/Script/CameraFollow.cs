﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Transform target2;
        public float lerpSpeed = 1.0f;

        private Vector3 offset;
        private Vector3 offset2;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;
            offset2 = transform.position - target2.position;
        }

        private void Update()
        {
            if (target == null)
            {
                targetPos = target2.position + offset2;
                transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
            }
            else
            {

                targetPos = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
            }


        }

    }
}
