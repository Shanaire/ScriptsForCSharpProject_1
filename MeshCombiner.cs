using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {
    /* 
     * This script is also linked with the MeshCombineEditor script, which is used to creat a button that when the button is 
     * clicked the new merged mesh is created, through the running of the Combine Mesh functuion.
     * 
     * This script is used to create a combined mesh by grabbing all the meshfilters and conbiming them into one new object.
     * 
     * In using this script: 
     *      Apply it an empty gameObject that will be the parent to the objects that you want to combine.
     *      The gameObject will need the mesh renderer script and the the mesh filter script.
     *      When the button is pressed the new objects will be added to the filter of that game object.
     * 
     * NEED TO WORK ON THE 65K VERTS LIMITATION 
     * 
     */

    public void CombineMeshes()
    {
        
        
        
        
        
        
        // Getting the previous position and rotation so that it can be applied to the newly created objects
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        // Then setting the postition and rotation back to zero.
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        // Finding all the mesh filters that are on the children of the parent objects.
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        // This is now creating a mesh to add all of the meshes that are children of the parent into a single mesh object.
        Mesh finalMesh = new Mesh();

        Debug.Log("CombineMeshes" + filters.Length);

        // This is the instance of a mesh combiner that is going to house the objects from the previous objects.
        CombineInstance[] combiners = new CombineInstance[filters.Length];


        // for each of the meshes in the mesh filter, we are adding these to the new mesh comining it into one mesh
        for (int i =0; i < filters.Length; i ++)
        { 
            // remove it self from the series of mesh filters it is grabing.
            if (filters[i].transform == transform)
            {
                continue;
            }
            
            combiners[i].subMeshIndex = 0;
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }

        // Adding all the meshes into the final mesh.
        finalMesh.CombineMeshes(combiners);

        // This is getting the parent mesh filter and displaying it.
        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
