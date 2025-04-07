using UnityEngine;

//CASO APARE�A UM ERRO NESSE SCRIPT
//� NECESSARIO BAIXAR O INPUT SYSTEM
//Para isso clique em Window -> Package Manager -> Unity Registry pesquise 'Input System' e instale essa aplica��o

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f; //velocidade que o jogador se move

    private Vector2 _movement;

    private Animator _animator; 
    private Rigidbody2D _rb;

    private bool PodeAndar = true;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _Ultimohorizontal = "UltimoHorizontal";
    private const string _Ultimovertical = "UltimoVertical"; 
    //Essas ultimas 4 linhas s�o usadas para anima��o, essas springs entre aspas s�o a maneira que elas s�o escritas no ANIMATOR
    //Elas s�o usadas para o ANIMATOR para saber em que momento usar as anima��es de andar ou ficar parado


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PodeAndar)
        {
            _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

            _rb.linearVelocity = _movement * _moveSpeed;

            _animator.SetFloat(_horizontal, _movement.x); //anima��o do jogador ao andar para direita e para esquerda
            _animator.SetFloat(_vertical, _movement.y); //anima��o do jogador ao andar para cima e para baixo

            if (_movement != Vector2.zero)
            {
                _animator.SetFloat(_Ultimovertical, _movement.y);
                _animator.SetFloat(_Ultimohorizontal, _movement.x);
                //detecta a ultima posi��o que o jogador estava se movendo, assim fazendo que ele fique parado nessa posi��o em idle
            }
        }
    }
}
