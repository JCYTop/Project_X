/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     HexMapCamera
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/05/19 21:27:20
 *Description:   
 *History:
 ----------------------------------
*/

using UnityEngine;

namespace Runtime.HexMap.Scripts
{
    public class HexMapCamera : MonoBehaviour
    {
        private Transform swivel;
        private Transform stick;
        private float zoom = 1f;
        private float rotationAngle;
        public float stickMinZoom;
        public float stickMaxZoom;
        public float swivelMinZoom;
        public float swivelMaxZoom;
        public float moveSpeedMinZoom;
        public float moveSpeedMaxZoom;
        public float rotationSpeed;
        public HexGrid grid;

        private void Awake()
        {
            swivel = transform.GetChild(0);
            stick = swivel.GetChild(0);
        }

        private void Update()
        {
            var zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            if (zoomDelta != 0f)
            {
                AdjustZoom(zoomDelta);
            }

            var rotationDelta = Input.GetAxis("Rotation");
            if (rotationDelta != 0f)
            {
                AdjustRotation(rotationDelta);
            }

            var xDelta = Input.GetAxis("Horizontal");
            var zDelta = Input.GetAxis("Vertical");
            if (xDelta != 0f || zDelta != 0f)
            {
                AdjustPosition(xDelta, zDelta);
            }
        }

        private void AdjustRotation(float delta)
        {
            rotationAngle += delta * rotationSpeed * Time.deltaTime;
            if (rotationAngle < 0f)
            {
                rotationAngle += 360f;
            }
            else if (rotationAngle >= 360f)
            {
                rotationAngle -= 360f;
            }

            transform.localRotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }

        private void AdjustPosition(float xDelta, float zDelta)
        {
            var direction = transform.localRotation * new Vector3(xDelta, 0f, zDelta).normalized;
            var damping = Mathf.Max(Mathf.Abs(xDelta), Mathf.Abs(zDelta));
            var distance = Mathf.Lerp(moveSpeedMinZoom, moveSpeedMaxZoom, zoom) * damping * Time.deltaTime;
            var position = transform.localPosition;
            position += direction * distance;
            transform.localPosition = ClampPosition(position);
        }

        private Vector3 ClampPosition(Vector3 position)
        {
            var xMax = (grid.chunkCountX * HexMetrics.chunkSizeX - 0.5f) * (2f * HexMetrics.innerRadius);
            position.x = Mathf.Clamp(position.x, 0, xMax);
            var zMax = (grid.chunkCountZ * HexMetrics.chunkSizeZ - 1f) * (1.5f * HexMetrics.outerRadius);
            position.z = Mathf.Clamp(position.z, 0f, zMax);
            return position;
        }

        private void AdjustZoom(float delta)
        {
            zoom = Mathf.Clamp01(zoom + delta);
            var distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
            stick.localPosition = new Vector3(0f, 0f, distance);
            var angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
            swivel.localRotation = Quaternion.Euler(angle, 0f, 0f);
        }
    }
}