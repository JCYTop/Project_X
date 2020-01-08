/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MeshTest
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/01/05 22:29:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

public class MeshTest : MonoBehaviour
{
    private MeshFilter mesh;

    void Start()
    {
        mesh = this.GetComponent<MeshFilter>();
        Debug.Log(mesh.mesh.triangles);
    }
}