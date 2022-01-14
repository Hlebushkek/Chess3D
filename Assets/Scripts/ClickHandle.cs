using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandle : MonoBehaviour
{
    private ChessBoardAbstract board;
    private void Start()
    {
        board = FindObjectOfType<ChessBoardAbstract>();
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            bool castRay = false;
            Ray raycast = new Ray();
            if (Application.platform == RuntimePlatform.Android && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                castRay = true;
            }
            else if ((Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer) && Input.GetMouseButtonDown(0))
            {
                raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                castRay = true;
            }

            if (castRay)
            {
                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if (raycastHit.transform.TryGetComponent<ChessPieceAbstract>(out ChessPieceAbstract piece))
                    {
                        Team whoClick = CameraManager.getTeam();
                        Team whatClicked = piece.getTeam();
                        Team whoseTurn = TeamManager.GetCurrentTurnTeam();
                        if (whoClick == whatClicked && whoClick == whoseTurn)
                        {
                            Debug.Log("Your turn, your piece");
                            board.HighlightCells(piece, piece.getTeam());
                        }
                        else if (whoClick == whatClicked && whoClick != whoseTurn)
                        {
                            Debug.Log("Not your turn, your piece");
                        }
                        else if (whoClick != whatClicked && whoClick == whoseTurn)
                        {
                            Debug.Log("Your turn, not your piece");
                        }
                        else
                        {
                            Debug.Log("Not your turn, not your piece");
                        }
                    }
                    else if (raycastHit.transform.gameObject.tag == "BoardCell")
                    {
                        board.TryMovePiece(raycastHit.transform.position);
                    }
                }
            }
        }
    }
}
