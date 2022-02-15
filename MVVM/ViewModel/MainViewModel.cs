using ChatApp.Core;
using ChatApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace ChatApp.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /*Commands*/
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value; OnPropertyChanged();
            }
        }



        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel()
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });


            Messages.Add(new MessageModel
            {
                Username = "Allison",
                ImageSource = "https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png",
                UsernameColor = "#409aff",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeorigin = false,
                FirstMessage = true
            });
            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Allison",
                    UsernameColor = "#409aff",
                    ImageSource = "https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeorigin = false,
                    FirstMessage = false
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Bunny",
                    UsernameColor = "#409aff",
                    ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/SVG_Logo.svg/1024px-SVG_Logo.svg.png",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeorigin = false,
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Bunny",
                UsernameColor = "#409aff",
                ImageSource = "https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeorigin = false,
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allison {i}",
                    ImageSource = "https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png",
                    Messages = Messages
                });
            }
        }
    }
}
