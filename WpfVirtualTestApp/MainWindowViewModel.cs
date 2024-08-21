using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfVirtualTestApp
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; set; }

        public ICommand ChangeAllTextCommand { get; }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>();

            // デモ用に大量のデータを生成
            for (int i = 0; i < 1000; i++)
            {
                Items.Add(new ItemViewModel
                {
                    Name = $"Item {i + 1}",
                    Description = $"Description for item {i + 1}"
                });
            }

            ChangeAllTextCommand = new RelayCommand(ChangeAllText);
        }

        private void ChangeAllText()
        {
            var random = new Random();
            foreach (var item in Items)
            {
                // ランダムな文字列や数値を生成して、アイテムに設定
                item.Name = $"Changed Name {random.Next(1, 1000)}";
                item.Description = $"Changed Description {Guid.NewGuid()}";
            }
        }
    }

}
