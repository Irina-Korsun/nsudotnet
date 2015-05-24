using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using DataBaseLab.DataObjects;

namespace WpfFormsAndTables
{
    /// <summary>
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public ObservableCollection<Field> Fields { get; set; }
        public System.Type ObjType = null;
        public Object Ins { get; set; }
        public AddingWindow()
        {
            InitializeComponent();
        }
        public void ToAdd<T>(){
            var type = typeof(T);
            ObjType = type;
            Fields = new ObservableCollection<Field>();
            PropertyInfo[] Props = ObjType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                if (prop.Name != "ID")
                Fields.Add(new Field() { Name = prop.Name, Length = 100, Required = true });
            }
            FieldsListBox.ItemsSource = Fields;
            Ins = Activator.CreateInstance<T>();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //var t = Ins.GetType();
            //if (t.Equals(typeof(Departments))){
            //MessageBox.Show(t.ToString());
            //MessageBox.Show(typeof(Departments).ToString());
            //}
            //string Name;
            //string chief;
            //string employee;
                 //   MessageBox.Show(FieldsListBox);

            //foreach (var field in Fields)
            //{
            //    if (field.Name.Equals("Name"))
            //    {
            //        Name = Convert.ChangeType(Fields[i].Name, prop.PropertyType);
            //    }
            //}
           /* var item = Activator.CreateInstance(ObjType);
            PropertyInfo[] Props = ObjType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                int i = 1;
                prop.SetValue(item, Convert.ChangeType(Fields[i].Name, prop.PropertyType), null);
                i++;
            }
            Ins = item;
            this.Close();*/

        }
            public Object GetResult(){
                return Ins;
            }
    }
       
    public class Field
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public bool Required { get; set; }
    }
}
