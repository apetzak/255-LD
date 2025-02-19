﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Petzak
{
    public class Arrow : MonoBehaviour
    {
        bool clicked = false;
        public int fromCamera;
        public int toCamera;

        public Arrow()
        {
        }

        void OnMouseDown()
        {
            clicked = true;
        }

        void Start()
        {

        }

        void Update()
        {
            if (clicked)
            {
                if (toCamera == 6 && !Game.main.BridgeLowered)
                    return;

                var cameras = new Camera[11];
                Camera.GetAllCameras(cameras);

                foreach (Camera c in cameras)
                {
                    if (c == null)
                    {
                        //print("null");
                        continue;
                    }

                    if (c.name.Replace("Cam", "") == toCamera.ToString())
                    {
                        c.depth = 2;
                        Game.main.CurrentCamera = toCamera;
                        print(toCamera);
                    }
                    else
                    {
                        c.depth = 1;
                    }
                }

                clicked = false;
            }
        }
    }
}