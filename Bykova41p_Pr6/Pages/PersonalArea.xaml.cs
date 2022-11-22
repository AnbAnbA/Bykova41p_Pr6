using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace Bykova41p_Pr6.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalArea.xaml
    /// </summary>
    public partial class PersonalArea : Page
    {
        private Table_Users _user;

        // метод для отображения изображения в личном кабинете. первый аргумент - байтовый массив, в котором хранится изображение в БД, второй аргумент - имя изображения в разметке
        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();  // создаем объект для загрузки изображения
            using (MemoryStream m = new MemoryStream(Barray))  // для считывания байтового потока
            {
                BI.BeginInit();  // начинаем считывание
                BI.StreamSource = m;  // задаем источник потока
                BI.CacheOption = BitmapCacheOption.OnLoad;  // переводим изображение
                BI.EndInit();  // заканчиваем считывание
            }
            img.Source = BI;  // показываем картинку на экране (imUser – имя картиник в разметке)
            img.Stretch = Stretch.Uniform;
        }


        public PersonalArea(Table_Users User)
        {
            InitializeComponent();
            this._user = User;
            if (_user.IdRole == 1) 
            {
                btnBack.Visibility = Visibility.Visible;
            }
            tbName.Text = _user.Name;
            tbSurname.Text = _user.Surname;
            tbPatr.Text = _user.Patronymic;
            DPBirth.Text = _user.DateBirthday.ToString("dd.MM.yyyy года");
            List<Table_Phot> u = Base.ES.Table_Phot.Where(x=>x.idUser == _user.IdUsers).ToList();
            if (u.Count != 0)  // если список с фото не пустой, начинает переводить байтовый массив в изображение
            {

                byte[] Bar = u[u.Count - 1].Binpath;   // считываем изображение из базы (считываем байтовый массив двоичных данных) - выбираем последнее добавленное изображение
                showImage(Bar, imUser);  // отображаем картинку
            }
        }

        private void redaUserData_Click(object sender, RoutedEventArgs e)
        {
            WinPerArea winPerArea = new WinPerArea(_user);
            winPerArea.ShowDialog();
            FrameC.frameM.Navigate(new PersonalArea(_user));
        }

        private void redlogpar_Click(object sender, RoutedEventArgs e)
        {
            WinPerAreaLogPas winPerArealogpas = new WinPerAreaLogPas(_user);
            winPerArealogpas.ShowDialog();
            FrameC.frameM.Navigate(new PersonalArea(_user));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameC.frameM.Navigate(new Pages.MenuA(_user));  // переход в меню администратора
        }

        private void addph_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               Table_Phot u = new Table_Phot();
                u.idUser= _user.IdUsers;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();  // открываем диалоговое окно             
                string path = OFD.FileName;  // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                u.Binpath = Barray;
                Base.ES.Table_Phot.Add(u);
                Base.ES.SaveChanges();
                MessageBox.Show("Фото добавлено");
                FrameC.frameM.Navigate(new PersonalArea(_user));
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void addmoreph_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                OFD.Multiselect = true;  // открытие диалогового окна с возможностью выбора нескольких элементов
                if (OFD.ShowDialog() == true)  // пока диалоговое окно открыто, будет в цикле записывать каждое выбранное изображение в БД
                {
                    foreach (string file in OFD.FileNames)  // цикл организован по именам выбранных файлов
                    {
                        Table_Phot u = new Table_Phot();  // создание объекта для добавления записи в таблицу, где хранится фото
                        u.idUser = _user.IdUsers;  // присваиваем значение полю idUser (id авторизованного пользователя)
                        string path = file;  // считываем путь выбранного изображения
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);  // создаем объект для загрузки изображения в базу
                        ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                        u.Binpath = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                        Base.ES.Table_Phot.Add(u);  // добавляем объект в таблицу БД
                    }
                    Base.ES.SaveChanges();
                    MessageBox.Show("Фото добавлены");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void showgallery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btbackph_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
