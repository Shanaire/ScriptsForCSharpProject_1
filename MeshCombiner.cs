using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
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
     * Find away to Add the names of the respected material
     * 
     * NEED TO WORK ON THE 65K VERTS LIMITATION 
     * 
     */


    public void AdvanceMeshCombine()
    {
        // This is getting the MeshFilter component of the parent gameobject and storing it in myMeshFilter
        MeshFilter myMeshFilter = new MeshFilter();
        myMeshFilter = GetComponent<MeshFilter>();

        // Getting the previous position and rotation so that it can be applied to the newly created objects
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        // Then setting the postition and rotation back to zero.
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        // Getting all MeshFilters
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>(false); // Make if false because we don't want to flatten the structure of the filters.

        // This is getting a list of all the different materials that are in the selected object. 
        List<Material> materials = new List<Material>();
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>(false); // findout what false means in this context// For each of the objects that are in our list, get the mesh renderer for each of those objects
        foreach (MeshRenderer item in renderers)// Now we iterate through the mesgh renderers adding all the materials to the list, this time we can skip the parent object that has an material
        {
            if (item.transform == transform) // This statement is to skip our selves from being added to the list of materials.
            {
                continue;
            }
            Material[] localMats = item.sharedMaterials; // this is to give us a list of all the materials on that renderer and add it to this array. 
            foreach (Material item_2 in localMats)// for we can iterate through the arrange and add the items to the list, not repeating any items that are already in that list.
            {
                if (!materials.Contains(item_2))
                {
                    materials.Add(item_2); // This is adding all materials that are in the scene to the list given that the material is not already in the list.
                }
            }
        }

        // Now we are going to go through the process of creating a mesh for each of the materials that has been added to the materials list.
        // We are going to create a list of meshes, and it is going to be one for each materials.

        List<Mesh> submeshes = new List<Mesh>();
        foreach (Material item in materials)
        {
            // This is going to go through the process of creating a combine instance for each of the materials that we are going to create a mesh for.
            // This will also go through all the children submeshes to see if anyof them have the materials that we are currently trying to find.
            // This basically checking all the materials that are already collected with the materials that are in the one the mesh filter to match it, so that it can be applied.
            List<CombineInstance> combiners = new List<CombineInstance>();
            foreach (MeshFilter item_2 in filters)
            {
                MeshRenderer renderer = item_2.GetComponent<MeshRenderer>(); // We have to use the mesh renderer to check if the childern item from the mesh filter are using the same material that we are trying to find.
                if (renderer == null)
                {
                    Debug.Log(item_2.name + "No MeshRenderer");
                    continue;
                }
                // Now lets create an instance of all the materials that are on the current meshrenderer and add it to the array.
                Material[] localMaterials = renderer.sharedMaterials; // Adding all materials on that are availabel through the mesh rendenerers to the array
                for (int materialIndex = 0; materialIndex < localMaterials.Length; materialIndex++)
                {
                    if (localMaterials[materialIndex] != item)
                    {
                        continue;
                    }
                    // But if the material is in the list and it is the material we are looking for, the add it to the combineinstance
                    CombineInstance ci = new CombineInstance
                    {
                        mesh = item_2.sharedMesh,
                        subMeshIndex = materialIndex,
                        transform = item_2.transform.localToWorldMatrix
                    };
                    combiners.Add(ci);
                }

                // Now we can flatten the all the meshes into a single mesh
                Mesh mesh = new Mesh();
                mesh.CombineMeshes(combiners.ToArray(), true);
                submeshes.Add(mesh);
            }
        }
        // Now we can create our final combiners that will combine all the submeshes into one mesh

        List<CombineInstance> finalCombiners = new List<CombineInstance>(); // A list to hold all the final set of combine instances that is to be placed into the final mesh
        foreach (Mesh item in submeshes)
        {
            CombineInstance ci = new CombineInstance
            {
                mesh = item,
                subMeshIndex = 0,
                transform = Matrix4x4.identity
            };
            finalCombiners.Add(ci);
        }
        Mesh finalMesh_2 = new Mesh();
        finalMesh_2.CombineMeshes(finalCombiners.ToArray(), false);


        myMeshFilter.sharedMesh = finalMesh_2;

        //Debug.Log("Final mesh has" + submeshes.Count + " materials.");


        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }



    public void CombineMeshes()
    {
        // This is getting the MeshFilter component of the parent gameobject and storing it in myMeshFilter
        MeshFilter myMeshFilter = new MeshFilter();
        myMeshFilter = GetComponent<MeshFilter>();

        // Getting the previous position and rotation so that it can be applied to the newly created objects
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        // Then setting the postition and rotation back to zero.
        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        // Finding all the mesh filters that are on the children of the parent objects.
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        // This is now creating a mesh to add all of the meshes that are children of the parent into a single mesh object.
        //Mesh finalMesh = new Mesh();

        Debug.Log("CombineMeshes" + filters.Length);

        // This is the instance of a mesh combiner that is going to house the objects from the previous objects.;
        List<CombineInstance> combiners = new List<CombineInstance>();

        // for each of the meshes in the mesh filter, we are adding these to the new mesh comining it into one mesh
        foreach (MeshFilter item in filters)
        {
            if (item == myMeshFilter)
            {
                continue;
            }

            CombineInstance ci = new CombineInstance
            {
                subMeshIndex = 0,
                mesh = item.sharedMesh,
                transform = item.transform.localToWorldMatrix
            };
            combiners.Add(ci);
        }

        Mesh finalMesh = new Mesh();
        // Adding all the meshes into the final mesh.
        finalMesh.CombineMeshes(combiners.ToArray(), true);

        // This is getting the parent mesh filter and displaying it.
        myMeshFilter.sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

    }
}
