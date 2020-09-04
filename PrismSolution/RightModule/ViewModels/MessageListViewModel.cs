using Prism.Events;
using Prism.Mvvm;
using PrismApp.Core;
using System;
using System.Collections.ObjectModel;

namespace RightModule.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        IEventAggregator _ea;

        // Messages
        private ObservableCollection<string> messages;
        public ObservableCollection<string> Messages
        {
            get => messages;
            set => SetProperty(ref messages, value);
        }

        public MessageListViewModel(IEventAggregator ea) // 생성자
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();
            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread, false, 
                filter => filter.Contains("Prism"));
        }

        private void MessageReceived(string message) // 메서드 생성
        {
            Messages.Add(message);
        }
    }
}
