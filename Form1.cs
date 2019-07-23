using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace week11
{
    public class Employee
    {
        public string employee_name { get; set; }
        public string employee_phone { get; set; }
        public string employee_department { get; set; }
        public string employee_salary { get; set; }

    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Xml Serialization
            Employee obj = new Employee() { employee_name = textBox1.Text, employee_phone = textBox2.Text, employee_department = textBox3.Text,
                employee_salary = textBox4.Text };

            XmlSerializer serObj = new XmlSerializer(typeof(Employee));

            StreamWriter write = new StreamWriter(@"C:\Users\ladg2\Employee.xml");
            serObj.Serialize(write, obj);
            write.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Xml Deserialize
            XmlSerializer serObj = new XmlSerializer(typeof(Employee));
            StreamReader rdr = new StreamReader(@"C:\Users\ladg2\Employee.xml");

            Employee DeserilizedObj = (Employee)serObj.Deserialize(rdr);

            //print deserialize data
            textBox1.Text = DeserilizedObj.employee_name;
            textBox2.Text = DeserilizedObj.employee_phone;
            textBox3.Text = DeserilizedObj.employee_department;
            textBox4.Text = DeserilizedObj.employee_salary;

            rdr.Close();
        }
    }
}
