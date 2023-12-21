using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using System.Linq;

public class MainGameController : MonoBehaviour
{
    [SerializeField] private MainGameRepository _mainGameRepository = null;
    [SerializeField] private SendButtonView _sendButtonView = null;
    [SerializeField] private ReceiveLetterTextView _receiveLetterText = null;

    [SerializeField] private SelectionButtonModel _selectionButtonModel;
    private int currentId = 1;

    void Start()
    {
        _sendButtonView.OnClickSendButtonObservable.Subscribe(_ => {
            MainGameLoop();
        });

        MainGameLoop();
    }

    public void MainGameLoop()
    {
        for (var i = 0; i < 2; i++)
        {
            var currentMessage = _mainGameRepository.MessagesVO.FirstOrDefault(vo => vo.Id == currentId);
            var currentMessageDTO = new MessageDTO(currentMessage);
            switch (currentMessage.Type)
            {
                // 相手からの返信の時
                case 1:
                    InitializeReceiveLetterText(currentMessageDTO);
                    currentId = currentMessageDTO.StepNums.FirstOrDefault();
                    break;

                // 選択肢の時
                case 2:
                    InitializeSelections(currentMessageDTO);
                    break;
            }
        // _selectionButtonViews
        }
    }

    private void InitializeReceiveLetterText(MessageDTO currentMessageDTO)
    {
        _receiveLetterText.SetText(currentMessageDTO.Messages.FirstOrDefault());
    }

    private void InitializeSelections(MessageDTO currentMessageDTO)
    {
        _selectionButtonModel.SetData(currentMessageDTO);
    }
}
