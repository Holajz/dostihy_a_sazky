using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour {
	public GameObject figure;
	public GameObject GameBoard;
	public GameObject player;
	public int speed;
	public int upspeed;


	private const int slowestspeed = 1;
	private const int slowerspeed = 4;

	private bool finishedmove;
	private GameboardController board;
	private int BoardPosition;
	private int diceRoll;

	private bool moveLeft;
	private bool moveRight;
	private bool moveWiderRight;
	private bool moveWiderLeft;
	private const float moveThroughFieldAmount = 190f;
	private const float moveThroughWiderFieldAmount = 185f;
	private const float moveThroughNarrowerFieldAmount = 160f;

	private bool moveUpRight;
	private bool moveUpLeft;
	private const float moveUpFieldAmount = 182f;

	private bool moveToStart;
	private const float moveLeftPipeAmount = 44f;
	private const float moveDownBoardAmount = 885f;
	private const float moveRightBoardAmount = 8 * 191;
	private const float moveUpBoardAmount = 157f;
	private const float moveLeftBoardAmount = 155f;
	private float moveLeftPipe = 0;
	private float moveDownBoard = 0;
	private float moveRightBoard = 0;
	private float moveUpBoard = 0;
	private float moveLeftBoard = 0;


	private float moveThroughFieldAmountNow = 0;
	private float moveUp = 0;

	private const int START = 1;
	private const int LADY_ANNE = 7;
	private const int NAHODA = 8;

	private const int PASEK = 9;
	private const int KORAN = 10;
	private const int JAPAN = 15;
	private const int DRUHY_TRENER = 16;

	private const int KOSTRAVA = 17;
	private const int FINANCE = 18;
	private const int DRUHA_NAHODA = 23;
	private const int MOHYLA = 24;

	private const int METAL = 25;
	private const int TRETI_TRENER = 26;
	private const int DOPING = 31;
	private const int SHAGGA = 32;

	private const int DAHOMAN = 33;
	private const int DRUHE_FINANCE = 34;
	private const int VETERINARNI_VYSETRENI = 39;
	private const int NAPOLI = 40;

	private const int NEW_START = 41;


	// Use this for initialization
	void Start () {

		BoardPosition = 1;

		board = (GameboardController) GameBoard.GetComponent (typeof(GameboardController));
		diceRoll = 0;
		finishedmove = true;

		moveLeft = false;
		moveRight = false;
		moveToStart = false;
		moveUpLeft = false;
		moveUpRight = false;
	}
	
	// Update is called once per frame moves figures
	void Update () {

		if (moveLeft) {

			moveThroughFieldAmountNow += speed;
			Vector3 pos = figure.transform.position;
			pos.x -= speed;
			figure.transform.position = pos;

			if (moveThroughFieldAmountNow >= moveThroughFieldAmount) {
			
				moveThroughFieldAmountNow = 0;
				moveLeft = false;
			
			}

		} else if (moveRight) {

			moveThroughFieldAmountNow += speed;
			Vector3 pos = figure.transform.position;
			pos.x += speed;
			figure.transform.position = pos;

			if (moveThroughFieldAmountNow >= moveThroughFieldAmount) {

				moveThroughFieldAmountNow = 0;
				moveRight = false;

			}
			
		} else if (moveUpLeft) {
			
			if (moveUp <= moveUpFieldAmount) {

				moveUp += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.y += slowestspeed;
				figure.transform.position = pos;

			} else {
				moveThroughFieldAmountNow += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.x -= slowestspeed;
				figure.transform.position = pos;

				if (moveThroughFieldAmountNow >= moveThroughNarrowerFieldAmount) {

					moveThroughFieldAmountNow = 0;
					moveUp = 0;
					moveUpLeft = false;

				}
			}
			
		} else if (moveUpRight) {

			if (moveUp <= moveUpFieldAmount) {

				moveUp += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.y += slowestspeed;
				figure.transform.position = pos;

			} else {
				moveThroughFieldAmountNow += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.x += slowestspeed;
				figure.transform.position = pos;

				if (moveThroughFieldAmountNow >= moveThroughNarrowerFieldAmount) {

					moveThroughFieldAmountNow = 0;
					moveUp = 0;
					moveUpRight = false;

				}
			}
			
		} else if (moveWiderRight) {

			moveThroughFieldAmountNow += slowestspeed;
			Vector3 pos = figure.transform.position;
			pos.x += slowestspeed;
			figure.transform.position = pos;

			if (moveThroughFieldAmountNow >= moveThroughWiderFieldAmount) {

				moveThroughFieldAmountNow = 0;
				moveWiderRight = false;

			}
			
		} else if (moveWiderLeft) {

			moveThroughFieldAmountNow += slowestspeed;
			Vector3 pos = figure.transform.position;
			pos.x -= slowestspeed;
			figure.transform.position = pos;

			if (moveThroughFieldAmountNow >= moveThroughWiderFieldAmount) {

				moveThroughFieldAmountNow = 0;
				moveWiderLeft = false;

			}
			
		} else if (moveToStart) {

			if (moveLeftPipe <= moveLeftPipeAmount) {
				moveLeftPipe += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.x -= slowestspeed;
				figure.transform.position = pos;
				return;
			}
			if (moveDownBoard <= moveDownBoardAmount) {
				moveDownBoard += speed;
				Vector3 pos = figure.transform.position;
				pos.y -= speed;
				figure.transform.position = pos;
				return;

			} else if (moveRightBoard <= moveRightBoardAmount) {
				moveRightBoard += speed;
				Vector3 pos = figure.transform.position;
				pos.x += speed;
				figure.transform.position = pos;
				return;
			} else if (moveUpBoard <= moveUpBoardAmount) {
				moveUpBoard += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.y += slowestspeed;
				figure.transform.position = pos;
				return;
			} else if (moveLeftBoard <= moveLeftBoardAmount) {
				moveLeftBoard += slowestspeed;
				Vector3 pos = figure.transform.position;
				pos.x -= slowestspeed;
				figure.transform.position = pos;

				if (moveLeftBoard >= moveLeftBoardAmount) {
					pos.x -= 3f;
					pos.y += 0.25f;
					figure.transform.position = pos;

					moveLeftPipe = 0;
					moveDownBoard = 0;
					moveRightBoard = 0;
					moveUpBoard = 0;
					moveLeftBoard = 0;
					moveToStart = false;
				}
			}




		} 

	}

	//prepare for moving figures
	IEnumerator move(int diceroll)
	{

		diceRoll = diceroll;
		finishedmove = false;
	
		if (BoardPosition + diceRoll > 39) {
			board.ActivatePipeEnd (BoardPosition-40+diceRoll, figure);
			
		} else {
			board.ActivatePipeEnd (BoardPosition+diceRoll, figure);
		}

			for (int i = 1; i <= diceRoll; i++) {
				BoardPosition++;

			if (BoardPosition <= LADY_ANNE || 
				(BoardPosition >= FINANCE && BoardPosition <= DRUHA_NAHODA) ||
				(BoardPosition >= DRUHE_FINANCE && BoardPosition <= VETERINARNI_VYSETRENI)) 
			{
				
			moveLeft = true;
			yield return new WaitUntil (() => moveLeft == false);

			}


			if (BoardPosition == NAHODA ||
			    BoardPosition == MOHYLA ||
			    BoardPosition == NAPOLI) 
			{
			
			moveWiderLeft = true;
			yield return new WaitUntil (() => moveWiderLeft == false);

			}

			if (BoardPosition == DRUHY_TRENER ||
				BoardPosition == SHAGGA) 
			{

				moveWiderRight = true;
				yield return new WaitUntil (() => moveWiderRight == false);

			}



			if (BoardPosition == PASEK ||
				BoardPosition == METAL) 
			{

			moveUpRight = true;
			yield return new WaitUntil (() => moveUpRight == false);

			}


			if (BoardPosition == KOSTRAVA ||
			    BoardPosition == DAHOMAN) 
			{

			moveUpLeft = true;
			yield return new WaitUntil (() => moveUpLeft == false);

			}



			if ((BoardPosition >= KORAN && BoardPosition <= JAPAN) ||
				(BoardPosition >= TRETI_TRENER && BoardPosition <= DOPING)) 
			{

			moveRight = true;
			yield return new WaitUntil (() => moveRight == false);

			}


			if (BoardPosition == NEW_START) 
			{

			BoardPosition -= 40;
			moveToStart = true;
			yield return new WaitUntil (() => moveToStart == false);

			}

			}

		finishedmove = true;

		board.AddFiguretoFieldandChangeActiveCard (BoardPosition, figure);

	}

	public int throwdice()
	{
		if (finishedmove) {

			board.DeactivatePipeEnd (BoardPosition, figure);
			board.RemoveFigureFromField (BoardPosition);

			int diceroll = (int)Random.Range (1f, 6f);

			StartCoroutine (move (diceroll));

			return diceroll;

		}
		return 0;

	}

	public int getBoardPosition() 
	{
		return BoardPosition;
	}

	public bool MoveFinished()
	{
		return finishedmove;
	}


		
}
