using MyMobileApp.Models;
using MyMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMobileApp.ViewModels
{
    class QuestionViewModel : BaseQuestionViewModel
    {
        private Question _selectedQuestion;

        public ObservableCollection<Question> Questions { get; }
        public Command LoadQuestionCommand { get; }
        public Command ModigyQuestionCommand { get; }
        public Command<Question> ItemTapped { get; }

        public QuestionViewModel()
        {
            Title = "Questions";
            Questions = new ObservableCollection<Question>();
            LoadQuestionCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Question>(OnItemSelected);

            ModigyQuestionCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Questions.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Questions.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Question SelectedItem
        {
            get => _selectedQuestion;
            set
            {
                SetProperty(ref _selectedQuestion, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Question item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
