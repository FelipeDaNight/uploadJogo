using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{
	public float speed = 1f;
	public float attackRange = 1f;

	Transform player;
	Rigidbody2D rb;
	Enemy enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		enemy = animator.GetComponent<Enemy>();
		Physics2D.IgnoreCollision(animator.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);		
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		enemy.LookAtPlayer();

		Vector2 target = new Vector2(player.position.x, player.position.y);
		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime * 0.4f); 
		rb.MovePosition(newPos);

		if (Vector2.Distance(player.position, rb.position) <= attackRange * 0.3f)
		{
			animator.SetTrigger("Attack");
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}

}