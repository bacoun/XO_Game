using UnityEngine;
using System.Collections;

public class TicTacToe : MonoBehaviour {
	private static float HEIGHT = Screen.height, WIDTH = Screen.width;
	private string[] label = new string[9];
	private bool pOne = true, pTwo = false, win = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<9; i++)
			label [i] = "";
		win = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		float bSize = WIDTH / 3;
		if (GUI.Button (new Rect (0, 0, WIDTH, HEIGHT / 6), "New Game"))
			Start ();
		pOne = GUI.Toggle (new Rect (0, HEIGHT/6, WIDTH/2, HEIGHT/6), !pTwo, "X");
		pTwo = GUI.Toggle (new Rect (WIDTH/2, HEIGHT/6, WIDTH/2, HEIGHT/6), !pOne, "O");
		GUI.BeginGroup (new Rect (0, HEIGHT / 3, WIDTH, WIDTH));
		for (int i = 0; i<9; i++)
			if (GUI.Button (new Rect ((i % 3) * bSize, (i / 3) * bSize, bSize, bSize), label [i]))
			if (label [i] == "") {
				if (pOne)
					label [i] = "X";
				else
					label [i] = "O";
				pOne = !pOne;
				pTwo = !pTwo;
				checkWin ();
			}
		GUI.EndGroup ();
		if (win)
			GUI.Label(new Rect(0, HEIGHT / 3, WIDTH, WIDTH), "Game Over");
	}

	void checkWin(){
		for (int i = 0; i<9; i+=3)
			if ((label [i] == "X" && label [i + 1] == "X" && label [i + 2] == "X") || (label [i] == "O" && label [i + 1] == "O" && label [i + 2] == "O"))
				win = true;
		for (int i = 0; i<3; i++)
			if ((label [i] == "X" && label [i + 3] == "X" && label [i + 6] == "X") || (label [i] == "O" && label [i + 3] == "O" && label [i + 6] == "O"))
				win = true;
		if ((label [0] == "X" && label [4] == "X" && label [8] == "X") || (label [0] == "O" && label [4] == "O" && label [8] == "O"))
			win = true;
		if ((label [2] == "X" && label [4] == "X" && label [6] == "X") || (label [2] == "O" && label [4] == "O" && label [6] == "O"))
			win = true;
		if (!win) {
			bool tie = true;
			for (int i= 0; i<9; i++)
				if (label [i] == "")
					tie = false;
			win = tie;
		}
	}
	
}
