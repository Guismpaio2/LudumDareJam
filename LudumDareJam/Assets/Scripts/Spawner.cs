using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject larvaPrefab; // Prefab da larva a ser instanciada
    public playerMovement playerMovement; // Referência ao script de movimento do jogador

    public float spawnInterval = 2f; // Intervalo entre os spawns
    public float spawnRadius = 5f; // Raio de spawn
    public int maxLarvas = 10; // Número máximo de larvas na cena
    public int currentLarvas = 0; // Contador de larvas atuais

    private void Start()
    {
        InvokeRepeating(nameof(SpawnLarva), 0f, spawnInterval);

    }

    void SpawnLarva()
    {
        if (currentLarvas < maxLarvas)
        {
            Vector3 randomPos = Random.insideUnitCircle * spawnRadius; // Gera uma posição aleatória dentro de um círculo
            Instantiate(larvaPrefab,randomPos, Quaternion.identity); // Instancia a larva na posição gerada
            currentLarvas++; // Incrementa o contador de larvas atuais
        }
        else {
            //codigo do Game Over
            Debug.Log("Perdeu babaca");
            playerMovement.TravarJogador(); // Chama a função no script de movimento do jogador para travar o movimento                                   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, spawnRadius);
        //O gizmo vermelho mostra o raio de spawn, ajustando o valor de spawnRadius é possivel ajustar onde as larvar spawnam
    }
}
