using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

namespace EchoDestroyer
{
	public class AnimeIdle : StateMachineBehaviour
	{
		float m_deltatime;
		Transform m_playerTrans;
		Transform m_enemyTrans;
		EchoDestroyerEnemy m_echodestroyer;

		// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
		override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			m_deltatime = 0.0f;

            // 敵のデータを取得
            CharacterManager characterManager = ManagerContainer.instance.characterManager;
            m_echodestroyer = characterManager.enemyData as EchoDestroyerEnemy;
		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{

			// アタックに切り替える
			if (m_deltatime >= m_echodestroyer.SHOT_INTERVAL)
				animator.SetBool("IsAttack", true);

			//経過時間を更新する
			m_deltatime += Time.deltaTime;
		}

		// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
		//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//    
		//}

		// OnStateMove is called right after Animator.OnAnimatorMove()
		//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//    // Implement code that processes and affects root motion
		//}

		// OnStateIK is called right after Animator.OnAnimatorIK()
		//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		//{
		//    // Implement code that sets up animation IK (inverse kinematics)
		//}
	}
}