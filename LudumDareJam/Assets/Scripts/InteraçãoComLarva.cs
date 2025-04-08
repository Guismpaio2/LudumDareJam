using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteraçãoComLarva : MonoBehaviour
{
    public Timer timer;
    public Spawner spawner;
    bool podeInteragir;
    GameObject larva; // Referência ao objeto da larva

    void Update()
    {
        if (podeInteragir && Input.GetKeyDown(KeyCode.E)) PegarLarva(larva); // Passa a referência da larva
    }

    void PegarLarva(GameObject larva)
    {
        timer.PegouLarva(); // Chama a função no "Timer.cs" que adiciona 3 segundos ao tempo
        Destroy(larva); // Destrói o objeto da larva
        Debug.Log("Interagiu com a larva");
        spawner.currentLarvas -= 1; // Contador de larvas atuais

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Larva"))
        {
            podeInteragir = true;
            larva = collision.gameObject; // Armazena a referência ao objeto da larva
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Larva"))
        {
            podeInteragir = false;
            larva = null; // Limpa a referência ao objeto da larva
        }
    }
}