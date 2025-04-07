using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteraçãoComLarva : MonoBehaviour
{
    bool podeInteragir;
    void Update()
    {
        if (podeInteragir && Input.GetKeyDown(KeyCode.E)) PegarLarva();
        
    }

    void PegarLarva()
    {
        Destroy(gameObject);
        Debug.Log("Interagiu com a larva");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.name.Equals("Player"))
        {
            podeInteragir = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            podeInteragir = false;
        }
    }
}
