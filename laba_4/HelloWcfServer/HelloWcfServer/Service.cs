using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;


namespace HelloWcfServer
{
 [Table(Name = "Table")]

        
    class Service : IContract
    {

        private int Id;
        [Column(Storage = "Id")]

        public int ID
        {
            get
            {
                return this.Id;
            }
        }
        private int text;
        [Column(Storage = "text")]

        public int Text
        {
            get
            {
                return this.text;
            }
        }

        private Bitmap CreateBitmapImage(string imageText)
        {
            Bitmap bitmap = new Bitmap(1, 1);

            int width = 0;
            int height = 0;

            // Создаем объект Font для "рисования" им текста.
            Font font = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            // Создаем объект Graphics для вычисления высоты и ширины текста.
            Graphics graphics = Graphics.FromImage(bitmap);

            // Определение размеров изображения.
            width = (int)graphics.MeasureString(imageText, font).Width;
            height = (int)graphics.MeasureString(imageText, font).Height;

            // Пересоздаем объект Bitmap с откорректированными размерами под текст и шрифт.
            bitmap = new Bitmap(bitmap, new Size(width, height));

            // Пересоздаем объект Graphics
            graphics = Graphics.FromImage(bitmap);

            // Задаем цвет фона.
            graphics.Clear(Color.White);
            // Задаем параметры анти-алиасинга
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // Пишем (рисуем) текст
            graphics.DrawString(imageText, font, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
            graphics.Flush();
            //Image i = (Image)b;
            return (bitmap);
        }

        private Image i;
        public byte[] Say (string input)
        {
            string data = null;
           // using (var db = new )
            DataContext db = new DataContext(@"Database1.mdf");
            Table<Service> Table = db.GetTable<Service>();
            db.Log = Console.Out;
            Console.WriteLine("recieved {0}", input);
            Console.WriteLine("Connecting to database....");

            var companyNameQuery =
    from cust in Table
    where cust.Id == 1
    select cust.text;

            foreach (var customer in companyNameQuery)
            {
                Console.WriteLine(customer.ToString());
            }


          //  IQueryable<Service> Query = from cust in Table where cust.Id == 1 select cust;
            Console.WriteLine("Creating query");

           // foreach (var cu in Query)
           // {
              //  Console.WriteLine(cu);
           // }


         //   foreach (Service cust in Query)
          //  {
              //  Console.WriteLine("Trying to print data...");
                //Console.WriteLine("id = {0}, text = {1}", cust.Id, cust.text);
              //  data = (cust.Id).ToString();
                
           // }
            Console.WriteLine("Taking data = {0]", data);
            Bitmap pic = CreateBitmapImage(data);
            i = (Image)pic;
            ImageConverter converter = new ImageConverter();
            Console.WriteLine((byte[])converter.ConvertTo(i, typeof(byte[])));
            return (byte[])converter.ConvertTo(i, typeof(byte[]));
            
        }
    }
}
