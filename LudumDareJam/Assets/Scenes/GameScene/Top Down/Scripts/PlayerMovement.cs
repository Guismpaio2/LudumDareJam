using UnityEngine;

//CASO APAREÇA UM ERRO NESSE SCRIPT
//É NECESSARIO BAIXAR O INPUT SYSTEM
//Para isso clique em Window -> Package Manager -> Unity Registry pesquise 'Input System' e instale essa aplicação

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
    //Essas ultimas 4 linhas são usadas para animação, essas springs entre aspas são a maneira que elas são escritas no ANIMATOR
    //Elas são usadas para o ANIMATOR para saber em que momento usar as animações de andar ou ficar parado


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

            _animator.SetFloat(_horizontal, _movement.x); //animação do jogador ao andar para direita e para esquerda
            _animator.SetFloat(_vertical, _movement.y); //animação do jogador ao andar para cima e para baixo

            if (_movement != Vector2.zero)
            {
                _animator.SetFloat(_Ultimovertical, _movement.y);
                _animator.SetFloat(_Ultimohorizontal, _movement.x);
                //detecta a ultima posição que o jogador estava se movendo, assim fazendo que ele fique parado nessa posição em idle
            }
        }
    }
}
