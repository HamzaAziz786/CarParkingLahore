using System.Collections;
using UnityEngine;

public class Collision_Handler : MonoBehaviour
{
    public Material redTransparentMaterial;
    public Rigidbody player;
    Material OriginalMat;
    Renderer render;
    private void Start()
    {
        player.isKinematic = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Hurdle"))
        {
            GamePlay_Manager.Instance.BtnClickSource.PlayOneShot(GamePlay_Manager.Instance.AlarmClip);
            Vehicle_Lights.Instance.Indicator.enabled = true;
            Vehicle_Lights.Instance.brakeLights.enabled = true;
            player.isKinematic = true;
              render = collision.gameObject.GetComponent<Renderer>();
            OriginalMat = render.material;
           
            //if(render != null)
            //{
            //    Material[] material = render.materials;
            //    Material[] newMaterial = new Material[material.Length + 1] ;

            //    for(int i = 0; i < material.Length; i++)
            //    {
            //        newMaterial[i] = material[i];
            //    }

            //    newMaterial[material.Length] = redTransparentMaterial;
            //    render.materials = newMaterial;

            //}

            GamePlay_Manager.Instance.HidePanels();
            StartCoroutine(Failed());
            StartCoroutine(AnimateMat());
        }
    }

    IEnumerator AnimateMat()
    {
        yield return new WaitForSecondsRealtime(0f);
        render.material = redTransparentMaterial;
        yield return new WaitForSecondsRealtime(0.3f);
        render.material = OriginalMat;
        yield return new WaitForSecondsRealtime(0.3f);
        render.material = redTransparentMaterial;
        yield return new WaitForSecondsRealtime(0.3f);
        render.material = OriginalMat;
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(2f);
        GamePlay_Manager.Instance.OnFail();
        Vehicle_Lights.Instance.Indicator.enabled = false;
        Vehicle_Lights.Instance.brakeLights.enabled = false;



    }


}
