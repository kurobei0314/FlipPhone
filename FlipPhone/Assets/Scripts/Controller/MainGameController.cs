using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using System.Linq;

public class MainGameController : MonoBehaviour
{
    [SerializeField] private MainGameRepository _mainGameRepository = null;
    [SerializeField] private SendButtonPresenter _sendButtonPresenter = null;
    [SerializeField] private ReceiveLetterTextView _receiveLetterText = null;
    [SerializeField] private ReceivingGroupView _receivingGroupView = null;
    [SerializeField] private SendingGroupView _sendingGroupView = null;

    [SerializeField] private SelectionButtonModel _selectionButtonModel;
    private int currentId = 1;

    void Start()
    {
        _sendButtonPresenter.OnClickSendButtonObservable.Subscribe(step_num => {

            currentId = step_num;
            StartCoroutine("PlaySendAnim");
            MainGameLoop();
        });

        MainGameLoop();
        _receivingGroupView.PlayAnim();
    }

    public void MainGameLoop()
    {
        for (var i = 0; i < 2; i++)
        {
            var currentMessage = _mainGameRepository.MessagesVO.FirstOrDefault(vo => vo.Id == currentId);
            if (currentMessage == null) break;
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
        }
    }

    private IEnumerator PlaySendAnim()
    {
        _sendingGroupView.PlayAnim();
        yield return new WaitForSeconds(0.7f);
        _receivingGroupView.PlayAnim();
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
