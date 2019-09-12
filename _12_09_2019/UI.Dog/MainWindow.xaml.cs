using DAL.Abstract;
using DAL.Concrete;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.Entities;

namespace UIDog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDogService _dogService;
        public MainWindow()
        {
            EFContext context = new EFContext();
            _dogService = new DogService(context);
            //_dogService.AddDogEvent += _dogService_AddDogEvent;
            _dogService.FindDogEvent += _dogService_FindDogEvent;
            InitializeComponent();
        }

        private void _dogService_FindDogEvent(Dog dog)
        {
            Dispatcher.BeginInvoke(new Action(() =>
                dgFindedDogs.Items.Add(dog)
                ));
        }

        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            _dogService.FindDogsAsync(new Dog() { Name = tboxDogName.Text });
        }

        //private void _dogService_AddDogEvent(int count)
        //{
        //    Dispatcher.BeginInvoke(new Action(() =>
        //        lbCountToAdd.Content = count
        //        ));
        //}

        //private void ButAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    int count = int.Parse(tboxCount.Text);

        //    _dogService.AddDogsRangeAsync(count);
        //}
    }
}
