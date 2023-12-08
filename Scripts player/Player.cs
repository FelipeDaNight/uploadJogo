using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para comandos
public interface ICommand
{
    void Execute();
}

// Comando para movimentar o jogador
public class MoveCommand : ICommand
{
    private Transform _transform;
    private Vector3 _movement;
    private float _speed;

    public MoveCommand(Transform transform, Vector3 movement, float speed)
    {
        _transform = transform;
        _movement = movement;
        _speed = speed;
    }

    public void Execute()
    {
        _transform.position += _movement * _speed * Time.deltaTime;
    }
}

// Invocador que executa os comandos
public class CommandInvoker
{
    private List<ICommand> _commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
        _commands.Clear();
    }
}

public class Player : MonoBehaviour
{
    public Animator anim;
    public float speed;

    private Rigidbody2D _rigidbody;
    private CommandInvoker _commandInvoker = new CommandInvoker();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        ICommand moveCommand = new MoveCommand(transform, movement, speed);
        _commandInvoker.AddCommand(moveCommand);

        _commandInvoker.ExecuteCommands();
    }
}
