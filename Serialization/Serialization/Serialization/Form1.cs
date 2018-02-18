using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialization
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //serializing the object
        private void button1_Click(object sender, EventArgs e)
        {
            serializeObject srObj = new serializeObject();
            srObj.srString = ".Net serialization test !!";
            srObj.srInt = 1000;
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream fileStream = new FileStream("f:\\SerializeFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(fileStream, srObj);
            fileStream.Close();
            MessageBox.Show("Object Serialized !!");
        }
        //de-serializing the object
        private void button2_Click(object sender, EventArgs e)
        {
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream serialStream = new FileStream("f:\\SerializeFile.bin", FileModse.Open, FileAccess.Read, FileShare.Read);
            serializeObject srObj = (serializeObject)formatter.Deserialize(serialStream);
            serialStream.Close();
            MessageBox.Show(srObj.srString + "      " + srObj.srInt.ToString());
        }

    }
    //specimen class for serialization
    [Serializable]
    public class serializeObject
    {
        public string srString = null;
        public int srInt = 0;
    }
}