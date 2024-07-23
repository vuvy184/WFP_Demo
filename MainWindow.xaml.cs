using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.DirectoryServices.ActiveDirectory;
using System.ComponentModel;
using System;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Mô hình dữ liệu cho ListViewItem
        public class ListViewItemModel
        {
            public int ID { get; set; }
            public string Content { get; set; } = string.Empty;
        }

        // ObservableCollection để lưu trữ các mục trong ListView
        private ObservableCollection<ListViewItemModel> items;
        private int currentId = 1;
        private int? editingItemId = null; // Để lưu ID của mục đang được chỉnh sửa

        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<ListViewItemModel>();
            listView.ItemsSource = items;

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy giá trị từ TextBox
            string input = inputTextBox.Text;

            // Thêm giá trị vào ObservableCollection
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (editingItemId.HasValue)
                {
                    // Nếu đang chỉnh sửa, cập nhật mục hiện tại
                    var itemToEdit = items.FirstOrDefault(item => item.ID == editingItemId.Value);
                    if (itemToEdit != null)
                    {
                        itemToEdit.Content = input;
                    }
                    editingItemId = null; // Reset trạng thái chỉnh sửa
                }
                else
                {
                    // Thêm mục mới
                    int newId = items.Count > 0 ? items.Max(item => item.ID) + 1 : 1;
                    items.Add(new ListViewItemModel { ID = newId, Content = input });
                }
                inputTextBox.Clear(); // Xóa nội dung trong TextBox sau khi thêm hoặc chỉnh sửa
                listView.Items.Refresh(); // Làm mới ListView để cập nhật nội dung
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy ID của mục cần xóa từ thuộc tính Tag của nút
            int idToDelete = (int)((Button)sender).Tag;

            // Tìm mục có ID tương ứng và xóa khỏi ObservableCollection
            var itemToDelete = items.FirstOrDefault(item => item.ID == idToDelete);

            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
                
            }   
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
                int idToEdit = (int)((Button)sender).Tag;
                var itemToEdit = items.FirstOrDefault(item => item.ID == idToEdit);
                if (itemToEdit != null)
                {
                    inputTextBox.Text = itemToEdit.Content; // Đưa nội dung vào TextBox để chỉnh sửa
                    editingItemId = idToEdit; // Lưu ID của mục đang được chỉnh sửa
                }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị bảng thông báo xác nhận
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Kiểm tra kết quả
            if (result == MessageBoxResult.No)
            {
                // Nếu người dùng chọn "Không", hủy bỏ sự kiện đóng cửa
                e.Handled = true;
            }
            else
            {
                this.Close();
            }
        }

        private bool SaveDataToTXT(List<ListViewItemModel> data, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (ListViewItemModel info in data)
                    {
                        writer.WriteLine($"Id: {info.ID}, Info: {info.Content}");
                    }
                }
                return true; // Lưu thành công
            }
            catch(Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false; // Lưu thất bại
            }
           
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            // kiểm tra xem listview có chứa dữ liệu hay không
            if (listView.Items.Count == 0)
            {
                // hiển thị thông báo "không có dữ liệu"
                MessageBox.Show("vui lòng nhập dữ liệu!", "thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // thoát khỏi hàm
            }
            //lấy dữ liệu từ listview
            List<ListViewItemModel> data = new List<ListViewItemModel>();
            foreach (var item in listView.Items)
            {
                ListViewItemModel info = (ListViewItemModel)item;
                data.Add(info);
            }

            // Lưu dữ liệu vào file (ví dụ: lưu vào file txt)
            bool success = SaveDataToTXT(data, "data.txt");

            // Hiển thị thông báo
            if (success)
            {
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
