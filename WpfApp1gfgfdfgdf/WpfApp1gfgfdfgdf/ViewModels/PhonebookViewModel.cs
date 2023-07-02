using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1gfgfdfgdf.Models;

namespace WpfApp1gfgfdfgdf.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void OnCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public class PhonebookViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
                //DeleteContactCommand.OnCanExecuteChanged();
            }
        }

        public ICommand AddContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        public PhonebookViewModel()
        {
            Contacts = new ObservableCollection<Contact>();

            AddContactCommand = new RelayCommand(AddContact);
            DeleteContactCommand = new RelayCommand(DeleteContact, CanDeleteContact);
        }

        private void AddContact(object parameter)
        {
            Contacts.Add(new Contact());
        }

        private void DeleteContact(object parameter)
        {
            if (SelectedContact != null)
                Contacts.Remove(SelectedContact);
        }

        private bool CanDeleteContact(object parameter)
        {
            return SelectedContact != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
