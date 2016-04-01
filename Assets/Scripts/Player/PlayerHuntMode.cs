using UnityEngine;
using System.Collections;

public class PlayerHuntMode : MonoBehaviour 
{
    public Material DefaultMaterial;
    public Material HuntmodeMaterial;
    
    public MeshRenderer body;
	
    private void ChangeMaterial(Material material)
    {
        body.material = material;
    }
    
    public void HuntmodeEnable()
    {
        ChangeMaterial(HuntmodeMaterial);
    }
    
    public void HuntmodeDisable()
    {
        ChangeMaterial(DefaultMaterial);
    }
}
